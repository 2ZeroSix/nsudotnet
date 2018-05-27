using System;
using Caliburn.Micro;

namespace TicTacToe.ViewModels
{
    public class EndGameViewModel : Screen
    {
        public string Winner { get; set; }
        public EndGameViewModel(int winner)
        {
            if (winner == 0)
            {
                Winner = "DRAW";
            }
            else
            {
                Winner = string.Concat("Player ", winner, " WON");
            }
        }

        public void Close()
        {
            if (Parent is IConductor parent)
            {
                parent.DeactivateItem(this, true);
            }
        }
    }
}