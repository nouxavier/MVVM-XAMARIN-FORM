using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PokemonDomain;
using PokemonDomain.Model;
using PokemonMVVM.Core.Model;
using PokemonMVVM.Core.ViewModelResult;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.Core.ViewModels
{
    public class VMFilterTypePokemon: BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;
        private readonly IRestClient _restClient;
        private string _nextPage;
        public VMFilterTypePokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _restClient = restClient;
            ClosePageCommand = new MvxAsyncCommand(ClosePage);
            PokemonsTypes = new MvxObservableCollection<PokemonGeneration>();
            PokemonTypeSelectedCommand = new MvxAsyncCommand<PokemonGeneration>(PokemonTypeSelected);

        }

        private async Task PokemonTypeSelected(PokemonGeneration arg)
        {
            var result = await _pokemonService.GetPokemonTypeIdAsync(_restClient, arg.Url.ToString());
            
            List<PokemonGeneration> listPokemon = new List<PokemonGeneration>();
            foreach(var pokemonGeneration in result.Pokemon)
            {
                
                listPokemon.Add(pokemonGeneration.PokemonGeneration);
            }
            PagedResult<PokemonGeneration> resultPage = new PagedResult<PokemonGeneration>();
            resultPage.Next = null;
            resultPage.Results = listPokemon;
            resultPage.IsFilterType = true;
            resultPage.TypeFilter = arg.Name;
            await _navigationService.Navigate<VMTypePokemon, PagedResult<PokemonGeneration>, EntityVMResult<PagedResult<PokemonGeneration>>>(resultPage);
            await _navigationService.Close(this);
        }
     
        private async Task ClosePage()
        {
            await _navigationService.Close(this);
        }
        private async Task LoadTypePokemon()
        {
            var result = await _pokemonService.GetPokemonTypeAsync(_restClient, _nextPage);

            if (string.IsNullOrEmpty(_nextPage))
            {
                PokemonsTypes.Clear();
                PokemonsTypes.AddRange(result.Results);
            }
            else
            {
                PokemonsTypes.AddRange(result.Results);
            }

            _nextPage = result.Next;
        }

        public MvxNotifyTask LoadPokemonTypeTask { get; private set; }
        private MvxObservableCollection<PokemonGeneration> _pokemonsTypes;
        public MvxObservableCollection<PokemonGeneration> PokemonsTypes
        {
            get
            {
                return _pokemonsTypes;
            }
            set
            {
                _pokemonsTypes = value;
                RaisePropertyChanged(() => PokemonsTypes);
            }
        }

        public IMvxCommand ClosePageCommand { get; private set; }
        public IMvxCommand<PokemonGeneration> PokemonTypeSelectedCommand { get; private set; }

        public override Task Initialize()
        {
            LoadPokemonTypeTask = MvxNotifyTask.Create(LoadTypePokemon);

            return Task.FromResult(0);
        }
    }
}
