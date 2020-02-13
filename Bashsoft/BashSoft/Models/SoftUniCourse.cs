namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return this.studentsByName; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);

                ////throw new ArgumentException(string.Format(
                ////    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                ////    student.UserName, this.name));

                ////OutputWriter.DisplayException(string.Format(
                ////    ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                ////    student.UserName, this.name));
                ////return;
            }

            this.studentsByName.Add(student.UserName, student);
        }

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

        public override string ToString() => this.Name;
    }
}
