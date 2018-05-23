using System.Windows;
using Caliburn.Micro;

namespace TicTacToe.ViewModels
{
    public class MenuViewModel : Screen
    {
        public void Start()
        {
            if (Parent is IConductor parent)
                parent.ActivateItem(new GameViewModel());
            
        }
        
        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}