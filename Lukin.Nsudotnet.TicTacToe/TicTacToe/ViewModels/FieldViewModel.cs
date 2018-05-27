using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class FieldViewModel : FieldViewModelBase
    {
        private BindableCollection<FieldViewModelBase> _items;

        public BindableCollection<FieldViewModelBase> Items
        {
            get => _items;
            private set
            {
                if (Equals(value, _items)) return;
                _items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }

        public FieldViewModel(IField field) : base(field)
        {
            if (field.Cells == null) return;
            Items = new BindableCollection<FieldViewModelBase>();
            foreach (var cell in field.Cells)
            {
                Items.Add(FieldViewModelFactory.GetFieldViewModel(cell));
            }             
        }
    }
}