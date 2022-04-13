using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phase1Project
{
    internal class ReadDetails
    {
       
        public static void ReadInFile()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                path += @"\record.txt";
                using (StreamReader sr = new StreamReader(path))
                {
                    string str = sr.ReadToEnd();
                    
                    Console.WriteLine("ID\tNAME\tCLASS\tSECTION");
                    Console.WriteLine(str);
                    

                }
                Console.WriteLine("\nPress enter to continue");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nNo records to diplay");
            }
        }
    }
}

