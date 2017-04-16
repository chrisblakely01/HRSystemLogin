namespace Model.Domain
{
    using Model.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        //[Required]
        [MaxLength(30)]
        public string Username { get; set; }

        //[Required]
        public string Password { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string LastName { get; set; }

        public string SecurityQuestion { get; set; }

        [MaxLength(200)]
        public string SecurityAnswer { get; set; }

        public int LoginAttempts { get; set; }

        public bool IsActive { get; set; }
        
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
