using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepositoryPattern.Models.DAL
{
    public class AllRepository<T> : _IAllRepository<T> where T : class
    {
        private EntityframworkEntities _dbcontext;
        private IDbSet<T> _dbentity;

        public AllRepository()
        {
            _dbcontext = new EntityframworkEntities();
            _dbentity = _dbcontext.Set<T>(); 
        }

        public IEnumerable<T> GetaData()
        {
            return _dbentity.ToList();
        }

        public T GetDataById(int id)
        {
            T obj = _dbentity.Find(id);
            return obj;
        }

        public void InsertData(T data)
        {
            _dbentity.Add(data);
        }

        public void UpdateData(int id, T data)
        {
            _dbcontext.Entry(data).State = EntityState.Modified;
        }

        public void DeleteData(int id)
        {
            T obj = _dbentity.Find(id);
            _dbentity.Remove(obj);
        }

        public void SaveData()
        {
            _dbcontext.SaveChanges();
        }
    }
}