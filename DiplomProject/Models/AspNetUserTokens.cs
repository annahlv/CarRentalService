using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomProject.Models
{
    public partial class AspNetUserTokens
    {
        [Key]
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string LoginProvider { get; set; }
        [Key]
        [Column(Order = 3)]
        public string Name { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.AspNetUserTokens))]
        public virtual AspNetUsers User { get; set; }
    }
}
