using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DateiTools
{
    public class DateiTools
    {
        private string path;

        public string Path { get => path; set => path = value; }

        public DateiTools(string path)
        {
            this.path = path;
        }

        public void ausgeben() 
        {

            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                FileInfo[] files = dir.GetFiles();
                DirectoryInfo[] subDirs = dir.GetDirectories();

                Console.WriteLine($"Verzeichnis von {path}");
                Console.WriteLine();

                ulong totalSize = 0;
                foreach (FileInfo file in files)
                {
                    Console.WriteLine($"{file.CreationTime} {file.Length} {file.Name}");
                    totalSize += (ulong)file.Length;
                }

                int filecount = files.Length;
                int dircount = subDirs.Length;

                Console.WriteLine();
                Console.WriteLine($"{filecount} Datei(en)");
                if(dircount == 0) 
                {
                    Console.WriteLine("Keine Verzeichnisse vorhanden");
                }
                else
                {
                    Console.WriteLine($"{dircount} Verzeichnis (se)");
                }
                Console.WriteLine($"{totalSize:N0} Bytes");

            }
            else
            {
                Console.WriteLine("Pfad existiert nicht");
            }
        }
    }
}
