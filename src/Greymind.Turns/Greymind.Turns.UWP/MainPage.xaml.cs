namespace Greymind.Turns.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new Greymind.Turns.App());
        }
    }
}