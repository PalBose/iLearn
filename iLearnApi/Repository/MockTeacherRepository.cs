using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLearnApi.Repository
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task<List<Teacher>> AddTeachers(Teacher teacher);
    }

    public class MockTeacherRepository : ITeacherRepository
    {
        private readonly List<Teacher> teachers;

        public MockTeacherRepository()
        {
            teachers = new List<Teacher>()
            {
                new Teacher(){ Id=1,Email="a@b.c",FirstName="f1",LastName="l1", Skills= new List<Skill>(){ new Skill {ProficiencyLevel= Proficiency.Expert.ToString(),SkillName=Skills.AspNet.ToString()} , new Skill { ProficiencyLevel = Proficiency.Expert.ToString(), SkillName = Skills.Java.ToString() } } },
                new Teacher(){ Id=2,Email="a1@b.c",FirstName="f2",LastName="l2", Skills= new List<Skill>(){ new Skill {ProficiencyLevel= Proficiency.Expert.ToString(),SkillName=Skills.Java.ToString()} } },
            };
        }
        public async Task<List<Teacher>> AddTeachers(Teacher teacher)
        {
            this.teachers.Add(teacher);
            await Task.Delay(0000);
            return this.teachers;
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            await Task.Delay(0000);
            return this.teachers.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            await Task.Delay(0000);
            return this.teachers;
        }
    }

}
