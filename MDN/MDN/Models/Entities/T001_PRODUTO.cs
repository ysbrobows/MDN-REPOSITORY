using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.Models.Entities
{
    public class T001_PRODUTO
    {
        [Key]
        public int T001_ID_PRODUTO { get; set; }
        public string T001_TITULO { get; set; }
        public string T001_DESCRICAO { get; set; }
        public decimal T001_PRECO { get; set; }
        public string T001_FOTO { get; set; }


        [ForeignKey("T003_ID_UF")]
        [InverseProperty("T001_PRODUTO")]
        public virtual T003_UF T003_UFNavigation { get; set; }

        [ForeignKey("T002_ID_CATEGORIA")]
        [InverseProperty("T001_PRODUTO")]
        public virtual T002_CATEGORIA T002_CATEGORIANavigation { get; set; }
    }
}
