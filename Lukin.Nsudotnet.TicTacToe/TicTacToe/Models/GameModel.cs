using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class GameModel : FieldBase
    {
        public GameModel(IField field)
        {
            field.Parent = this;
            Cells = new List<IField> {field};
        }

        private int _currentPlayer = 1;

        public int CurrentPlayer
        {
            get => _currentPlayer;
            private set
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

            Cells[0].Current = false;
            var parent = cell.Parent?.Parent;
            if (parent == null) return;
            foreach (var subField in parent.Cells[cell.Row * 3 + cell.Col].Cells)
            {
                if (subField.Winner != 0) continue;
                parent.Cells[cell.Row * 3 + cell.Col].Current = true;
                CurrentPlayer = 3 - CurrentPlayer;
                return;
            }

            while (parent != null)
            {
                foreach (var subField in parent.Cells)
                {
                    if (subField.Winner != 0) continue;
                    parent.Current = true;
                    CurrentPlayer = 3 - CurrentPlayer;
                    return;
                }

                parent = parent.Parent;
            }
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