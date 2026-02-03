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
        }
    }
}
