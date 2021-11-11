using System.Windows.Input;
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

        public ICommand GuessCommand { get; }

        public ICommand PlayCommand { get; }

        public MainPageViewModel()
        {
            GuessCommand = new Command(() => OnGuess());
            PlayCommand = new Command(() => OnPlay());
        }

        private void OnGuess()
        {
            GuessedCount++;
        }

        private void OnPlay()
        {
            ShowPlay = false;
            ShowGuess = true;
        }
    }
}
