using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.ViewModels
{
    public class AnuncioGridVM
    {
        public int T001_ID_PRODUTO { get; set; }
        public string T001_TITULO { get; set; }
        public string T001_DESCRICAO { get; set; }
        public int T001_PRECO { get; set; }
        public DateTime T001_DT_CRIACAO { get; set; }
        public bool T001_ATIVO { get; set; }
        public int T003_ID_UF { get; set; }
        public int T002_ID_CATEGORIA { get; set; }
        public string UserName { get; set; }
        public string caminhoImagem { get; set; }
    }
}
