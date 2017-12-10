using Xamarin.Forms;

namespace ExerciseApp
{
    public partial class QuotesPage : ContentPage
    {
        private int index = 0;

        private string[] quotes = new string[]
        {
            "Quote 1",
            "Quote 2",
            "Quote 3",
            "Quote 4",
            "Quote 5"
        };

        public QuotesPage()
        {
            InitializeComponent();
            
            //// Alternative to using XAML
            //switch (Device.RuntimePlatform)
            //{
            //    case Device.Android:
            //        Padding = new Thickness(20, 30, 20, 30);
            //        break;
            //    case Device.WinPhone:
            //        Padding = new Thickness(20, 40, 20, 20);
            //        break;
            //}
            
            slider.Value = 20;
            quote.Text = quotes[index];
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            index++;
            if (index >= quotes.Length)
            {
                index = 0;
            }

            quote.Text = quotes[index];
        }
    }
}