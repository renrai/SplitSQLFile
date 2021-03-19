using System;
using System.IO;

namespace SplitTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {

                string infile = @"C:\Projetos\SplitFiles\sql.sql";
                var reader = File.OpenText(infile);
                int outFileNumber = 1;
                Console.WriteLine("Wait...");
                const int MAX_LINES = 100000;
                while (!reader.EndOfStream)
                {
                    string outfname = Path.GetDirectoryName(infile) + "\\" + Path.GetFileNameWithoutExtension(infile) + outFileNumber.ToString("D4") + Path.GetExtension(infile);
                    Console.WriteLine(outfname);
                    var writer = File.CreateText(outfname);
                    for (int idx = 0; idx < MAX_LINES; idx++)
                    {
                        writer.WriteLine(reader.ReadLine());
                        if (reader.EndOfStream) break;
                    }
                    writer.Close();
                    outFileNumber++;
                }
                reader.Close();
                Console.WriteLine("Done.");
                Console.ReadKey();
            
        }
    }
}
