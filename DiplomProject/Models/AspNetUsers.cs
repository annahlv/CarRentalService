using DiplomProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomProject.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(5)]
        public string Lingua { get; set; }
        [StringLength(100)]
        public string Nickname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RecentEntrance { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RecentLogIn { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        [Required]
        public string Discriminator { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
    }
}
