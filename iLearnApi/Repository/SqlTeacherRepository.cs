using iLearnApi.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLearnApi.Repository
{
    public class SqlTeacherRepository : ITeacherRepository
    {
        public AppDbContext Context { get; }
        public SqlTeacherRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Teacher> AddTeachers(Teacher teacher)
        {
            var t = await Context.Teachers.AddAsync(teacher);
            await Context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteTeachers(Teacher teacher)
        {
            var t = await Context.Teachers.FindAsync(teacher.Id);
            if (t != null)
            {
                Context.Teachers.Remove(t);
                await Context.SaveChangesAsync();
            }
            return t;
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            var t = await Context.Teachers.FindAsync(id);
            return t;

        }

        public async Task<List<Teacher>> GetTeachers()
        {
            var teachers = await Task.FromResult(Context.Teachers);
            return teachers.ToList();
        }

        public async Task<Teacher> UpdateTeachers(Teacher teacher)
        {
            var t = await Context.Teachers.FindAsync(teacher.Id);
            if (t != null)
            {
                Context.Teachers.Attach(t);
                await Context.SaveChangesAsync();
            }
            return t;
        }
    }
}
