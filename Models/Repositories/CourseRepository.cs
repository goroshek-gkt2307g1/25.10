using _25._10.Domain;
using _25._10.Interfaces;
using _25._10.Models.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _25._10.Models.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        public void Add(Course course)
        {
            try
            {
                using var context = new MyDatabaseContext();
                context.Courses.Add(course); // Исправлено: context.Courses вместо context.Add
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding course: {ex.Message}");
            }
        }

        public void Update(int id, Course course)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var courseInDb = context.Courses.FirstOrDefault(x => x.CourseId == id);
                if (courseInDb != null)
                {
                    courseInDb.CourseTitle = course.CourseTitle;
                    courseInDb.CourseDescription = course.CourseDescription;
                    // Добавь другие свойства Course если есть

                    context.Courses.Update(courseInDb);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating course: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var course = context.Courses.FirstOrDefault(x => x.CourseId == id);
                if (course != null)
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
            }
        }

        public Course? Find(Predicate<Course> predicate)
        {
            using var context = new MyDatabaseContext();
            return context.Courses
                .AsEnumerable() 
                .FirstOrDefault(c => predicate(c));
        }

        public Course? Get(int id)
        {
            using var context = new MyDatabaseContext();
            return context.Courses
                .FirstOrDefault(x => x.CourseId == id);
        }

        public IEnumerable<Course> GetAll()
        {
            using var context = new MyDatabaseContext();
            return context.Courses.ToList();
        }
    }
}