using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Repository
{
    public class MemberRepository
    {
        private GemmaDBContext db = new GemmaDBContext();
        public List<MemberViewModel> GetAllMembers()
        {
            var result = from member in db.AspNetUsers
                         select new MemberViewModel
                         {
                             Id = member.Id,
                             UserName = member.UserName,
                             Email = member.Email,
                             PhoneNumber = member.PhoneNumber,
                             LockoutEndDateUtc = member.LockoutEndDateUtc,
                             AccessFailedCount = member.AccessFailedCount
                         };
            return result.ToList();
        }
        public MemberViewModel GetMemberDetail(string id)
        {
            AspNetUser member = db.AspNetUsers.Find(id);
            if (member == null)
            {
                return null;
            }
            var result = new MemberViewModel
            {
                Id = member.Id,
                UserName = member.UserName,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                LockoutEndDateUtc = member.LockoutEndDateUtc,
                AccessFailedCount = member.AccessFailedCount
            };
            return result;
        }
    }
}