using Windows.ApplicationModel.Core;

namespace GameEngine
{
    // Entry point for a MonoGame UWP app with no XAML — CoreApplication.Run
    // hosts Game1 directly as the app's single view. This replaces the old
    // App.xaml / App.xaml.cs bootstrap entirely.
    internal static class Program
    {
        [System.MTAThreadAttribute]
        static void Main(string[] args)
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<Game1>();
            CoreApplication.Run(factory);
        }
    }
}
