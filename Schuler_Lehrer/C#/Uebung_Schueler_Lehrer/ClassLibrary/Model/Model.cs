using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AverageGrade { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }

    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        
        public ICollection<Student> Students { get; set; }

        public ICollection<ClassTeacher> ClassTeachers { get; set; }

    }

    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }

    public class ClassTeacher
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
