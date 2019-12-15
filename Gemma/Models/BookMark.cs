namespace Gemma
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookMark")]
    public partial class BookMark
    {

        [Key]
        [Column(Order = 0)]
        public string CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; } //關聯

        public virtual Product Product { get; set; }
    }
}
