﻿#pragma checksum "C:\Users\luisdeolpy\Documents\Visual Studio 2015\Projects\DutiesManager\DutiesManager\Views\Main.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EABF79BFF108875CEC4D8D29C84EFCE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DutiesManager.Views
{
    partial class Main : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Sv = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.BHamburger = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\Views\Main.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BHamburger).Click += this.BHamburger_OnClick;
                    #line default
                }
                break;
            case 3:
                {
                    this.SvContent = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 22 "..\..\..\Views\Main.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)this.SvContent).Loaded += this.SvContent_OnLoaded;
                    #line default
                }
                break;
            case 4:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.FilterTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.TbTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.LbDuties = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 30 "..\..\..\Views\Main.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.LbDuties).SelectionChanged += this.LbDuties_SelectionChanged;
                    #line default
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element8 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 42 "..\..\..\Views\Main.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element8).Click += this.Add_OnClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

