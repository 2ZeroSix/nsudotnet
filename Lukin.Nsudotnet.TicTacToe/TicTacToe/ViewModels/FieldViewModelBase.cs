using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public abstract class FieldViewModelBase : Screen
    {
        public bool Win1IsVisible => _field.State == State.Player1;

        public bool Win2IsVisible => _field.State == State.Player2;
        public State State => _field.State;
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
                    case "State":
                        NotifyOfPropertyChange(() => Win1IsVisible);
                        NotifyOfPropertyChange(() => Win2IsVisible);
                        break;
                }
            };
        }
    }
}