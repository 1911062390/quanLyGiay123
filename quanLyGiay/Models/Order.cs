namespace quanLyGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Updated_At { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
