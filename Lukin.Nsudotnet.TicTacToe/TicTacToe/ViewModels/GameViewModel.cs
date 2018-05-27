using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
        public class GameViewModel : FieldViewModelBase
    {
        public string CurrentPlayer => ((GameModel) _field).CurrentPlayer.ToString();

        private FieldViewModelBase _activeItem;

        public FieldViewModelBase ActiveItem
        {
            get => _activeItem;
            set
            {
                if (Equals(value, _activeItem)) return;
                _activeItem = value;
                NotifyOfPropertyChange(() => ActiveItem);
            }
        }

        public GameViewModel(GameModel gameModel) : base(gameModel)
        {
            ActiveItem = FieldViewModelFactory.GetFieldViewModel(gameModel.Cells[0]);
            gameModel.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "CurrentPlayer") NotifyOfPropertyChange(() => CurrentPlayer);
                if (e.PropertyName == "State" && Parent is IConductor parent)
                {
                    parent.DeactivateItem(this, true);
                    parent.ActivateItem(new EndGameViewModel(State));
                }
            };
        }


        public void Surrender()
        {
            if (Parent is IConductor parent)
            {
                parent.DeactivateItem(this, true);
                parent.ActivateItem(new EndGameViewModel((State)(3 - ((GameModel) _field).CurrentPlayer)));
            }
        }
    }
}