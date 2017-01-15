using DutiesManager.Models;
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
            }
        }
        private void BHamburger_OnClick(object sender, RoutedEventArgs e)
        {
            Sv.IsPaneOpen = !Sv.IsPaneOpen;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = LbMenu.SelectedIndex;

            if (index == 0)
                Frame?.Navigate(typeof(Main));
            else
                Frame?.Navigate(typeof(Main));
        }
    }
}
