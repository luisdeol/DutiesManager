using DutiesManager.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DutiesManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateDuty : Page
    {
        public CreateDuty()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:51994/api/duties";
            Uri uri = new Uri(url);
            if (CalendarDatePicker.Date != null)
            {
                Duty duty = new Duty
                {
                    CreatedAt = DateTime.Now,
                    Description = DescriptionTextBox.Text,
                    DueTime = TimePicker.Time.ToString(),
                    DueDate = CalendarDatePicker.Date.Value.DateTime,
                    UserId = 2,
                    DutyTitle = TitleTextBox.Text
                };
                DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Duty));
                MemoryStream ms = new MemoryStream();
                jsonSer.WriteObject(ms, duty);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                StringContent content = new StringContent(sr.ReadToEnd(),
                                                            System.Text.Encoding.UTF8,
                                                            "application/json");
                var response = await client.PostAsync(uri.ToString(), content);
                MessageDialog confirmationDialog = new MessageDialog("Duty created!");
                await confirmationDialog.ShowAsync();
                Frame?.Navigate(typeof(Main));
            }
        }

        private void BHamburger_OnClick(object sender, RoutedEventArgs e)
        {
            Sv.IsPaneOpen = !Sv.IsPaneOpen;
        }
    }
}
