using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsOperations.Base;
using StudentsOperations.Storages.Base.Interfaces;

namespace StudentsOperations.Storages.Base
{
    public abstract class ListStorage<T> : List<T>, IStorage<T> where T : Entity
    {
        public IEnumerable<T> GetAll() => this.AsEnumerable();

        public T? GetById(int Id) => GetAll().FirstOrDefault(e => e.Id == Id);

        public abstract int Add(T NewItem);

        public bool Edit(T Item) { throw new NotImplementedException(); }

        public T? Remove(int Id) { throw new NotImplementedException(); }
    }
}
