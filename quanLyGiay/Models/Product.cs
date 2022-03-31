namespace quanLyGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Id { get; set; }

        public int CatId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Detail { get; set; }

        public string Img { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public DateTime? Create_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public int Status { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
