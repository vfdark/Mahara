using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mahara.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Track { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
        public ICollection<ExchangeRequest> SentExchangeRequests { get; set; } = new List<ExchangeRequest>();
        public ICollection<ExchangeRequest> ReceivedExchangeRequests { get; set; } = new List<ExchangeRequest>();
    }
}
