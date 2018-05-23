using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class FieldViewModel : Conductor<FieldViewModel>.Collection.AllActive
    {
        public FieldViewModel(IField field)
        {
            if (field.Cells == null) return;
            foreach (var cell in field.Cells)
            {
                Items.Add(new FieldViewModel(cell));
            }
             
        }
        
    }
}