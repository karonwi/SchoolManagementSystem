using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Seeder
{
    public static class SeederHelper<T>
    {
        #region Comment
        /*
         * I intend to try various file reader methods and get current directory method.
         * I Have changed the usual readAllText to streamreader because I read that stream reader is faster.
         */
        #endregion
        public static List<T> GetData(string filePath)
        {
            //var dir3 = AppDomain.CurrentDomain.BaseDirectory;
            //var dir2 = System.AppContext.BaseDirectory;
            //var dir = Environment.CurrentDirectory;
            var baseDir = Directory.GetCurrentDirectory();
            var fileReader = new StreamReader(FilePath(baseDir, filePath));
            var text = fileReader.ReadToEnd();
            //var path2 = File.ReadAllText(FilePath(baseDir, filePath));
            return JsonConvert.DeserializeObject<List<T>>(text);
        }

        private static string FilePath(string folderName, string fileName)
        {
            folderName += @"/Json";
            if (Directory.Exists(folderName))
            {
                return Path.Combine(folderName, fileName);
            }
            return "";
        }
    }
}
