using LMS.Dal.Entities;

namespace LMS.Dal
{
    public interface IEntityDao<T> where T : class
    {
        int Create(T entity);
        int Delete(Guid id);
        List<T> GetAll();
        T GetById(Guid id);
        List<T> GetByName(string name);
        int Update(T entity);
    }
}