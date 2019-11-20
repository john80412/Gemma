namespace Gemma
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        [Key]
        [Column(Order = 0)]
        public string CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ColorID { get; set; }

        public int Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SizeID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Color Color { get; set; }

        public virtual Product Product { get; set; }

        public virtual Size Size { get; set; }
    }
}
