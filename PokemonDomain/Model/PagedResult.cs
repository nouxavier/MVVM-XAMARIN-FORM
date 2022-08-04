using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonMVVM.Core.Model
{
    public class PagedResult<T> where T : class
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }
        public string TypeFilter { get; set; }
        public bool IsFilterType { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
