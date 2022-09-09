using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services;

public interface IStudentService
{
    IEnumerable<Student> GetStudentsWithCourses(); // fcionalidad q hay q inpementar
    IEnumerable<Student> GetStudentsWithNoCourses();

}