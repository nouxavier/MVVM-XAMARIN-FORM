using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using PokemonMVVM.Core.ViewModels;

namespace PokemonMVVM.Views
{
    public partial class VTypePokemon : MvxContentPage<VMTypePokemon>
    {
        public VTypePokemon()
        {
            InitializeComponent();
        }
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            var set = this.CreateBindingSet<VTypePokemon, VMTypePokemon>();
            set.Apply();

        }
    }
}