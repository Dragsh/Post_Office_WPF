﻿#pragma checksum "..\..\..\View\AddSubcriberWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "299E4B44E85ADAC8CD6C8A0073E5155C88BC3DEFB832B8070AB7B86851FF8E6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PostOffice.View;
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


namespace PostOffice.View {
    
    
    /// <summary>
    /// AddSubcriberWindow
    /// </summary>
    public partial class AddSubcriberWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 64 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImagePhoto;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxSurname;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxName;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxPatronymic;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbxStreet;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbHouse;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbApartment;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\View\AddSubcriberWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbxSector;
        
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
            System.Uri resourceLocater = new System.Uri("/PostOffice;component/view/addsubcriberwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AddSubcriberWindow.xaml"
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
            
            #line 16 "..\..\..\View\AddSubcriberWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\..\View\AddSubcriberWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ImagePhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.TxtBoxSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TxtBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxtBoxPatronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CbxStreet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.TxbHouse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TxbApartment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.CbxSector = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
