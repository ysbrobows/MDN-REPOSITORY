using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.ViewModels
{
    public class AnuncioVM
    {
        public int T001_ID_PRODUTO { get; set; }
        public string T001_TITULO { get; set; }
        public string T001_DESCRICAO { get; set; }
        public decimal T001_PRECO { get; set; }
        public string T001_FOTO { get; set; }
        public int T002_ID_CATEGORIA { get; set; }
        public int T003_ID_UF { get; set; }
    }
}
