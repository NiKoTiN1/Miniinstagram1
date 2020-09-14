using Microsoft.EntityFrameworkCore;
using Miniinstagram1.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miniinstagram1.Database.Repositries
{
    public class BaseReposetry<T> : IBaseReposetry<T> where T : class
    {
        public BaseReposetry(DatabaseContext context)
        {
            _context = context;
        }

        DbSet<T> set => _context.Set<T>();

        DatabaseContext _context;
        public void Create(T item)
        {
            set.Add(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            set.Remove(item);
            _context.SaveChanges();
        }

        public T Get(string id)
        {
            var item = set.Find(id);
            return item;
        }

        public ICollection<T> GetAll()
        {
            return set.ToList();
        }

        public virtual void Update(T item, string id)
        {
            var elem = set.Find(id);
            if(elem != null)
            {
                elem = item;
                _context.SaveChanges();
            }
        }
    }
}
