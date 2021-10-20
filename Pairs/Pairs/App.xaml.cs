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

        protected async override void OnStart()
        {
            IShapeRepository shapeRepository = new ShapeRepository();

            var shapes = await shapeRepository.ListAsync();

            await MainPage.DisplayAlert(
                $"Loaded {shapes.Count} shapes",
                shapes.First().Path,
                "OK");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
