//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELBancoPichincha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MOVEMENT
    {
        public int ID_MOVEMENT { get; set; }
        [Required]
        public int ID_ACCOUNT { get; set; }
        [Required]
        public Nullable<int> DATE { get; set; }
        [Required]
        public string TYPE { get; set; }
        [Required]
        public Nullable<decimal> VALUE { get; set; }
        public Nullable<decimal> BALANCE { get; set; }
        public Nullable<decimal> INITIAL_BALANCE { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}