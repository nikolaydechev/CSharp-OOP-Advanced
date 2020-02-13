namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class SoftUniStudent : IStudent
    {
        private string userName;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public SoftUniStudent(string userName, Dictionary<string, ICourse> enrolledCourses, Dictionary<string, double> marksByCourseName)
            : this(userName)
        {
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);

                ////throw new ArgumentException(string.Format(
                ////    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                ////    this.userName, course.Name));

                ////OutputWriter.DisplayException(string.Format(
                ////    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                ////    this.userName, course.Name));
                ////return; 
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();

                ////throw new ArgumentException(ExceptionMessages.NotEnrolledInCourse);

                ////OutputWriter.DisplayException(ExceptionMessages.NotEnrolledInCourse);
                ////return;
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);

                ////OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                ////return;
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }
        
        public int CompareTo(IStudent other) => this.UserName.CompareTo(other.UserName);

        public override string ToString() => this.UserName;

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = (scores.Sum()) /
                                            (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}
