namespace TicTacToe.Models
{
    public class Cell : FieldBase
    {
        public Cell(IField parent=null)
        {
            Parent = parent;
        }

        public Cell() : this(null)
        {
        }

        public void Click()
        {
            IField gameModel = this;
            while (gameModel.Parent != null)
            {
                gameModel = gameModel.Parent;
            }

            if (gameModel is GameModel model)
            {
                model.Click(this);
            }
        }

        public override void recalcWinner(int player)
        {
            if (Winner == 0) Winner = player;
        }
    }
}