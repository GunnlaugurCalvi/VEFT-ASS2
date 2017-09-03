namespace CoursesApi.Models.DTOModels
{
    /// <summary>
    /// DTO model used to return a detailed
    /// description of a course to web API
    /// </summary>
    public class CourseDTODetail
    {
        public string Name { get; set; }

        public string CourseID { get; set; }

        public string Semester {get; set;}

        public int StudentCount {get ; set;}
    }

}