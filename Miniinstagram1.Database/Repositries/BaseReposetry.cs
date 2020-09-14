using Miniinstagram1.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miniinstagram1.Database.Repositries
{
    public class BaseReposetry<T> : IBaseReposetry<T> where T : class
    {
        public BaseReposetry(DatabaseContext context)
        {
            _context = context;
        }
        DatabaseContext _context;
        public void Create(T item)
        {
            _context.Add<T>(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
