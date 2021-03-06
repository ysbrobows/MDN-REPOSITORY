﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDN.Models.Entities
{
    public class T001_PRODUTO
    {
        [Key]
        public int T001_ID_PRODUTO { get; set; }
        public string T001_TITULO { get; set; }
        public string T001_DESCRICAO { get; set; }
        public int T001_PRECO { get; set; }
        public DateTime T001_DT_CRIACAO { get; set; }
        public bool T001_ATIVO { get; set; }
        public int T003_ID_UF { get; set; }
        public int T002_ID_CATEGORIA { get; set; }

        public string User_Id { get; set; }

        //[ForeignKey("Id")]
        //[InverseProperty("T001_PRODUTO")]
        //public virtual T003_UF T003_UFNavigation { get; set; }

        [ForeignKey("T003_ID_UF")]
        [InverseProperty("T001_PRODUTO")]
        public virtual T003_UF T003_UFNavigation { get; set; }

        [ForeignKey("T002_ID_CATEGORIA")]
        [InverseProperty("T001_PRODUTO")]
        public virtual T002_CATEGORIA T002_CATEGORIANavigation { get; set; }
    }
}
