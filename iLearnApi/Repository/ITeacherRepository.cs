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
        Task<Teacher> UpdateTeachers(Teacher teacher);
        Task<Teacher> DeleteTeachers(Teacher teacher);
    }

}
