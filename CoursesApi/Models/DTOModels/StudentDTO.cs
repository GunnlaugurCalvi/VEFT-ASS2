namespace CoursesApi.Models.DTOModels
{
    /// <summary>
    /// DTO model used to return only the studentID
    /// and name to the web API
    /// </summary>
    public class StudentsDTO
    {   
        public int SSN { get; set; }

        public string Name { get; set; }

    }

}