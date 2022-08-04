using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using OxyPlot.Xamarin.Forms.Platform.Android;
using System.Globalization;
using System.Threading;


namespace PokemonMVVM.Droid
{
    [Activity(Label = "PokemonMVVM",
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme",
        LaunchMode = LaunchMode.SingleTask,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class RootActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {


            base.OnCreate(bundle);

            PlotViewRenderer.Init();
            var userSelectedCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = userSelectedCulture;


        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}