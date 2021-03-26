using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class MembersRepository
    {
        private static List<Member> members = new List<Member>(){
            new Member()
            {
                FirstName = "Nguyen Van",
                LastName = "A",
                Gender = "Male",
                DOB = new DateTime(1995, 04, 05),
                PhoneNumber = "0936934555",
                BirthPlace = "Ha Noi",
                StartDate = new DateTime(2021, 03, 15),
                EndDate = new DateTime(2021, 06, 15)
            },
            new Member()
            {
                FirstName = "Nguyen Thi",
                LastName = "B",
                Gender = "Female",
                DOB = new DateTime(1995, 04, 05),
                PhoneNumber = "0936934555",
                BirthPlace = "Ha Noi",
                StartDate = new DateTime(2021, 03, 15),
                EndDate = new DateTime(2021, 06, 15)
            },
            new Member()
            {
                FirstName = "Nguyen Van",
                LastName = "A",
                Gender = "Male",
                DOB = new DateTime(1995, 04, 05),
                PhoneNumber = "0936934555",
                BirthPlace = "Ha Noi",
                StartDate = new DateTime(2021, 03, 15),
                EndDate = new DateTime(2021, 06, 15)
            },
            new Member()
            {
                FirstName = "Nguyen Van",
                LastName = "A",
                Gender = "Male",
                DOB = new DateTime(1995, 04, 05),
                PhoneNumber = "0936934555",
                BirthPlace = "Ha Noi",
                StartDate = new DateTime(2021, 03, 15),
                EndDate = new DateTime(2021, 06, 15)
            },
            new Member()
            {
                FirstName = "Nguyen Van",
                LastName = "A",
                Gender = "Male",
                DOB = new DateTime(1995, 04, 05),
                PhoneNumber = "0936934555",
                BirthPlace = "Ha Noi",
                StartDate = new DateTime(2021, 03, 15),
                EndDate = new DateTime(2021, 06, 15)
            }
        };
        public List<Member> GetListMembers()
        {
            return members;
        }
        public void AddNewMember(Member member)
        {
            members.Add(member);
        }
        public void UpdateMember(Member member, int index)
        {
            if (IsAValidIndex(index))
            {
                members[index] = member;
            }
        }
        public Member GetMemberByIndex(int index)
        {
            if (!IsAValidIndex(index)) return null;
            Member member = members[index];
            return member;
        }
        public void DeleteMemberByIndex(int index)
        {
            if (IsAValidIndex(index))
            {
                members.RemoveAt(index);
            }
        }
        //Check if an index delivered from view is a valid one
        private bool IsAValidIndex(int index)
        {
            return (index < members.Count && index >= 0);
        }
    }
}