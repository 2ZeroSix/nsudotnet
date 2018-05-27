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

        public bool IsClickable => _field.Current && _field.State == 0;

        public CellViewModel(Cell cell) : base(cell)
        {
            _field.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "Current") NotifyOfPropertyChange(() => IsClickable);
            };
        }

        public void Click()
        {
            (_field as Cell)?.Click();
        }
    }
}