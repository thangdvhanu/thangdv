using System.Collections.Generic;

namespace MVC.Models
{
    public interface IMembersRepository
    {
        List<Member> GetListMembers();
        Member GetMemberByIndex(int index);
        void AddNewMember(Member member);
        void UpdateMember(Member member, int index);
        void DeleteMemberByIndex(int index);
        List<Member> GetListMembersByName(string name);
    }
}