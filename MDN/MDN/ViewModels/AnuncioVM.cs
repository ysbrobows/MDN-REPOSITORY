using MDN.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.ViewModels
{
    public class AnuncioVM
    {
        public T001_PRODUTO Produto { get; set; }
        public FileInfo[] Imagens { get; set ; }
        public string caminho { get; set; }
        public string telefone { get; set; }
    }
}
