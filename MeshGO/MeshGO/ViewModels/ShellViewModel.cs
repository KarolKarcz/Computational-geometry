using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeshGO.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public void GENERATE()
        {
            ActivateItem(new MeshViewModel());
        }

        public void SIMPLEMESH()
        {
            ActivateItem(new SimpleMeshViewModel());
        }

        public void CONVEXHULL()
        {
            ActivateItem(new ConvexHullViewModel());
        }
    }
}
