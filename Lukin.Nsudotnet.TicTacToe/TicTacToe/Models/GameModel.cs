using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class GameModel : FieldBase
    {
        public GameModel(IField field)
        {
            field.Parent = this;
            Cells = new List<IField> {field};
            field.Current = true;
        }

        private Player _currentPlayer = Player.Player1;

        public Player CurrentPlayer
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
            var parent = cell.Parent;
            if (parent.Parent != null && !(parent.Parent is GameModel))
            {
                var rowPath = new List<int> {cell.Row};
                var columnPath = new List<int> {cell.Col};
                while (parent != null && !(parent.Parent?.Parent is GameModel))
                {
                    rowPath.Add(parent.Row);
                    columnPath.Add(parent.Col);
                    parent = parent.Parent;
                }

                parent = Cells[0];
                for (var i = rowPath.Count - 1; i >= 0 ; --i)
                {
                    parent = parent.Cells[rowPath[i] * 3 + columnPath[i]];
                }

                foreach (var subField in parent.Cells)
                {
                    if (subField.State != 0) continue;
                    parent.Current = true;
                    CurrentPlayer = 3 - CurrentPlayer;
                    return;
                }

                while (!(parent is GameModel))
                {
                    foreach (var subField in parent.Cells)
                    {
                        if (subField.State != 0) continue;
                        parent.Current = true;
                        CurrentPlayer = 3 - CurrentPlayer;
                        return;
                    }

                    parent = parent.Parent;
                }
            }
            else
            {
                Cells[0].Current = true;
                CurrentPlayer = 3 - CurrentPlayer;
                return;
            }


            State = 0;
        }

        public override void recalcWinner(Player player)
        {
            if (Cells[0].State != State.Empty)
            {
                State = Cells[0].State;
            }
        }
    }
}