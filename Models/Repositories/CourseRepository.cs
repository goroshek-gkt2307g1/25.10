using _25._10.Interfaces;
using _25._10.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Models.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private List<Course> _courses = [
            new Course(1, "Программист .NET", "Пройди основы .NET", DateTime.Now, "Петров А.П", "Активна"),
            new Course(2,"Программист Python", "Пройди основы Python", DateTime.Now, "Петров А.П", "Активна"),
            new Course(3,"Программист Scratch", "Пройди основы Scratch", DateTime.Now, "Петров А.П", "Активна"),
            new Course(4,"Английский язык", "Прокачай свой уровень английского", DateTime.Now, "Петров А.П", "Активна"),
    ];
        public Course? Find(Predicate<Course> predicate) => _courses.Find(predicate);
        public Course? Get(int id) => _courses.FirstOrDefault(x => x.Id == id);
        public IEnumerable<Course> GetAll() => _courses;
    }
}
