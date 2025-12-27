using System;

namespace Mahara.Models
{
    public class ExchangeRequest
    {
        public int Id { get; set; }

        public string SenderUserId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string ReceiverUserId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public int SkillOfferedId { get; set; }
        public Skill SkillOffered { get; set; }

        public int SkillRequestedId { get; set; }
        public Skill SkillRequested { get; set; }

        public string Status { get; set; } = "Pending"; // Pending / Accepted / Rejected
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
