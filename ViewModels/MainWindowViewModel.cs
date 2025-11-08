using _25._10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using _25._10.Models.Entities;
using _25._10.Models.Repositories;
using _25._10.Commands;
using System.Collections.Specialized;

namespace _25._10.ViewModels
{
    internal class MainWindowViewModel : PropertyChangedBase
    {
        private MyCommand _addCommand;
        private MyCommand _updateCommand;
        private MyCommand _deleteCommand;
        private ObservableCollection<Course> _courses;
        private readonly CourseRepository _courseRepository;
        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                if (value != null)
                {
                    _courses = value;
                    OnPropertyChanged();
                }
            }
        }

        public MyCommand AddCommand
        {
            get => _addCommand ??= new MyCommand(
            (obj) =>
            {
                Course course = new();
                GetUsersView();
                _courseRepository.Add(course);
            }, (obj) => true
            );
        }
        public MyCommand UpdateCommand
        {
            get => _updateCommand ??= new MyCommand(
            (obj) =>
            {
                var course = Courses.Last();
                course.CourseDescription = "Обнова описания";
                _courseRepository.Update(course.CourseId, course);
                GetUsersView();
            }, (obj) => Courses.Count > 0
            );
        }

        public MyCommand DeleteCommand
        {
            get => _deleteCommand ??= new MyCommand(
            (obj) =>
            {
                var course = Courses.Last();
                _courseRepository.Delete(course.CourseId);
                GetUsersView();
            }, (obj) => Courses.Count > 0
            );
        }


        public MainWindowViewModel()
        {
            _courseRepository = new();
            GetUsersView();
            Courses.CollectionChanged += Courses_CollectionChanged;
        }

        private void Courses_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems != null)
                {
                    foreach (Course course in e.NewItems)
                    {
                        _courseRepository.Add(course);
                    }
                }
            }
            //другие проверки...
        }

        private void GetUsersView()
        {
            var collection = _courseRepository.GetAll();
            Courses = new ObservableCollection<Course>(collection);
        }
    }
}
