﻿#pragma checksum "..\..\..\Forms\RobaForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A93EFDCAE467BC41143BEFB33CA79AC0B87731F852649E1EF8030C559C0867F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DBProject.Forms;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace DBProject.Forms {
    
    
    /// <summary>
    /// RobaForm
    /// </summary>
    public partial class RobaForm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Forms\RobaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NazivBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Forms\RobaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CijenaBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Forms\RobaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KolicinaBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Forms\RobaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DodajButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Forms\RobaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AzurirajBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Forms\RobaForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AzurirajButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DBProject;component/forms/robaform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\RobaForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NazivBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CijenaBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.KolicinaBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DodajButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Forms\RobaForm.xaml"
            this.DodajButton.Click += new System.Windows.RoutedEventHandler(this.Dodaj_Klik);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AzurirajBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AzurirajButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Forms\RobaForm.xaml"
            this.AzurirajButton.Click += new System.Windows.RoutedEventHandler(this.Azuriraj_Klik);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

