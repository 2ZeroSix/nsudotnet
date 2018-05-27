using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public abstract class FieldViewModelBase : Screen
    {
        public bool Win1IsVisible => _field.Winner == 1;

        public bool Win2IsVisible => _field.Winner == 2;
        public int Winner => 1;
        protected readonly IField _field;

        public int Col => _field.Col;
        public int Row => _field.Row;
        protected FieldViewModelBase(IField field)
        {
            this._field = field;
            _field.PropertyChanged += (o, e) =>
            {
                switch (e.PropertyName)
                {
                    case "Winner":
                        NotifyOfPropertyChange(() => Win1IsVisible);
                        NotifyOfPropertyChange(() => Win2IsVisible);
                        break;
                }
            };
        }
    }
}