using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PokemonMVVM.Core._Util;

namespace PokemonMVVM.Droid.Services
{
    public class LogApp : ILogApp
    {
        void ILogApp.AppAnalytics(string eventoNome, string viewModel, string detail, string domain)
        {
            try
            {
                Dictionary<string, string> properties = null;
                properties = new Dictionary<string, string>
                    {
                        { "Tela", viewModel ?? "" },
                        { "Detalhes", detail ?? ""},
                        { "Dominio", domain ?? ""}
                    };

                Analytics.TrackEvent(eventoNome, properties);
            }
            catch { /*dummy - APP CENTER NUNCA PODE PARAR A APP MESMO SE ERRO*/ }
        }

        void ILogApp.AppCrash(Exception ex, string viewModel, string detail, string domain)
        {
            try
            {
                Dictionary<string, string> properties = null;
                properties = new Dictionary<string, string>
                    {

                        { "Screen", viewModel ?? "" },
                        { "Detail", detail ?? ""},
                        { "Domain", domain ?? ""}
                    };

                Crashes.TrackError(ex, properties);
            }
            catch { /*dummy - APP CENTER NUNCA PODE PARAR A APP MESMO SE ERRO*/ }

        }

        async Task ILogApp.InicializaLog()
        {
            AppCenter.Start("codigo app center", typeof(Analytics), typeof(Crashes));
            await Crashes.IsEnabledAsync();
        }
    }
}