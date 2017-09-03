namespace CoursesApi.Models.EntityModels
{
   /// <summary>
   /// This Entity is used for student
   /// It is not exposed outside of the API
   /// used in both service and repository layer
   /// </summary>
   public class Student
   {
       public int ID {get; set;}
      
       public int SSN { get; set; }

       public string Name { get; set; }

       public int StudentCourseID  { get; set; }
   }

}


