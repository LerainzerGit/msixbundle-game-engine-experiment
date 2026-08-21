using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using MonoGame.Framework;

namespace GameEngine
{
    sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var factory = new MonoGameGameFactory<Game1>();
            MonoGame.Framework.WindowsUniversal.MonoGamePlatform.Run(factory);
        }
    }

    internal class MonoGameGameFactory<T> where T : Microsoft.Xna.Framework.Game, new()
    {
        public T Create() => new T();
    }
}
