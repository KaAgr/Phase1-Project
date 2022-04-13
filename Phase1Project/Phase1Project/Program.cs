using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                //Console.Clear();
                Console.WriteLine("\nEnter 1 to read details, 2 to add details, 3 to remove details, 4 to exit");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    ReadDetails.ReadInFile();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\nEnter id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter class:");
                    int std = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter section:");
                    char section = Convert.ToChar(Console.ReadLine());

                    WriteDetails obj = new WriteDetails(id, name, std, section);
                    bool flag=obj.WriteInFile();

                    if(flag)
                        Console.WriteLine("\nRecord added successfully, Press Enter to continue");
                    Console.ReadLine();
                }

                else if (choice == 3)
                {
                    Console.WriteLine("\nEnter id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool flag=WriteDetails.DeleteInFile(id);
                    if (flag)
                        Console.WriteLine("\nRecord deleted successfully, Press Enter to continue");
                    Console.ReadLine();
                }

                else if(choice == 4)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid Input, Press enter to continue");
                    Console.ReadLine();
                }
            } while (choice != 4);
        }
    }
}
