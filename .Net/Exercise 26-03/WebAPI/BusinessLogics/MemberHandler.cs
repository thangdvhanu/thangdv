using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.BusinessLogics
{
    public class MemberHandler : IMemberHandler
    {
        private List<Member> _listMembers;
        public MemberHandler()
        {
            SeedingData();
        }

        public List<Member> AddNewMember(Member member)
        {
            _listMembers.Add(member);
            return _listMembers;
        }

        public List<Member> DeleteMember(int index)
        {
            _listMembers.RemoveAt(index);
            return _listMembers;
        }

        public List<Member> FilterMemberByBirthPlace(string place)
        {
            var result = _listMembers.Where(x => x.BirthPlace == place).ToList();
            return result;
        }

        public List<Member> FilterMemberByBirthYear(int year)
        {
            var result = _listMembers.Where(x => x.DOB.Year == year).ToList();
            return result;
        }

        public List<Member> FilterMemberByBirthYearGreaterThan(int year)
        {
            var result = _listMembers.Where(x => x.DOB.Year > year).ToList();
            return result;
        }

        public List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            var result = _listMembers.Where(x => x.DOB.Year < year).ToList();
            return result;
        }

        public List<Member> FilterMemberByGender(string gender)
        {
            var result = _listMembers.Where(x => x.Gender == gender).ToList();
            return result;
        }

        public List<Member> FilterMemberByGraduation(bool IsGraduated)
        {
            var result = _listMembers.Where(x => x.IsGraduated == IsGraduated).ToList();
            return result;
        }

        public List<string> GetMemberWithFullNameOnly()
        {
            var result = _listMembers.Select(x => $"{x.FirstName + " " + x.LastName}").ToList();
            return result;
        }

        public Member ReturnTheOldestMember()
        {
            var minDob = _listMembers.Min(x => x.DOB);
            var result = _listMembers.FirstOrDefault(x => x.DOB == minDob);
            return result;
        }

        private void SeedingData()
        {
            _listMembers = new List<Member>{
                new Member{
                    FirstName = "Bao",
                    LastName = "Tran",
                    Gender = "Male",
                    DOB = DateTime.Now.AddYears(-30).Date,
                    PhoneNumber = "0123456789",
                    BirthPlace = "Ha Tinh",
                    IsGraduated = true,
                    StartDate = DateTime.Now.AddDays(-15).Date,
                    EndDate = DateTime.Now.AddMonths(3).Date
                },
                new Member{
                    FirstName = "Quyen",
                    LastName = "Huynh",
                    Gender = "Female",
                    DOB = DateTime.Now.AddYears(-29).Date,
                    PhoneNumber = "0123456778",
                    BirthPlace = "Ho Chi Minh",
                    IsGraduated = true,
                    StartDate = DateTime.Now.AddDays(-15).Date,
                    EndDate = DateTime.Now.AddMonths(3).Date
                },
                new Member{
                    FirstName = "Dung",
                    LastName = "Que",
                    Gender = "Female",
                    DOB = DateTime.Now.AddYears(-29).Date,
                    PhoneNumber = "0124556778",
                    BirthPlace = "Ho Chi Minh",
                    IsGraduated = true,
                    StartDate = DateTime.Now.AddDays(-15).Date,
                    EndDate = DateTime.Now.AddMonths(3).Date
                },
                new Member{
                    FirstName = "Vi",
                    LastName = "Tran",
                    Gender = "Female",
                    DOB = DateTime.Now.AddYears(-29),
                    PhoneNumber = "0123496778",
                    BirthPlace = "Ho Chi Minh",
                    IsGraduated = true,
                    StartDate = DateTime.Now.AddDays(-15).Date,
                    EndDate = DateTime.Now.AddMonths(3).Date
                },
                new Member{
                    FirstName = "Dat",
                    LastName = "Nguyen",
                    Gender = "Male",
                    DOB = DateTime.Now.AddYears(-28).Date,
                    PhoneNumber = "0123498778",
                    BirthPlace = "Ho Chi Minh",
                    IsGraduated = true,
                    StartDate = DateTime.Now.AddDays(-15).Date,
                    EndDate = DateTime.Now.AddMonths(3).Date
                }
            };
        }
    }
}