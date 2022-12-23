using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AView = Android.Views.View;

namespace ScrollNFocus
{
    public class BlaPage : ContentPage
    {
        public BlaPage()
        {
            DataTemplate b = new(() =>
            {
                Border border = new()
                {
                    Padding = new(12, 8),
                    Content = new Entry
                    {
                        HeightRequest = 40,
                        
                    }
                };

                border.Content.SetBinding(Entry.TextProperty, ".");

                return border;
            });

            List<string> g = new()
            {
                "q",
                "d",
                "b",
                "z",
                //"t",
                //"n",
                //"f",
                //"q",
                //"d",
                //"b",
                //"z",
                //"t",
                //"n",
                //"f"
            };

            VerticalStackLayout vsl = new()
            {
                Padding = new(4,16)
            };

            BindableLayout.SetItemsSource(vsl, g);
            BindableLayout.SetItemTemplate(vsl, b);


            //ScrollView sv = new()
            //{
            //    Content = vsl
            //};

            //Content = sv;

            Content = vsl;
        }
    }
}