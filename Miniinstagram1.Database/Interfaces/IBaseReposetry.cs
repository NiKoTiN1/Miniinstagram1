using System.Collections.Generic;

namespace Miniinstagram1.Database.Interfaces
{
    public interface IBaseReposetry<T>
    {
        void Create(T item);
        void Delete(T item);
        T Get(string id);
        ICollection<T> GetAll();
        void Update(T itemб, string id);
    }
}