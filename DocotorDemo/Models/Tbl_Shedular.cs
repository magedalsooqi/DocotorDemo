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
    
    public partial class Tbl_Shedular
    {
        public string ID { get; set; }
        public string ShedularDate { get; set; }
        public string ShedularTime { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
    
        public virtual Tbl_Docotors Tbl_Docotors { get; set; }
        public virtual Tbl_Patients Tbl_Patients { get; set; }
    }
}
