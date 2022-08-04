using MvvmCross.IoC;
using MvvmCross.ViewModels;
using PokemonInjection;

namespace PokemonMVVM.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            InjectionMobile.Start();


            CreatableTypes().EndingWith("Services").AsInterfaces().RegisterAsLazySingleton();
            RegisterCustomAppStart<AppStart>();
            base.Initialize();
        }
    }
}
