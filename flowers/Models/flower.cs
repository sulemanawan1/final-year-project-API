//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace flowers.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class flower
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public flower()
        {
            this.planflowers = new HashSet<planflower>();
        }
    
        public string name { get; set; }
        public string color { get; set; }
        public Nullable<int> startmonth { get; set; }
        public Nullable<int> endmonth { get; set; }
        public string month { get; set; }
        public string season { get; set; }
        public Nullable<int> growtime { get; set; }
        public string height { get; set; }
        public Nullable<int> minheight { get; set; }
        public Nullable<int> maxheight { get; set; }
        public string category { get; set; }
        public string shape { get; set; }
        public string fragrance { get; set; }
        public Nullable<int> lifetime { get; set; }
        public string altitude { get; set; }
        public Nullable<int> minaltitude { get; set; }
        public Nullable<int> maxaltitude { get; set; }
        public string area { get; set; }
        public string watering { get; set; }
        public string sunlight { get; set; }
        public string pesticide { get; set; }
        public string disease { get; set; }
        public string soiltype { get; set; }
        public string fertilizer { get; set; }
        public int id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planflower> planflowers { get; set; }
    }
}
