using System;
using System.Threading.Tasks;

namespace PokemonDomain.Logs
{
    public interface ILog
    {
        Task InicializaLog();
        void AppAnalytics(string eventName, string viewModel = "", string detail = "", string domain = "");
        void AppCrash(Exception ex, string viewModel = "", string detalhes = "", string dominio = "");
    }
}
