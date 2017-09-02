using System;

namespace CoursesApi.Models.EntityModels
{
    public class Course
    { 
        public int ID { get; set; }

        public string Name { get; set; }

        public string CourseID { get; set; }

        public int Semester {get; set;}

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}
    }

}