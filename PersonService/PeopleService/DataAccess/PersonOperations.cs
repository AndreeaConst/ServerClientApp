using PersonService;
using System;
using System.Collections.Generic;
using System.IO;

namespace PersonService.DataAccess
{
    public class PersonOperations
    {
        private readonly string filePath = "./Resources/people.txt";

        public bool AddPerson(Person person)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(person.Name + "|" + person.Gender + "|" + person.Age + "|" + person.ID, true);
                sw.Close();
                Console.WriteLine("Adding client to list...");
                Console.WriteLine("Name " + person.Name + ", gender " + person.Gender + ", age " + person.Age + ", ID " + person.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return true;
        }

        public void GetPeople()
        {
            
            string line;
            try
            {
                Console.WriteLine("Clients registered so far: ");

                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] broken_line = line.Split('|');

                    Person person = new Person() { Name = broken_line[0], Gender = broken_line[1], Age = Convert.ToInt32(broken_line[2]), ID = broken_line[3] };

                    Console.WriteLine("Name: " + person.Name + ", gender: " + person.Gender + ", age: " + person.Age + ", ID: " + person.ID);

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}