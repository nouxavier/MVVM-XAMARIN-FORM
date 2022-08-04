using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
using System;

namespace PokemonInjection
{
    public static class InjectionMobile
    {
        public static void Start()
        {
            MvvmCross.Mvx.IoCProvider.RegisterType<IPokemonService, PokemonService>();
            MvvmCross.Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();
            MvvmCross.Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();

        }

    }
}
