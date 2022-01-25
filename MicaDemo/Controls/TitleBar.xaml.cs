﻿using MicaDemo.Helpers;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace MicaDemo.Controls
{
    public sealed partial class TitleBar : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
           nameof(Title),
           typeof(string),
           typeof(TitleBar),
           new PropertyMetadata(default(string)));

        public static readonly DependencyProperty TitleHeightProperty = DependencyProperty.Register(
           nameof(TitleHeight),
           typeof(double),
           typeof(TitleBar),
           new PropertyMetadata(40d));

        public static readonly DependencyProperty IsBackEnableProperty = DependencyProperty.Register(
           nameof(IsBackEnable),
           typeof(bool),
           typeof(TitleBar),
           new PropertyMetadata(true));

        public static readonly DependencyProperty RightAreaContentProperty = DependencyProperty.Register(
           nameof(RightAreaContent),
           typeof(object),
           typeof(TitleBar),
           null);

        public static readonly DependencyProperty BackgroundVisibilityProperty = DependencyProperty.Register(
           nameof(BackgroundVisibility),
           typeof(Visibility),
           typeof(TitleBar),
           new PropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty BackButtonVisibilityProperty = DependencyProperty.Register(
           nameof(BackButtonVisibility),
           typeof(Visibility),
           typeof(TitleBar),
           new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty RefreshButtonVisibilityProperty = DependencyProperty.Register(
           nameof(RefreshButtonVisibility),
           typeof(Visibility),
           typeof(TitleBar),
           new PropertyMetadata(Visibility.Collapsed));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public double TitleHeight
        {
            get => (double)GetValue(TitleHeightProperty);
            set => SetValue(TitleHeightProperty, value);
        }

        public bool IsBackEnable
        {
            get => (bool)GetValue(IsBackEnableProperty);
            set => SetValue(IsBackEnableProperty, value);
        }

        public object RightAreaContent
        {
            get => GetValue(RightAreaContentProperty);
            set => SetValue(RightAreaContentProperty, value);
        }

        public Visibility BackgroundVisibility
        {
            get => (Visibility)GetValue(BackgroundVisibilityProperty);
            set => SetValue(BackgroundVisibilityProperty, value);
        }

        public Visibility BackButtonVisibility
        {
            get => (Visibility)GetValue(BackButtonVisibilityProperty);
            set => SetValue(BackButtonVisibilityProperty, value);
        }

        public Visibility RefreshButtonVisibility
        {
            get => (Visibility)GetValue(RefreshButtonVisibilityProperty);
            set => SetValue(RefreshButtonVisibilityProperty, value);
        }

        public event RoutedEventHandler RefreshEvent;
        public event RoutedEventHandler BackRequested;

        public TitleBar() => InitializeComponent();

        private void RefreshButton_Click(object sender, RoutedEventArgs e) => RefreshEvent?.Invoke(sender, e);

        private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(sender, e);

        private void TitleGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (e.OriginalSource is Grid || (e.OriginalSource is TextBlock a && a == TitleBlock))
            { RefreshEvent?.Invoke(sender, e); }
        }

        public void ShowProgressRing()
        {
            ProgressRing.IsActive = true;
            ProgressRing.Visibility = Visibility.Visible;
        }

        public void HideProgressRing()
        {
            ProgressRing.Visibility = Visibility.Collapsed;
            ProgressRing.IsActive = false;
        }
    }
}
