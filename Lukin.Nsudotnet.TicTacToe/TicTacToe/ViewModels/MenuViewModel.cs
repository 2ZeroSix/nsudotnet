using System.Windows;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class MenuViewModel : Screen
    {
        public void Start()
        {
            if (Parent is IConductor parent)
                parent.ActivateItem(new GameViewModel(new GameModel(new Field<Field<Field<Cell>>>())));
            
        }
        
        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}