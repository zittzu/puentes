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
    
    public partial class Estructuras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estructuras()
        {
            this.DatosAdministrativos = new HashSet<DatosAdministrativos>();
            this.DibujoCroquis = new HashSet<DibujoCroquis>();
            this.DTDetalles = new HashSet<DTDetalles>();
            this.DTGeometrias = new HashSet<DTGeometrias>();
            this.DTLosa = new HashSet<DTLosa>();
            this.DTMuros = new HashSet<DTMuros>();
            this.DTSubEstructuras = new HashSet<DTSubEstructuras>();
            this.DTSuperEstructuras = new HashSet<DTSuperEstructuras>();
            this.EstructuraDetalles = new HashSet<EstructuraDetalles>();
            this.Inspecciones = new HashSet<Inspecciones>();
            this.Miscelaneas = new HashSet<Miscelaneas>();
            this.Priorizaciones = new HashSet<Priorizaciones>();
            this.Tramos = new HashSet<Tramos>();
        }
    
        public int EstructuraId { get; set; }
        public Nullable<int> EstructuraTipoId { get; set; }
        public Nullable<int> NumeroRegistro { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> CarreteraId { get; set; }
        public Nullable<int> DepartamentoId { get; set; }
        public Nullable<int> MunicipioId { get; set; }
        public string PMS { get; set; }
        public string PKM { get; set; }
        public Nullable<int> AnioConstruccion { get; set; }
        public Nullable<int> CatalogoCarreteraId { get; set; }
        public Nullable<int> CatalogoRequisitoId { get; set; }
        public Nullable<System.DateTime> FechaRecoleccionDatos { get; set; }
        public Nullable<int> EstadoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosAdministrativos> DatosAdministrativos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DibujoCroquis> DibujoCroquis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTDetalles> DTDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTGeometrias> DTGeometrias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTLosa> DTLosa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTMuros> DTMuros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTSubEstructuras> DTSubEstructuras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTSuperEstructuras> DTSuperEstructuras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstructuraDetalles> EstructuraDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspecciones> Inspecciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miscelaneas> Miscelaneas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Priorizaciones> Priorizaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tramos> Tramos { get; set; }
    }
}
