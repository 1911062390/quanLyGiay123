namespace quanLyGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orderdetail
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? UserId { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public int Tong { get; set; }

        public int? Status { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
