using Caliburn.Micro;

namespace TicTacToe.ViewModels
{
    public class AppViewModel : Conductor<object>.Collection.OneActive
    {
        public AppViewModel()
        {
            ActiveItem = new MenuViewModel();
            
        }
    }
}