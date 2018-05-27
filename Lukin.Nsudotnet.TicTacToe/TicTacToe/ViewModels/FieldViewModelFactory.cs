using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class FieldViewModelFactory
    {
        public static FieldViewModelBase GetFieldViewModel(IField field)
        {
            if (field.GetType() == typeof(Cell))
            {
                return new CellViewModel(field as Cell);
            }
            else
            {
                return new FieldViewModel(field);
            }
        }
    }
}