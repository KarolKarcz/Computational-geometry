using Caliburn.Micro;
using MeshGO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MeshGO
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>(); 
        }
    }
}
