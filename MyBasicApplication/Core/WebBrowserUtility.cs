﻿using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyBasicApplication.Core
{
    public class WebBrowserUtility : BindableBase
    {
        public static readonly DependencyProperty BindableSourceProperty =
                      DependencyProperty.RegisterAttached("BindableSource", typeof(string),
                      typeof(WebBrowserUtility), new UIPropertyMetadata(null,
                      BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o,
                                                         DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebBrowser)o;
            if (webBrowser != null)
            {
                string uri = e.NewValue as string;
                webBrowser.Source = !String.IsNullOrEmpty(uri) ? new Uri(uri) : null;
            }

        }

    }
}
