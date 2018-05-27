using Caliburn.Micro;
using TicTacToe.Models;

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