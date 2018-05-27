namespace TicTacToe.Models
{
    public abstract class BaseGameModel : BaseField
    {
        private int _currentPlayer = 1;
        public int CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                if (value == _currentPlayer) return;
                _currentPlayer = value;
                NotifyOfPropertyChange(() => CurrentPlayer);
            }
        }

        public void Click(Cell cell)
        {
            if (!cell.Current) return;
            IField field = cell;
            while (field != null)
            {
                field.recalcWinner(CurrentPlayer);
                field = field.Parent;
            }
            cell.Parent.Current = false;
            cell.Parent.Parent.Cells[cell.Row * 3 + cell.Col].Current = true;
            CurrentPlayer = 3 - CurrentPlayer;
        }
        
        public override void recalcWinner(int player)
        {
            if (Cells[0].Winner != 0)
            {
                Winner = Cells[0].Winner;
            }
        }

    }
}