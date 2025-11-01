using _25._10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using _25._10.Models.Entities;
using _25._10.Models.Repositories;

namespace _25._10.ViewModels
{
    internal class MainWindowViewModel : Entity
    {
        private readonly CourseRepository _courseRepository;
        public ObservableCollection<Course> Courses { get; set; }
        public MainWindowViewModel() 
        {
            _courseRepository = new();
            var collection = _courseRepository.GetAll();
            Courses = new ObservableCollection<Course>(collection);
        }
    }
}
