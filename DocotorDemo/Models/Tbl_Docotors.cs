//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocotorDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Docotors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Docotors()
        {
            this.Tbl_Patients = new HashSet<Tbl_Patients>();
            this.Tbl_Shedular = new HashSet<Tbl_Shedular>();
        }
    
        public string ID { get; set; }
        public string DoctorName { get; set; }
        public string Specialist { get; set; }
        public string DrDescription { get; set; }
        public string DrImage { get; set; }
        public string ItemID { get; set; }
    
        public virtual Tbl_Item Tbl_Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Patients> Tbl_Patients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Shedular> Tbl_Shedular { get; set; }
    }
}
