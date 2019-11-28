using Gemma.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gemma.Repository
{
    public class MemberRepository
    {
        public GemmaDBContext db = new GemmaDBContext();
        public bool IsSuccess;

        public IPagedList<MemberViewModel> GetSearchMember(string Id, int page)
        {
            var currentPage = page < 1 ? 1 : page;
            var members = from m in db.AspNetUsers.Include(m => m.Id)
                          select new MemberViewModel
                          {
                              Id = m.Id,
                              UserName = m.UserName,
                              PhoneNumber = m.PhoneNumber,
                              Email = m.Email
                          };
            if(!string.IsNullOrEmpty(Id))
            {
                members = members.Where((m) => m.Id == Id);
            }

            var results = members.OrderBy(m => m.Id).ToPagedList(currentPage, 10);
            return results;
        }

        //public List<MemberViewModel> GetAllMembers()
        //{
        //    var result = from member in db.AspNetUsers
        //                 select new MemberViewModel
        //                 {
        //                     Id = member.Id,
        //                     UserName = member.UserName,
        //                     Email = member.Email,
        //                     PhoneNumber = member.PhoneNumber,
        //                 };
        //    return result.ToList();
        //}
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
                PhoneNumber = member.PhoneNumber
            };
            return result;
        }

        //public void CreatMember(MemberViewModel member)
        //{
            //var result = db.AspNetUsers.Find(member.Id, member.UserName, member.Email, member.PhoneNumber);
            //if(result != null)
            //{
            //    IsSuccess = false;
            //    return;
            //}

            //IsSuccess = true;
        //    var data = new AspNetUser
        //    {
        //        Id = member.Id,
        //        UserName = member.UserName,
        //        Email = member.Email,
        //        PhoneNumber = member.PhoneNumber
        //    };

        //    db.AspNetUsers.Add(data);
        //    db.SaveChanges();
        //}

        public void EditMember(MemberViewModel member)
        {
            var result = db.AspNetUsers.Find(member.Id);
            result.PhoneNumber = member.PhoneNumber;
            db.Entry(result).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteMember(string id)
        {
            var result = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(result);
            db.SaveChanges();
        }
    }
}   