namespace FreelancePlatform.Core.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
    }
}
