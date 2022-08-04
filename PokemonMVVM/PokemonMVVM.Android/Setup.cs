
using MvvmCross.Forms.Platforms.Android.Core;

namespace PokemonMVVM.Droid
{
    public class Setup : MvxFormsAndroidSetup<PokemonMVVM.Core.App, PokemonMVVM.App>
    {

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

        }
    }
}