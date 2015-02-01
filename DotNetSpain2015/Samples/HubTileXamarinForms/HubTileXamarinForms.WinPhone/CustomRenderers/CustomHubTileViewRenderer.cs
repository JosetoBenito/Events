﻿using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HubTileXamarinForms.CustomControls;
using HubTileXamarinForms.WinPhone.CustomRenderers;
using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer((typeof(CustomHubTileView)), typeof(CustomHubTileViewRenderer))]
namespace HubTileXamarinForms.WinPhone.CustomRenderers
{
    public class CustomHubTileViewRenderer : ViewRenderer<CustomHubTileView, HubTile>
    {
        private HubTile HubTile;

        public CustomHubTileViewRenderer()
        {
            HubTile = new HubTile
            {
                Margin = new System.Windows.Thickness(5)
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomHubTileView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            HubTile.Title = Element.Title;
            HubTile.Message = Element.Message;
            var fileImageSource = Element.Source as FileImageSource;
            if(fileImageSource != null)
                HubTile.Source = new BitmapImage(new Uri(fileImageSource.File, UriKind.RelativeOrAbsolute));

            System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(
                (byte)(Element.Color.A * 255),
                (byte)(Element.Color.R * 255),
                (byte)(Element.Color.G * 255),
                (byte)(Element.Color.B * 255));

            HubTile.Background = new SolidColorBrush(color);

            SetNativeControl(HubTile);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == CustomHubTileView.TitleProperty.PropertyName)
                HubTile.Title = Element.Title;

            if (e.PropertyName == CustomHubTileView.MessageProperty.PropertyName)
                HubTile.Message = Element.Message;
        }
    }
}
