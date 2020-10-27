using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DiplomProject.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("OrderState")]
        public int StateId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderPlaced { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderApproved { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartRent { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndRent { get; set; }
        public Car Car { get; set; }
        public ApplicationUser User { get; set; }
        public virtual OrderState State { get; set; }
    }
}
