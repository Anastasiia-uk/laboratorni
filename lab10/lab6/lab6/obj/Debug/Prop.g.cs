#pragma checksum "..\..\Prop.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "34C0382005E9498DF63FE8746FA42C17D7895C687F972214E59CA43B189EC961"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using lab6;


namespace lab6 {
    
    
    /// <summary>
    /// Prop
    /// </summary>
    public partial class Prop : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Prop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FontComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Prop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ColorBgComboBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Prop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ColorFgComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/lab6;component/prop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Prop.xaml"
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
            this.FontComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\Prop.xaml"
            this.FontComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FontComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ColorBgComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\Prop.xaml"
            this.ColorBgComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ColorBgComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ColorFgComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\Prop.xaml"
            this.ColorFgComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ColorFgComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

