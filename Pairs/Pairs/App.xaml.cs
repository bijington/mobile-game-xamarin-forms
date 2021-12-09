using System.Linq;
using Pairs.Repositories;
using Xamarin.Forms;

namespace Pairs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
