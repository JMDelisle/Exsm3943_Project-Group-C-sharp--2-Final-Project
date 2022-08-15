﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassroomStart.Models
{
    [Table("products")]
    [Index("ProductCategoryId", Name = "Product Category ID")]
    public partial class Product
    {
        public Product()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Product Category ID", TypeName = "int(11)")]
        public int ProductCategoryId { get; set; }
        [Column("Product Name")]
        [StringLength(30)]
        public string ProductName { get; set; } = null!;
        [Column("Quantity On Hand", TypeName = "int(11)")]
        public int QuantityOnHand { get; set; }
        [Column(TypeName = "int(11)")]
        public int Minimum { get; set; }
        [Column(TypeName = "int(11)")]
        public int Cost { get; set; }
        [Column("Sale Price", TypeName = "int(11)")]
        public int SalePrice { get; set; }

        [ForeignKey("ProductCategoryId")]
        [InverseProperty("Products")]
        public virtual ProductCategory ProductCategory { get; set; } = null!;
        [InverseProperty("ProductName")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
