namespace TPN_4_ProgramacionMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "TPN°4-ProgramacionMovil" };
        }
    }
}
