﻿using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MyBasicApplication.Core;

namespace Controls.Local
{
    public class TitleBar : System.Windows.Controls.Control
    {
        ImageButton closeButton;
        ImageButton maxButton;
        ImageButton minButton;
     
        public TitleBar()
        {
            this.MouseLeftButtonDown += new MouseButtonEventHandler(OnTitleBarLeftButtonDown);
            this.MouseDoubleClick += new MouseButtonEventHandler(TitleBar_MouseDoubleClick);
            this.Loaded += new RoutedEventHandler(TitleBar_Loaded);

        }

        void TitleBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MaxButton_Click(sender, e);
        }

        void TitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            closeButton = (ImageButton)this.Template.FindName("CloseButton", this);
            minButton = (ImageButton)this.Template.FindName("MinButton", this);
            maxButton = (ImageButton)this.Template.FindName("MaxButton", this);

 

            closeButton.Click += new RoutedEventHandler(CloseButton_Click);
            minButton.Click += new RoutedEventHandler(MinButton_Click);
            maxButton.Click += new RoutedEventHandler(MaxButton_Click);
        }


        static TitleBar()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitleBar), new FrameworkPropertyMetadata(typeof(TitleBar)));
        }
        #region event handlers

        void OnTitleBarLeftButtonDown(object sender, MouseEventArgs e)
        {
            Window window = this.TemplatedParent as Window;
            if (window != null)
            {
                window.DragMove();
            }
        }

     
        void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        void MinButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = this.TemplatedParent as Window;
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = this.TemplatedParent as Window;
            if (window != null)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    maxButton.ImageDown = "/images/maxpressed_n.png";
                    maxButton.ImageNormal = "/images/max_n.png";
                    maxButton.ImageOver = "/images/maxhot_n.png";

                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    maxButton.ImageDown = "/images/normalpress.png";
                    maxButton.ImageNormal = "/images/normal.png";
                    maxButton.ImageOver = "/images/normalhot.png";

                    window.WindowState = WindowState.Maximized;
                }
            }
        }
        #endregion

            #region properties

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        #endregion

        #region dependency properties

        public static readonly DependencyProperty TitleProperty =
           DependencyProperty.Register(
               "Title", typeof(string), typeof(TitleBar));

        public static readonly DependencyProperty IconProperty =
           DependencyProperty.Register(
               "Icon", typeof(ImageSource), typeof(TitleBar));

        #endregion

    }
}
