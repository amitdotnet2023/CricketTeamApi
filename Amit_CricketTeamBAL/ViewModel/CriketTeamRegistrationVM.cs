using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamBAL.ViewModel
{
    public class CriketTeamRegistrationVM
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
        public string? DateOfBirth { get; set; }
        public double? Height { get; set; } // Optional
        public double? Weight { get; set; } // Optional

        [Required]
        public string? Role { get; set; }
    }
}
