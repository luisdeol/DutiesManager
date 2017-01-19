using DutiesManager.Models;
using System;
using System.Net.Http;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DutiesManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Details : Page
    {
        public Details()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var duty = (Duty)e.Parameter;
            if (duty != null)
            {
                TitleValue.Text = duty.DutyTitle;
                DescriptionValue.Text = duty.Description;
                DueDateValue.Text = duty.DueTime;
                DueTimeValue.Text = duty.DueTime;
                Check.Tag = duty.DutyId;
            }
        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = LbMenu.SelectedIndex;

            if (index == 0)
                Frame?.Navigate(typeof(Main));
            else
                Frame?.Navigate(typeof(Main));
        }

        private async void Check_OnClick(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:51994/api/duties/";
            string deleteUri = String.Format(url + "{0}", Check.Tag.ToString());
            Uri uri = new Uri(deleteUri);

            MessageDialog dialog = new MessageDialog(
                "Are you sure that you want to check that as solved? It is going to be deleted!",
                "Check Task as solved"
                );
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;
            dialog.Commands.Add(new UICommand("Yes") { Id = 0});
            dialog.Commands.Add(new UICommand("No") { Id = 1 });

            var result = await dialog.ShowAsync();
            if (result == dialog.Commands[0])
            {
                var deleteResponse = await client.DeleteAsync(deleteUri);
                var deleteSuccessDialog = new MessageDialog(String.Format("The Task {0} was removed!", TitleValue.Text));
                await deleteSuccessDialog.ShowAsync();
            }
            Frame?.Navigate(typeof(Main));
        }
    }
}
