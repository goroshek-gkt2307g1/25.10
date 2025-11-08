using _25._10.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Domain
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<Course> Course { get; set; }

        public MyDatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DBSRV\\ag2025;Initial Catalog='VlasovaAA курсовая1';Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //настраиваем ограничение UNIQUE
            modelBuilder.Entity<Course>().HasIndex(c => c.CourseId).IsUnique();
            //настраиваем начальные данные
            modelBuilder.Entity<Course>().HasData([
            new Course(1, "Программист .NET", "Пройди основы .NET и C#", "Петров А.П", "Активна") {UserEnrollmentStatus = "APPROVED"},
            new Course(2, "Data Science на Python", "Анализ данных и машинное обучение", "Иванова М.К", "Активна" ) {UserEnrollmentStatus = "NOT_APPLIED" },
            new Course(3, "Веб-разработка", "Full-stack разработка современных приложений", "Сидоров В.Л", "Активна") {UserEnrollmentStatus = "NOT_APPLIED" },
            new Course(4, "Английский для IT", "Технический английский и коммуникация", "Козлова Е.В", "Активна") {UserEnrollmentStatus = "APPROVED" },
            new Course(5, "Тестирование ПО", "Автоматизация тестирования и QA", "Соколова Е.П", "Активна") {UserEnrollmentStatus = "PENDING" },
            new Course(6, "DevOps практики", "CI/CD, контейнеризация и облака", "Федоров Д.С", "Активна") {UserEnrollmentStatus = "NOT_APPLIED" },
            new Course(7, "Мобильная разработка", "Создание приложений для iOS и Android", "Николаев П.Р", "Активна") {UserEnrollmentStatus = "NOT_APPLIED" },
            new Course(8, "Кибербезопасность", "", "Орлов А.В", "Активна") {UserEnrollmentStatus = "NOT_APPLIED" },
            new Course(9, "UX/UI дизайн", "Проектирование интерфейсов и разработка макетов", "Морозова Т.И", "Активна") {UserEnrollmentStatus = "PENDING" },
            new Course(10, "Управление проектами", "Agile, Scrum и менеджмент IT-проектов", "Волков С.М", "Активна") {UserEnrollmentStatus = "REJECTED" }
        ]);
        }
    }
}
