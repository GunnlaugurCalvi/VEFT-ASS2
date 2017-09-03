using System;

namespace CoursesApi.Models.viewModels
{

   /// <summary>
   /// This course viewmodel class is used for return values
   /// and parameters to the web API methods
   /// </summary>
   public class CourseTemplate
   {
       public string CourseID {get; set;}

       public string Semester {get; set;}

       public DateTime StartDate {get; set;}

       public DateTime EndDate {get; set;}
   }
}


