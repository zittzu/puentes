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
    
    public partial class Priorizaciones
    {
        public int PriorizacionId { get; set; }
        public Nullable<int> EstructuraId { get; set; }
        public string Calificacion { get; set; }
        public string Pririzacion { get; set; }
        public string PriorizacionFinal { get; set; }
        public string Costo { get; set; }
        public string Transito { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Estructuras Estructuras { get; set; }
    }
}