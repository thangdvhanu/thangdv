using System.Collections.Generic;

namespace WebAPI.BusinessLogics
{
    public interface IMemberHandler
    {
        //1. Return list member who is male//
        List<Member> FilterMemberByGender(string gender);
        //2. Return the oldest one//
        Member ReturnTheOldestMember();
        //3. Return FullName of member//
        List<string> GetMemberWithFullNameOnly();
        //4.1 Return list of member who has birth year is 2000//
        List<Member> FilterMemberByBirthYear(int year);
        //4.2 Return list of member who has birth year greater than 2000
        List<Member> FilterMemberByBirthYearGreaterThan(int year);
        //4.3 Return list of member who has birth year less than 2000
        List<Member> FilterMemberByBirthYearLessThan(int year);
        //5. Return list members who born in HN//
        List<Member> FilterMemberByBirthPlace(string place);
        //6. Add new member to class
        List<Member> AddNewMember(Member member);
    }
}