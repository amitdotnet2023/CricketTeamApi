using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamDAL.Contract
{
    public class BaseResponse
    {
        [Required]
        public bool Success { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
