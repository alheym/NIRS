using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS
{
    public static class ProjectManager
    {
        /// <summary>
        ///  Стандартный путь сохранения/загрузки файла
        /// </summary>
        private static string _filePathDefault =
            Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"/lab.S2P";

        /// <summary>
        /// Метод сохранения файла
        /// </summary>
        /// <param name="_project"> сохраняемый файл</param>
        /// <param name="_filePath"> путь для сохранения</param>
        public static void SaveFile(Project _project, string _filePath)
        {
            if (_filePath == String.Empty)
            {
                _filePath = _filePathDefault;
            }

            JsonSerializer serialiser = new JsonSerializer() { Formatting = Formatting.Indented };

            // Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(_filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {   
                //Вызываем сериализацию и передаем объект который хотим сериализовать
                serialiser.Serialize(writer, _project);
            }
        }

        /// <summary>
        /// метод загрузки файла
        /// </summary>
        /// <param name="project"> загружаемый файл</param>
        /// <param name="_filePath">путь откуда будут загружены данные</param>
        /// <returns>загруженный файл</returns>
        public static Project LoadFile(Project project, string _filePath)
        {
            // если путь директории не указан, то загрузить из стандартной 
            if (_filePath == String.Empty)
            {
                _filePath = _filePathDefault;
            }
            
            // если файл не существует --> создать новый файл
            if (!File.Exists(_filePathDefault))
            {
                return new Project();
            }

            // экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();

            // поток для чтения файла с указанием пути
            using (StreamReader sr = new StreamReader(_filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                // вызываем десериализацию и явно преобразуем результат в целевой тип данных
                project = (serializer.Deserialize<Project>(reader));
                return project;
            }
        }
    }
}
