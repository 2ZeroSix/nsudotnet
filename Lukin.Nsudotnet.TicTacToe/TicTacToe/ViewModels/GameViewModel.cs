using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class GameViewModel : Conductor<FieldViewModel>
    {
        private Field<Field<Cell>> _field;
        public IPlayer player { get; }

        public GameViewModel()
        {
            _field = new Field<Field<Cell>>();
            ActiveItem = new FieldViewModel(new Field<Field<Cell>>());
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