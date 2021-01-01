using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Models.DAL
{
    public interface _IAllRepository<T>  where T : class
    {
        IEnumerable<T> GetaData();
        T GetDataById(int id);
        void InsertData(T data);
        void UpdateData(int id, T data);
        void DeleteData(int id);
        void SaveData();
    }
}
