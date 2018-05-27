using System.Collections.Generic;
using System.ComponentModel;
using Caliburn.Micro;

namespace TicTacToe.Models
{
    public interface IField : INotifyPropertyChangedEx, INotifyPropertyChanged
    {
        bool Current { get; set; }
        int Col { get; set; }
        int Row { get; set; }
        IField Parent { get; set; }
        List<IField> Cells { get; }
        int Winner { get; set; }
        void recalcWinner(int player);
    }
}