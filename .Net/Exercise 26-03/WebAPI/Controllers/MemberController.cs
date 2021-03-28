using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.BusinessLogics;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private IMemberHandler _memberHandler;
        public MemberController(IMemberHandler memberHandler)
        {
            _memberHandler = memberHandler;
        }
        [HttpGet]
        [Route("/api/memberbygender/{gender}")]
        public List<Member> FilterMemberByGender(string gender)
        {
            return _memberHandler.FilterMemberByGender(gender);
        }
        [HttpGet]
        [Route("/api/memberbybirthplace/{place}")]
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            return _memberHandler.FilterMemberByBirthPlace(place);
        }
        [HttpGet]
        [Route("/api/oldestmember")]
        public Member ReturnTheOldestMember()
        {
            return _memberHandler.ReturnTheOldestMember();
        }
        [HttpGet]
        [Route("/api/memberwithfullnameonly")]
        public List<string> GetMemberWithFullNameOnly()
        {
            return _memberHandler.GetMemberWithFullNameOnly();
        }
        [HttpGet]
        [Route("/api/memberbybirthyear/{year}")]
        public List<Member> FilterMemberByBirthYear(int year)
        {
            return _memberHandler.FilterMemberByBirthYear(year);
        }
        [HttpGet]
        [Route("/api/memberbybirthyeargreaterthan/{year}")]
        public List<Member> FilterMemberByBirthYearGreaterThan(int year)
        {
            return _memberHandler.FilterMemberByBirthYearGreaterThan(year);
        }
        [HttpGet]
        [Route("/api/memberbybirthyearlessthan/{year}")]
        List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            return _memberHandler.FilterMemberByBirthYearLessThan(year);
        }
        [HttpGet]
        [Route("/api/memberbygraduation/{isGraduated}")]
        public List<Member> FilterMemberByGraduation(bool isGraduated)
        {
            return _memberHandler.FilterMemberByGraduation(isGraduated);
        }
        [HttpPost]
        public List<Member> Post(Member member)
        {
            return _memberHandler.AddNewMember(member);
        }
        [HttpDelete]
        public List<Member> Delete(int index)
        {
            return _memberHandler.DeleteMember(index);
        }
    }
}
