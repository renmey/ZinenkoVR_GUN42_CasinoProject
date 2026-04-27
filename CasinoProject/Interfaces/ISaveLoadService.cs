using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoProject.Interfaces
{
    public interface ISaveLoadService<T>
    {
        public void SaveData(T data, string id);

        public T LoadData(string id); 
    }
}
