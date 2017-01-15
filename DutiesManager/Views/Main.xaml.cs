using DutiesManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DutiesManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
        public Main()
        {
            this.InitializeComponent();
        }

        private async void SvContent_OnLoaded(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:51994/api/duties";
            Uri uri = new Uri(url);
            var response = await client.GetStringAsync(uri);
            List<Duty> duties = JsonConvert.DeserializeObject<List<Duty>>(response);
            foreach (Duty duty in duties)
            {
                ListBoxItem item = new ListBoxItem
                {
                    Content = duty.DutyTitle,
                    Tag = duty.DutyId
                };
                LbDuties.Items?.Add(item);
            }
        }

        private void BHamburger_OnClick(object sender, RoutedEventArgs e)
        {
            Sv.IsPaneOpen = !Sv.IsPaneOpen;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(typeof(CreateDuty), new { id = 4 });
        }

        private async void LbDuties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dutyId = ((ListBoxItem) LbDuties.SelectedItem).Tag.ToString();
            HttpClient client = new HttpClient();
            string url = "http://localhost:51994/api/duties/"+ dutyId;
            Uri uri = new Uri(url);
            var response = await client.GetStringAsync(uri);
            Duty duty = JsonConvert.DeserializeObject<Duty>(response);

            Frame?.Navigate(typeof(Details), duty);
        }
    }
}
