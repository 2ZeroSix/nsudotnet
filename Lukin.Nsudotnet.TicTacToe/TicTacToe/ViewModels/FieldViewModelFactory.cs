using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public static class FieldViewModelFactory
    {
        public static FieldViewModelBase GetFieldViewModel(IField field)
        {
            switch (field)
            {
                case Cell cell:
                    return new CellViewModel(cell);
                case GameModel gameModel:
                    return new GameViewModel(gameModel);
                default:
                    return new FieldViewModel(field);
            }
        }
    }
}