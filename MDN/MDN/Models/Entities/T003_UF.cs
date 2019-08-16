using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MDN.Models.Entities
{
    public class T003_UF
    {
        public T003_UF()
        {
            T001_PRODUTO = new HashSet<T001_PRODUTO>();
        }

        [Key]
        public int T003_ID_UF { get; set; }
        public string T003_NO_UF { get; set; }


        [InverseProperty("T003_UFNavigation")]
        public virtual ICollection<T001_PRODUTO> T001_PRODUTO { get; set; }
    }
}
