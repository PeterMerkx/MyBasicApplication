﻿#pragma checksum "..\..\..\Themes\ResourceDictionary.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AFDE7C61F37128288B0155B58F1CAB0592F3264903C8DF0D21CB68DE488CA60A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Controls.Local;
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


namespace MyBasicApplication {
    
    
    /// <summary>
    /// OfficeStyleWindow
    /// </summary>
    public partial class OfficeStyleWindow : System.Windows.ResourceDictionary, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/MyBasicApplication;component/themes/resourcedictionary.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Themes\ResourceDictionary.xaml"
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
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 189 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeNorth);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 195 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeSouth);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 202 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeWest);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 208 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeEast);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 215 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeNorthWest);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 216 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeNorthEast);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 217 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeSouthWest);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 218 "..\..\..\Themes\ResourceDictionary.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeSouthEast);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

