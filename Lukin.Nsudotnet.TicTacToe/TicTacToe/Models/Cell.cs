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

        public override void recalcWinner(Player player)
        {
            if (State == 0) State = (State) player;
        }
    }
}