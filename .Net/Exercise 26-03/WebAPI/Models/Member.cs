using System;

namespace WebAPI
{
    public class Member : Person
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}