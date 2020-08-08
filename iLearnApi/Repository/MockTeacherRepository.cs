using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLearnApi.Repository
{
 
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
        public async Task<Teacher> AddTeachers(Teacher teacher)
        {
            this.teachers.Add(teacher);
            await Task.Delay(0000);
            return teacher;
        }

        public async Task<Teacher> DeleteTeachers(Teacher teacher)
        {
            Teacher t = this.teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (t != null)
                this.teachers.Remove(t);
            await Task.Delay(0000);
            return teacher;
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

        public async Task<Teacher> UpdateTeachers(Teacher teacher)
        {
            Teacher t = this.teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (t != null)
            {
                t.FirstName = teacher.FirstName;
                t.LastName = teacher.LastName;
                t.Skills = teacher.Skills;
                t.Email = teacher.Email;
            }
            await Task.Delay(0000);
            return teacher;
        }
    }

}
