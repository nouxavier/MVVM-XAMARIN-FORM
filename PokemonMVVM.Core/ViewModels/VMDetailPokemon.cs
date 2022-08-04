using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PokemonDomain.Model;
using PokemonDomain.Model.Detail;
using PokemonDomain.Model.Pokemons.Type;
using PokemonMVVM.Core.ViewModelResult;
using PokemonServiceContext.Rest;
using PokemonServiceContext.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.Core.ViewModels
{
    public class VMDetailPokemon : BaseViewModel<PokemonGeneration, EntityVMResult<PokemonGeneration>>
    {

        private readonly IMvxNavigationService _navigationService;
        private readonly IPokemonService _pokemonService;
        private readonly IRestClient _restClient;
        private Uri _url;
        public VMDetailPokemon(IMvxNavigationService navigationService, IPokemonService pokemonService, IRestClient restClient)
        {
            _navigationService = navigationService;
            _pokemonService = pokemonService;
            _restClient = restClient;
            PokemonsTypes = new MvxObservableCollection<PokemonGeneration>();

        }

        private PokemonDetail _detailPokemon;
        public PokemonDetail DetailPokemon
        {
            get => _detailPokemon;
            set
            {
                _detailPokemon = value;
                RaisePropertyChanged(() => DetailPokemon);
            }
        }
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

        private string _urlImage;
        public string UrlImage
        {
            get => _urlImage;
            set
            {
                _urlImage = value;
                RaisePropertyChanged(() => UrlImage);
            }
        }
        public MvxNotifyTask LoadDetailPokemonTask { get; private set; }
        public override Task Initialize()
        {
            LoadDetailPokemonTask = MvxNotifyTask.Create(LoadDetailPokemon);
            return Task.FromResult(0);
        }

        private async Task LoadDetailPokemon()
        {
            var result = await _pokemonService.GetPokemonDetailAsync(_restClient, _url.ToString());
            DetailPokemon = result;
            PokemonsTypes.Clear();
            foreach (var type in result.Types)
            {
                PokemonsTypes.Add(type.PokemonGeneration);
            }

        }

        public override void Prepare(PokemonGeneration parameter)
        {
            _url = parameter.Url;
            _urlImage = parameter.UrlImage;
        }
    }
}
