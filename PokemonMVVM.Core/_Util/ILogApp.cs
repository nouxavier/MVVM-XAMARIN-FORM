using System;
using System.Threading.Tasks;

namespace PokemonMVVM.Core._Util
{
    public interface ILogApp
    {
        Task InicializaLog();
        void AppAnalytics(string eventName, string viewModel = "", string detail = "", string domain = "");
        void AppCrash(Exception ex, string viewModel = "", string detalhes = "", string dominio = "");
    }
}
