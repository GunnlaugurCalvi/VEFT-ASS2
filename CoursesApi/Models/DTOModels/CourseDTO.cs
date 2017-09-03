namespace CoursesApi.Models.DTOModels
{
    /// <summary>
    /// DTO model used for returning only names of courses
    /// to the web API
    /// </summary>
    public class CourseDTO
    {
        public string Name { get; set; }
    }

}