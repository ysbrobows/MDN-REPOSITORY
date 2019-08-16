using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.Models.Entities
{
    public class T002_CATEGORIA
    {
        public T002_CATEGORIA()
        {
            T001_PRODUTO = new HashSet<T001_PRODUTO>();
        }

        [Key]
        public int T002_ID_CATEGORIA { get; set; }
        public string T002_NO_CATEGORIA { get; set; }

        [InverseProperty("T002_CATEGORIANavigation")]
        public virtual ICollection<T001_PRODUTO> T001_PRODUTO { get; set; }
    }
}
