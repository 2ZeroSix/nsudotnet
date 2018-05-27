using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
        public class GameViewModel : Conductor<FieldViewModelBase>
    {
        private BaseGameModel _game;
        public int CurrentPlayer;
        public GameViewModel(BaseGameModel gameModel)
        {
            _game = gameModel;
            ActiveItem = FieldViewModelFactory.GetFieldViewModel(_game.Cells[0]);
        }

        public void Surrender()
        {
            if (Parent is IConductor parent)
            {
                parent.DeactivateItem(this, true);
            }
        }
    }
}