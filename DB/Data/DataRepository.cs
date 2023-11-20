using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentApp.Api.DB;
using StudentApp.Api.DB.Models;

namespace StudentApp.Api.DB.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly MainDbContext _context;

        public DataRepository(MainDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> list) where T : class
        {
            _context.RemoveRange(list);
        }

        public async Task<bool> Save()
        {
            var saved = 0;
            try
            {
                saved = await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return saved > 0 ? true : false;
        }

        public async Task<Student> GetById(long id)
        {
            var student = await _context.Student.Where(p => p.Id == id).FirstOrDefaultAsync();
            return student;
        }

       
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Student.ToListAsync();
            return students;
        }

    }
}