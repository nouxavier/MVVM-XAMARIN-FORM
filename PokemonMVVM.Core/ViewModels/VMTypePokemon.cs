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
using System.Linq;
using System.Threading.Tasks;

namespace PokemonMVVM.Core.ViewModels
{

    public class VMTypePokemon : BaseViewModel<PagedResult<PokemonGeneration>, EntityVMResult<PagedResult<PokemonGeneration>>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;
        private readonly IRestClient _restClient;
        private string _nextPage;
        private bool _IsVisibleAllPokemon;
        public VMTypePokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _restClient = restClient;
            FilterTypeCommand = new MvxCommand(FilterPokemon);
            AllFilterTypeCommand = new MvxCommand(AllPokemmon);
            Pokemons =  new MvxObservableCollection<PokemonGeneration>();
            PokemonSelectedCommand = new MvxAsyncCommand<PokemonGeneration>(PokemonSelected);
            FetchPokemonCommand = new MvxCommand(
               () =>
               {
                   if (!string.IsNullOrEmpty(_nextPage))
                   {
                       FetchPokemonTask = MvxNotifyTask.Create(LoadPokemon);
                       RaisePropertyChanged(() => FetchPokemonTask);
                   }
               });
            RefreshPokemonCommand = new MvxCommand(RefreshPokemon);
            _IsVisibleAllPokemon = true;
        }

        private void AllPokemmon()
        {
            _IsVisibleAllPokemon = true;
            SetTitleAll();
            LoadPokemonTask = MvxNotifyTask.Create(LoadPokemon);
            RaisePropertyChanged(() => LoadPokemonTask);
        }

        private void FilterPokemon()
        {
             _navigationService.Navigate<VMFilterTypePokemon>();
        }
        private void SetTitleAll()
        {
            NameFilter ="NAME OF ALL POKÉMON";
        }
        private async Task LoadPokemon()
        {
            if(_IsVisibleAllPokemon)
            {
                var result = await _pokemonService.GetPokemonAsync(_restClient, _nextPage);

                if (string.IsNullOrEmpty(_nextPage))
                {
                    Pokemons.Clear();
                    Pokemons.AddRange(result.Results);
                }
                else
                {
                    Pokemons.AddRange(result.Results);
                }

                _nextPage = result.Next;
                SetTitleAll();
            }
            
        }

        private async Task PokemonSelected(PokemonGeneration selectedPokemon)
        {
            await _navigationService.Navigate<VMDetailPokemon, PokemonGeneration, EntityVMResult<PokemonGeneration>>(selectedPokemon);
        }

        public MvxNotifyTask LoadPokemonTask { get; private set; }
        public MvxNotifyTask FetchPokemonTask { get; private set; }

        private MvxObservableCollection<PokemonGeneration> _pokemons;
        public MvxObservableCollection<PokemonGeneration> Pokemons
        {
            get
            {
                return _pokemons;
            }
            set
            {
                _pokemons = value;
                RaisePropertyChanged(() => Pokemons);
            }
        }
        private string _nameFilter;
        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                _nameFilter = value;
                RaisePropertyChanged(() => NameFilter);
            }
        }
        public IMvxCommand FilterTypeCommand { get; private set; }
        public IMvxCommand AllFilterTypeCommand { get; private set; }
        
        public IMvxCommand<PokemonGeneration> PokemonSelectedCommand { get; private set; }

        public IMvxCommand FetchPokemonCommand { get; private set; }

        public IMvxCommand RefreshPokemonCommand { get; private set; }

        private void RefreshPokemon()
        {
            if(_IsVisibleAllPokemon)
            {
                _nextPage = null;

                LoadPokemonTask = MvxNotifyTask.Create(LoadPokemon);
                RaisePropertyChanged(() => LoadPokemonTask);
            }
           
        }

        public override Task Initialize()
        {
            LoadPokemonTask = MvxNotifyTask.Create(LoadPokemon);
            return Task.FromResult(0);
        }



        public override void Prepare(PagedResult<PokemonGeneration> parameter)
        {
            if (string.IsNullOrEmpty(_nextPage))
            {
                Pokemons.Clear();
                Pokemons.AddRange(parameter.Results);
            }
            else
            {
                Pokemons.AddRange(parameter.Results);
            }

            _nextPage = parameter.Next;
            _IsVisibleAllPokemon = !parameter.IsFilterType;
            NameFilter ="NAME OF ALL " + parameter.TypeFilter.ToUpper() + " TYPE POKÉMON";

        }
    }

}
