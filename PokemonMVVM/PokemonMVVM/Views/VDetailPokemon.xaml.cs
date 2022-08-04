using MvvmCross.Forms.Views;
using PokemonMVVM.Core.ViewModels;
using Xamarin.Forms.Xaml;
using MvvmCross.Binding.BindingContext;

namespace PokemonMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VDetailPokemon : MvxContentPage<VMDetailPokemon>
    {
        public VDetailPokemon()
        {
            InitializeComponent();
        }
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            var set = this.CreateBindingSet<VDetailPokemon, VMDetailPokemon>();
            set.Apply();
        }
    }
}