using System.Collections.Generic;
using System.Threading.Tasks;
using StudentApp.Api.DB.Models;

namespace StudentApp.Api.DB.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(IEnumerable<T> list) where T : class;    
        Task<bool> Save();
        Task<Student> GetById(long id);

        Task<IEnumerable<Student>> GetStudents();  
    }
}