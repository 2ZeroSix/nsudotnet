using System.Collections.Generic;
using System.Dynamic;
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
//            var windowSettings =
//                new Dictionary<string, object> {{"MinWidth", 300}, {"MinHeight", 300}};
            DisplayRootViewFor<AppViewModel>();
        }
    }
}