// Updated by XamlIntelliSenseFileGenerator 02/08/2021 16:02:01
#pragma checksum "..\..\FinestraTata.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9DAA68039CF444D0EC89ABF5033D92C126F4365A7876AAB18E057E60C38FB7F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_T;
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


namespace Project_T
{


    /// <summary>
    /// FinestraTata
    /// </summary>
    public partial class FinestraTata : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 9 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid txt_zona_operativa;

#line default
#line hidden


#line 12 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login;

#line default
#line hidden


#line 13 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email;

#line default
#line hidden


#line 14 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_password;

#line default
#line hidden


#line 15 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_nome;

#line default
#line hidden


#line 16 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_cognome;

#line default
#line hidden


#line 21 "..\..\FinestraTata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_registrati;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project T;component/finestratata.xaml", System.UriKind.Relative);

#line 1 "..\..\FinestraTata.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.txt_zona_operativa = ((System.Windows.Controls.Grid)(target));
                    return;
                case 2:
                    this.btn_login = ((System.Windows.Controls.Button)(target));

#line 12 "..\..\FinestraTata.xaml"
                    this.btn_login.Click += new System.Windows.RoutedEventHandler(this.btn_login_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.txt_email = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.txt_password = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 5:
                    this.txt_nome = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.txt_cognome = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.btn_registrati = ((System.Windows.Controls.Button)(target));

#line 21 "..\..\FinestraTata.xaml"
                    this.btn_registrati.Click += new System.Windows.RoutedEventHandler(this.btn_registrati_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox txt_zona_operativa1;
    }
}
