//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace puentes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DTSubEstructuras
    {
        public int DTSubEstrucId { get; set; }
        public Nullable<int> EstructuraId { get; set; }
        public Nullable<int> SubEstrucTipoId { get; set; }
        public Nullable<int> MaterialId { get; set; }
        public Nullable<int> TipoCimentacionId { get; set; }
        public Nullable<int> SubEstrucClasificacionId { get; set; }
    
        public virtual Estructuras Estructuras { get; set; }
    }
}