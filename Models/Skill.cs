using System.ComponentModel.DataAnnotations;

namespace Mahara.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        // 🔴 THIS WAS MISSING
        public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    }
}
