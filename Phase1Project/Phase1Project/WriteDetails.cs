using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1Project
{
    internal class WriteDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public int std { get; set; }
        public char section { get; set; }

        public WriteDetails() { }
        public WriteDetails(int id, string name, int std, char section)
        {
            this.id = id;
            this.name = name;
            this.std = std;
            this.section = section;
        }

        public bool WriteInFile()
        {
            string modified = $"{id}\t{name}\t{std}\t{section}";
            try
            {
                string path = Directory.GetCurrentDirectory();
                path += @"\record.txt";
                using (StreamWriter streamWriter = new StreamWriter(path,true))
                {
                    streamWriter.WriteLine($"{modified}");
                    streamWriter.Flush();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static bool DeleteInFile(int id)
        {
            List<WriteDetails> products = new List<WriteDetails>();
            try
            {
                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\record.txt");
                string[] lines = File.ReadAllLines(fileInfo.FullName);

                foreach (var line in lines)
                {
                    WriteDetails product = new WriteDetails();
                    string[] values = line.Split('\t');
                    product.id = Convert.ToInt32(values[0]);
                    product.name = values[1];
                    product.std = Convert.ToInt32(values[2]);
                    product.section = Convert.ToChar(values[3]);
                    products.Add(product);
                }
                if (products != null)
                {

                    var proToDelete = products.Where(x => x.id == id).FirstOrDefault();
                    products.Remove(proToDelete);
                    fileInfo.Delete();
                    foreach (var pro in products)
                    {
                        pro.WriteInFile();
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
