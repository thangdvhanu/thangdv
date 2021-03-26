using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Models
{
    public class MembersRepository : IMembersRepository
    {
        private static List<Member> members = new List<Member>(){
            new Member()
            {
                FirstName = "Bao",
                LastName = "Tran",
                Gender = "Male",
                DOB = DateTime.Now.AddYears(-30),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Tinh",
                StartDate = DateTime.Now.AddDays(-15),
                EndDate = DateTime.Now.AddMonths(3)
            },
            new Member()
            {
                FirstName = "Quyen",
                LastName = "Huynh",
                Gender = "Female",
                DOB = DateTime.Now.AddYears(-29),
                PhoneNumber = "0123456778",
                BirthPlace = "Ho Chi Minh",
                StartDate = DateTime.Now.AddDays(-15),
                EndDate = DateTime.Now.AddMonths(3)
            },
            new Member()
            {
                FirstName = "Dung",
                LastName = "Que",
                Gender = "Female",
                DOB = DateTime.Now.AddYears(-29),
                PhoneNumber = "0124556778",
                BirthPlace = "Ho Chi Minh",
                StartDate = DateTime.Now.AddDays(-15),
                EndDate = DateTime.Now.AddMonths(3)
            },
            new Member()
            {
                FirstName = "Vi",
                LastName = "Tran",
                Gender = "Female",
                DOB = DateTime.Now.AddYears(-29),
                PhoneNumber = "0123496778",
                BirthPlace = "Ho Chi Minh",
                StartDate = DateTime.Now.AddDays(-15),
                EndDate = DateTime.Now.AddMonths(3)
            },
            new Member()
            {
                FirstName = "Dat",
                LastName = "Nguyen",
                Gender = "Male",
                DOB = DateTime.Now.AddYears(-28),
                PhoneNumber = "0123498778",
                BirthPlace = "Ho Chi Minh",
                StartDate = DateTime.Now.AddDays(-15),
                EndDate = DateTime.Now.AddMonths(3)
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

        public List<Member> GetListMembersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return members;
            }
            return members.Where(x => x.LastName == name || x.FirstName == name).ToList();
        }
    }
}