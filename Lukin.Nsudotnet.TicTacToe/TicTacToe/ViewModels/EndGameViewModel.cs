using System;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class EndGameViewModel : Screen
    {
        public string Winner { get; set; }
        public EndGameViewModel(State state)
        {
            if (state == State.Draw)
            {
                Winner = "DRAW";
            } else if (state == State.Empty)
            {
                Winner = "UNKNOWN ERROR";
            }
            else
            {
                Winner = string.Concat("Player ", state, " WON");
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