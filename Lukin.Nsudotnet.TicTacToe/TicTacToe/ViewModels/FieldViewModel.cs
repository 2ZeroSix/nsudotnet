using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class FieldViewModel : FieldViewModelBase
    {
        public BindableCollection<FieldViewModelBase> Items { get; private set; }
        public FieldViewModel(IField field) : base(field)
        {
            if (field.Cells == null) return;
            Items = new BindableCollection<FieldViewModelBase>();
            if (field.Col == 1 && field.Row == 1) field.Current = true;
            foreach (var cell in field.Cells)
            {
                Items.Add(FieldViewModelFactory.GetFieldViewModel(cell));
            }             
        }
    }
}