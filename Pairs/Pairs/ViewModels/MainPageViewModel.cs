using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Pairs.Repositories;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Pairs.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private int guessedCount;
        private bool showGuess;
        private bool showPlay = true;

        public int GuessedCount
        {
            get => guessedCount;
            set => SetProperty(ref guessedCount, value);
        }

        public bool ShowGuess
        {
            get => showGuess;
            set => SetProperty(ref showGuess, value);
        }

        public bool ShowPlay
        {
            get => showPlay;
            set => SetProperty(ref showPlay, value);
        }

        public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();

        public ICommand GuessCommand { get; }

        public ICommand PlayCommand { get; }

        public MainPageViewModel()
        {
            GuessCommand = new Command(() => OnGuess());
            PlayCommand = new AsyncCommand(() => OnPlay(), allowsMultipleExecutions: false);
        }

        private void OnGuess()
        {
            GuessedCount++;
        }

        private async Task OnPlay()
        {
            ShowPlay = false;
            ShowGuess = true;

            var shapeRepository = new ShapeRepository();

            var allShapes = await shapeRepository.ListAsync();

            var random = new Random();

            const int gridSize = 8;
            var requiredShapeCount = gridSize / 2;

            var actualTiles = new List<TileViewModel>(gridSize);

            for (int i = 0; i < requiredShapeCount; i++)
            {
                var shapeIndex = random.Next(allShapes.Count);
                var shape = allShapes[shapeIndex];
                allShapes.RemoveAt(shapeIndex);

                actualTiles.Add(new TileViewModel(shape));
                actualTiles.Add(new TileViewModel(shape));
            }

            int n = actualTiles.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = actualTiles[k];
                actualTiles[k] = actualTiles[n];
                actualTiles[n] = value;
            }

            foreach (var tile in actualTiles)
            {
                Tiles.Add(tile);
            }
        }
    }
}
