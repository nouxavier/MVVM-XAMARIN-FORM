using MvvmCross.Forms.Views;
using PokemonMVVM.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using Xamarin.Forms.Xaml;

namespace PokemonMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VFilterTypePokemon : MvxContentPage<VMFilterTypePokemon>
    {
        public VFilterTypePokemon()
        {
            InitializeComponent();
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            var set = this.CreateBindingSet<VFilterTypePokemon, VMFilterTypePokemon>();
            set.Apply();

        }
    }
}