using System;

namespace CoursesApi.Models.viewModels
{
    public class CourseTemplate
    {
        public string CourseID {get; set;}

        public int Semester {get; set;}

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}
    }
}