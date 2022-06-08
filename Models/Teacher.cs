using System.ComponentModel.DataAnnotations;

namespace GestionEtudiant.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string Teacherspeciality { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
