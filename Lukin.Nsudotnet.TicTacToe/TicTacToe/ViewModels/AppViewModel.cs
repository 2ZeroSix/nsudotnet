using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class AppViewModel : Conductor<object>.Collection.OneActive
    {
        public AppViewModel()
        {
            ActiveItem = new MenuViewModel();
            ActiveItem = new GameViewModel(new GameModel<Field<Field<Cell>>>());
//            ActiveItem = new CellViewModel(new Cell());
        }
    }
}