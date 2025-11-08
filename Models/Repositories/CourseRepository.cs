using _25._10.Domain;
using _25._10.Interfaces;
using _25._10.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Models.Repositories
{
    public class CourseRepository : IRepository<Course>
    {

        public void Add(Course course)
        {
            try
            {
                using var context = new MyDatabaseContext();
                context.Add(course);
                context.SaveChanges();
            }
            catch { }
        }

        public void Update(int id, Course course)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var _courseInDb = context.Course.FirstOrDefault(x => x.CourseId == id);
                if (_courseInDb != null)
                {
                    _courseInDb.CourseTitle = course.CourseTitle;
                    _courseInDb.CourseDescription = course.CourseDescription;
                    context.Update(_courseInDb);
                }
                context.SaveChanges();
            }
            catch { }
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var course = context.Course.FirstOrDefault(x => x.CourseId == id);
                if (course != null)
                    context.Course.Remove(course);
                context.SaveChanges();
            }
            catch { }
        }


        public Course? Find(Predicate<Course> predicate)
        {
            using var context = new MyDatabaseContext();
            return context.Course.FirstOrDefault(c => predicate(c));
        }

        public Course? Get(int id)
        {
            using var context = new MyDatabaseContext();
            return context.Course.FirstOrDefault(x => x.CourseId == id);
        }

        public IEnumerable<Course> GetAll()
        {
            using var context = new MyDatabaseContext();
            return [.. context.Course];
        }

    }
}
