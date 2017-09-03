using System;

namespace CoursesApi.Models.viewModels
{
    public class CourseTemplate
    {
        public string CourseID {get; set;}

        public string Semester {get; set;}

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}
    }
}