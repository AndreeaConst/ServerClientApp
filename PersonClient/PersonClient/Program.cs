using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using PersonClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PersonClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new PersonRegistration.PersonRegistrationClient(channel);

            int kCurrentYear = 2021;

            Console.Write("Type in your name: ");
            var name = Console.ReadLine();

            Console.Write("Type in your ID: ");
            var id = Console.ReadLine();

            var gender = "undefined";
            var age = 0;
            string lastNo = id[1].ToString() + id[2].ToString();
            int birthYear;

            switch (id[0])
            {
                case ('1'):
                    gender = "M";

                    birthYear = Convert.ToInt32("19" + lastNo);
                    if(kCurrentYear > birthYear)
                        age = kCurrentYear - birthYear;

                    break;
                case ('2'):
                    gender = "F";

                    birthYear = Convert.ToInt32("19" + lastNo);
                    if (kCurrentYear > birthYear)
                        age = kCurrentYear - birthYear;

                    break;
                case ('5'):
                    gender = "M";

                    birthYear = Convert.ToInt32("20" + lastNo);
                    if (kCurrentYear > birthYear)
                        age = kCurrentYear - birthYear;

                    break;
                case ('6'):
                    gender = "F";

                    birthYear = Convert.ToInt32("20" + lastNo);
                    if (kCurrentYear > birthYear)
                        age = kCurrentYear - birthYear;

                    break;
            }


            var personToBeAdded = new Person() { 
                Name = name.Trim().Length > 0 ? name : "undefined",
                Gender = gender,
                Age = age,
                ID = id.Trim().Length > 0 ? id : "undefined" };
            var response = await client.AddPersonAsync(new AddPersonRequest { Person = personToBeAdded });
            Console.WriteLine("Adding status: " + response.Status);

            client.PrintPeopleStream(new Empty());
        }
    }
}