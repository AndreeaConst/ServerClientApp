using PersonService.DataAccess;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonService.Services
{
    public class PersonService : PersonRegistration.PersonRegistrationBase
    {
        private readonly PersonOperations personOperations = new PersonOperations();
        private readonly ILogger<PersonService> _logger;

        public PersonService(ILogger<PersonService> logger)
        {
            _logger = logger;
        }

        public override Task<AddPersonResponse> AddPerson(AddPersonRequest request, ServerCallContext context)
        {
            var person = request.Person;
            var people = personOperations.AddPerson(person);

            _logger.Log(LogLevel.Information, "Added person: " + person.Name);

            return Task.FromResult(new AddPersonResponse() { Status = AddPersonResponse.Types.Status.Success });
        }

        public override Task<Empty> PrintPeopleStream(Empty request, ServerCallContext context)
        {
            PersonOperations personOperations = new PersonOperations();
            personOperations.GetPeople();

            return Task.FromResult(new Empty());
        }
    }
}