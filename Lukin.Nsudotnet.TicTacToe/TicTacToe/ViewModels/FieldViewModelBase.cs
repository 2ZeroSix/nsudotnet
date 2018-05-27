using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public abstract class FieldViewModelBase : Screen
    {
        public int Winner => 1;
        protected readonly IField _field;

        public int Col => _field.Col;
        public int Row => _field.Row;
        protected FieldViewModelBase(IField field)
        {
            this._field = field;
        }
    }
}