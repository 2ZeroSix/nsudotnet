using System.Windows;
using Caliburn.Micro;
using TicTacToe.ViewModels;

namespace TicTacToe
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper() {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<AppViewModel>();
        }
    }
}