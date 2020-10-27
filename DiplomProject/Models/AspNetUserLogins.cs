using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomProject.Models
{
    public partial class AspNetUserLogins
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
        public string LoginProvider { get; set; }
        [Key]
        [Column(Order = 2)]
        [StringLength(128)]
        public string ProviderKey { get; set; }
        [Key]
        [Column(Order = 3)]
        public Guid UserId { get; set; }
        public string ProviderDisplayName { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUsers.AspNetUserLogins))]
        public virtual AspNetUsers User { get; set; }
    }
}
