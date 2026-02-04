using System.Threading.Tasks;

namespace Mobiilerakendus
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;
            CounterLabel.Text = "Nupp oli vajutatud";
            DotNetBot.Rotation += 90;
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                if (count >=5)
            {
                CounterBtn.BackgroundColor = Colors.Red;
                CounterBtn.TextColor = Colors.White;
            }
            CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            var rnd = new Random();
            var color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            ResetBtn.BackgroundColor = color;
            this.BackgroundColor = color;
            if (count % 10 == 0)
                DotNetBot.IsVisible = false;
            else
                DotNetBot.IsVisible = true;
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = "Vajuta siia";
            CounterLabel.Text = "Alustame uuesti!";
            DotNetBot.Rotation = 0;
            DotNetBot.IsVisible = true;
            ResetBtn.ClearValue(BackgroundColorProperty);
            CounterBtn.ClearValue(BackgroundColorProperty);
            CounterBtn.ClearValue(Button.TextColorProperty);
            BackgroundColor = Colors.White;
            if (DotNetBot.HorizontalOptions == LayoutOptions.Start)
            {
                DotNetBot.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                DotNetBot.HorizontalOptions = LayoutOptions.Start;
            }
        }

        //private void Upbtn_Clicked(object sender, EventArgs e)
        //{
        //    pilt.VerticalOptions == LayoutOptions.Start;
        //}

        //private void Downbtn_Clicked(object sender, EventArgs e)
        //{
        //    pilt.VerticalOptions == LayoutOptions.End;
        //}

        private async void Upbtn_Clicked(object sender, EventArgs e)
        {
            await pilt.TranslateToAsync(0, -75, 250);
        }

        private async void Downbtn_Clicked(object sender, EventArgs e)
        {
            await pilt.TranslateToAsync(0, 0, 250);
        }

        private void Opacity_Clicked(object sender, EventArgs e)
        {
            pilt.Opacity -=0.2;
        }

        private void Scale_Clicked(object sender, EventArgs e)
        {
            pilt.Scale += 0.3;
        }

        private void Cornerrad_Clicked(object sender, EventArgs e)
        {
            Opacity.CornerRadius = 40;
            Scale.CornerRadius = 60;
            Cornerrad.CornerRadius = 100;
        }
    }
}
