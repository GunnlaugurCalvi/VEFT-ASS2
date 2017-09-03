using System;

namespace CoursesApi.Models.EntityModels
{
   /// <summary>
   /// Entity Model for course
   /// this entity is not exposed outside of the API
   /// used in both service and repository layer
   /// </summary>
   public class Course
   {
       public int ID { get; set; }

       public string Name { get; set; }

       public string CourseID { get; set; }

       public string Semester {get; set;}

       public DateTime StartDate {get; set;}

       public DateTime EndDate {get; set;}
   }

}

