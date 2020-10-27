using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomProject.Models
{
    public partial class AspNetUserRoles
    {
        [Key]
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRoles.AspNetUserRoles))]
        public virtual AspNetRoles Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.AspNetUserRoles))]
        public virtual AspNetUsers User { get; set; }
    }
}
