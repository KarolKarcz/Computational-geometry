﻿#pragma checksum "..\..\..\..\Views\MeshView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4C07F85EA5AB9373C3E5AFA1F0092D0091C5D9AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MeshGO.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MeshGO.Views {
    
    
    /// <summary>
    /// MeshView
    /// </summary>
    public partial class MeshView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GENERATE;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateTriangle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateRandomSquare;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generateRandomTriangle;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fileTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button fileGenerate;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Square;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Triangle;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button fileLoad;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox1;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Views\MeshView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Cnva;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MeshGO;component/views/meshview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MeshView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GENERATE = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Views\MeshView.xaml"
            this.GENERATE.Click += new System.Windows.RoutedEventHandler(this.GENERATE_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.generateTriangle = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Views\MeshView.xaml"
            this.generateTriangle.Click += new System.Windows.RoutedEventHandler(this.generateTriangle_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.generateRandomSquare = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Views\MeshView.xaml"
            this.generateRandomSquare.Click += new System.Windows.RoutedEventHandler(this.generateRandomSquare_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.generateRandomTriangle = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Views\MeshView.xaml"
            this.generateRandomTriangle.Click += new System.Windows.RoutedEventHandler(this.generateRandomTriangle_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.fileTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\..\Views\MeshView.xaml"
            this.fileTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.fileTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.fileGenerate = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Views\MeshView.xaml"
            this.fileGenerate.Click += new System.Windows.RoutedEventHandler(this.fileGenerate_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Square = ((System.Windows.Controls.CheckBox)(target));
            
            #line 66 "..\..\..\..\Views\MeshView.xaml"
            this.Square.Checked += new System.Windows.RoutedEventHandler(this.Square_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Triangle = ((System.Windows.Controls.CheckBox)(target));
            
            #line 71 "..\..\..\..\Views\MeshView.xaml"
            this.Triangle.Checked += new System.Windows.RoutedEventHandler(this.Triangle_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.fileLoad = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\Views\MeshView.xaml"
            this.fileLoad.Click += new System.Windows.RoutedEventHandler(this.fileLoad_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.TextBox1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 85 "..\..\..\..\Views\MeshView.xaml"
            this.TextBox1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Cnva = ((System.Windows.Controls.Canvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

