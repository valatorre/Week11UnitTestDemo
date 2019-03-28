using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public interface IPersonOrchestrator
    {
        List<PersonViewModel> GetAllPeople();
    }
    public class PersonOrchestrator : IPersonOrchestrator
    {
        private readonly IDateTimeService _dateTimeService;

        public PersonOrchestrator(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public List<PersonViewModel> GetAllPeople()
        {
            var people = new List<PersonViewModel>
            {
                new PersonViewModel
                {
                    FirstName = "Bill",
                    LastName = "Gates",
                    Birthdate = new DateTime(1955, 4, 4)
                },
                new PersonViewModel
                {
                    FirstName = "Steve",
                    LastName = "Jobs",
                    Birthdate = new DateTime(1955, 3, 28)
                }
            };

            return people;
        }

        public bool IsTodayYourBirthday(PersonViewModel person)
        {
            var birthday = person.Birthdate;
            var today = _dateTimeService.Now();

            return birthday.Month == today.Month && birthday.Day == today.Day;
        }
    }
}
