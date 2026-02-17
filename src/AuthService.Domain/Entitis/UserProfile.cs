using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Domain.Entities
{
    public class UserProfile
    {
        [Key]
        [Required]
        [MaxLength(16)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(16)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Url]
        [MaxLength(2048)]
        public string ProfilePictureUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public User? User { get; set; }
    }
}
/*
+--------------+--------------+------------------+---------------------+---------------------+  
| Id           | UserId       | ProfilePictureUrl| Bio                 | DateOfBirth         |
+--------------+--------------+------------------+---------------------+---------------------+
| 1            | 1            | http://example.com/profile.jpg | Software developer | 1990-01-01          |
+--------------+--------------+------------------+---------------------+---------------------+
*/