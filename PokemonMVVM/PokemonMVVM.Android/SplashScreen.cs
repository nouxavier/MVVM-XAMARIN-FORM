using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace PokemonMVVM.Droid
{
    [Activity(
   
    MainLauncher = true,
    Icon = "@mipmap/icon",
    Theme = "@style/MainTheme.Splash",
    NoHistory = true,
    ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxFormsSplashScreenActivity<Setup, PokemonMVVM.Core.App, PokemonMVVM.App>
    {

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(RootActivity));
            return Task.CompletedTask;
        }
    }
}