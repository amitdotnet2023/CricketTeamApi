using Amit_CricketTeamDAL.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamDAL.Models
{
    public class CricketTeamMaster : AuditableEntity
    {

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public int? TotalMatchesPlayed { get; set; } // Optional

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? DateOfBirth { get; set; }

        public double? Height { get; set; } // Optional
        public double? Weight { get; set; } // Optional

        [Required]
        public string? Role { get; set; }
    }
}
