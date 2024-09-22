using System.IO;
using System.Text;

namespace FileLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo testDir1 = new DirectoryInfo(@"c:\Otus\TestDir1");
            DirectoryInfo testDir2 = new DirectoryInfo(@"c:\Otus\TestDir2");

            DirecotyCreate(testDir1);
            DirecotyCreate(testDir2);

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(GenerateFiles(@"c:\Otus\TestDir1\", i) + " created");
                Console.WriteLine(GenerateFiles(@"c:\Otus\TestDir2\", i) + " created");
            }

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(ReadFileLine($@"c:\Otus\TestDir1\File{i}.txt", i));
                Console.WriteLine(ReadFileLine($@"c:\Otus\TestDir2\File{i}.txt", i));
            }

        }

        public static void DirecotyCreate(DirectoryInfo di)
        {
            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                di.Create();
                Console.WriteLine("The directory was created successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed on directory creation: {0}", e.ToString());
            }
        }

        public static string GenerateFiles(string path, int i)
        {
            path = path + "File" + $"{i}" + ".txt";
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"File{i}");
                        sw.WriteLine(DateTime.Now);
                    }
                }
                else
                {
                    Console.WriteLine("That file exists already.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed on file generation: {0}", e.ToString());
            }

            return path;
        }
        public static string ReadFileLine(string path, int i)
        {
            Console.WriteLine("Reading file by lines...");
            string line;
            string content = $"File{i}: ";

            try
            {
                StreamReader sr = new StreamReader(path);

                line = sr.ReadLine();

                for (int j = 1; j < 3; j++)
                {

                    if (j == 1)
                    {
                        content += line;
                        line = sr.ReadLine();
                    }
                    else
                    {
                        content += " + " + line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed on file reading: {0}", e.ToString());
            }


            Console.WriteLine("File reading completed.");

            return content;
        }

        public static string ReadAllFile(string path)
        {
            Console.WriteLine("Reading file...");

            string content = "";

            try
            {
                if (File.Exists(path))
                {
                    content += File.ReadAllText(path);
                }
                else
                {
                    Console.WriteLine($"File {path} does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed on file reading: {0}", e.ToString());
            }


            Console.WriteLine("File reading completed.");

            return content;
        }
    }
}
