namespace CoursesApi.Models.EntityModels
{
    public class Student
    { 
        public int ID {get; set;}
        
        public int SSN { get; set; }

        public string Name { get; set; }

        public int StudentCourseID  { get; set; }
    }

}