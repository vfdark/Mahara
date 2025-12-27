using System;

namespace Mahara.Models
{
    public class ExchangeRequest
    {
        public int Id { get; set; }

        public string SenderUserId { get; set; } = string.Empty;
        public ApplicationUser Sender { get; set; } = null!;

        public string ReceiverUserId { get; set; } = string.Empty;
        public ApplicationUser Receiver { get; set; } = null!;

        public int SkillOfferedId { get; set; }
        public Skill SkillOffered { get; set; } = null!;

        public int SkillRequestedId { get; set; }
        public Skill SkillRequested { get; set; } = null!;

        public string Status { get; set; } = "Pending"; // Pending / Accepted / Rejected
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
