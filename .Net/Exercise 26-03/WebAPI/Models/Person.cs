using System;

namespace WebAPI
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
    }
}