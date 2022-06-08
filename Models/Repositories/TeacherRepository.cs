namespace GestionEtudiant.Models.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        readonly StudentContext context;

        public TeacherRepository(StudentContext context)
        {
            this.context = context;
        }

        public void Add(Teacher t)
        {
            context.Teachers.Add(t);
            context.SaveChanges();
        }

        public void Delete(Teacher t)
        {
            Teacher t1 = context.Teachers.Find(t.TeacherID);
            if (t1 != null)
            {
                context.Teachers.Remove(t1);
                context.SaveChanges();
            }
        }

        public void Edit(Teacher t)
        {
            Teacher t1 = context.Teachers.Find(t.TeacherID);
            if (t1 != null)
            {
                t1.TeacherName = t.TeacherName;
                t1.Teacherspeciality = t.Teacherspeciality;
                context.SaveChanges();
            }
        }

        public IList<Teacher> GetAll()
        {
            return context.Teachers.OrderBy(t => t.TeacherName).ToList();
        }

        public Teacher GetById(int id)
        {
            return context.Teachers.Find(id);
        }
    }
}
