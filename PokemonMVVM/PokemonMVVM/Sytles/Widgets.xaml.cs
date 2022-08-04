using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonMVVM.Sytles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Widgets : ResourceDictionary
    {
        public Widgets()
        {
            InitializeComponent();
        }
    }
}