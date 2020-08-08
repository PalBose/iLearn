using System.Collections.Generic;

namespace iLearnApi.Repository
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Skill> Skills { get; set; }
    }

    public class Skill
    {
        public int Id { get; set; }
        public Skills SkillName { get; set; }
        public Proficiency ProficiencyLevel { get; set; }
    }

    public enum Skills
    {
        AspNet,
        AspNetCore,
        iOS,
        Java,
        Sql
    }

    public enum Proficiency
    {
        Novice,
        Intermediate,
        Expert
    }
}