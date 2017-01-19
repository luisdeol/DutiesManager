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
                Frame?.Navigate(typeof(Details), duty);
            }
        }

        private async void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            const string title = "Create";
            const string content = "Voce tem certeza que quer descartar as mudanças no formulário?";
            var dialog = new MessageDialog(content, title);
            var yesCommand = new UICommand("Ok") { Id = 0 };
            var noCommand = new UICommand("Cancel") { Id=1 };
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;
            dialog.Commands.Add(yesCommand);
            dialog.Commands.Add(noCommand);
            var result = await dialog.ShowAsync();
            if (result == yesCommand)
                Frame?.Navigate(typeof(Main));
        }

        private async void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = LbMenu.SelectedIndex;
            var title = "Cancel";
            var description = "Your pending changes are going to be lost. Are you sure yo want to leave this page?";
            var cancelDialog = new MessageDialog(description, title);
            var yesCommand = new UICommand("Yes");
            var noCommand = new UICommand("No");
            cancelDialog.DefaultCommandIndex = 1;
            cancelDialog.CancelCommandIndex = 0;
            cancelDialog.Commands.Add(noCommand);
            cancelDialog.Commands.Add(yesCommand);
            var showDialog = await cancelDialog.ShowAsync();
            if (showDialog == yesCommand)
                if (index == 0)
                    Frame?.Navigate(typeof(Main));
                else
                    Frame?.Navigate(typeof(Main));
        }
    }
}
