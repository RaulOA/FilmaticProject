//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Filmatic.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public invoice()
        {
            this.invoice_deta = new HashSet<invoice_deta>();
        }
    
        public int id { get; set; }
        public string id_user { get; set; }
        public string id_payment_card { get; set; }
        public System.DateTime create_at { get; set; }
        public Nullable<decimal> total_amount { get; set; }
        public string status { get; set; }
    
        public virtual auth_users auth_users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice_deta> invoice_deta { get; set; }
        public virtual payment_cards payment_cards { get; set; }
    }
}
