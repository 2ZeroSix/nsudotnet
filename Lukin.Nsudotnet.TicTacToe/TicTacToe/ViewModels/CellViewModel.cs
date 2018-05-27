using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class CellViewModel : FieldViewModelBase
    {
        public bool Win1IsVisible => _field.Winner == 1;

        public bool Win2IsVisible => _field.Winner == 2;

        public bool IsClickable => _field.Current;

        public CellViewModel(Cell cell) : base(cell)
        {
            _field.PropertyChanged += (o, e) =>
            {
                switch (e.PropertyName)
                {
                    case "Winner":
                        NotifyOfPropertyChange(() => Win1IsVisible);
                        NotifyOfPropertyChange(() => Win2IsVisible);
                        break;
                    case "Current":
                        NotifyOfPropertyChange(() => IsClickable);
                        break;
                }
            };
        }

        public void Click()
        {
            (_field as Cell)?.Click();
        }
    }
}