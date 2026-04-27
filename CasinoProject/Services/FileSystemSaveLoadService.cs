using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoProject.Interfaces;
using CasinoProject.Services;

namespace CasinoProject.Services
{
     public class FileSystemSaveLoadService : ISaveLoadService<string>
    {

        private readonly string _path;


        public FileSystemSaveLoadService(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
                
            }

            _path = path;
            IsDirectoryExists();
        }

        public void SaveData(string data, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            IsDirectoryExists();

            string filePath = Path.Combine(_path, $"{id}.txt");

            File.WriteAllText(filePath, data);

        }

        public string LoadData(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            IsDirectoryExists();

            if (!File.Exists(Path.Combine(_path, $"{id}.txt")))
            {
                return null; 
            }


            return File.ReadAllText(Path.Combine(_path, $"{id}.txt"));

        }

        private void IsDirectoryExists()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }


    }
}
