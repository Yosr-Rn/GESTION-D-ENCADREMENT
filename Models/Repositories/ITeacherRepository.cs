namespace GestionEtudiant.Models.Repositories
{
    public interface ITeacherRepository
    {
        IList<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(Teacher t);
        void Edit(Teacher t);
        void Delete(Teacher t);

       
    }
}
