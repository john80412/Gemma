﻿using Gemma.ViewModel;
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
        public IPagedList<MemberViewModel> GetSearchMember(string userName, int page)
        {
            var currentPage = page;
            var members = from m in db.AspNetUsers
                          select new MemberViewModel
                          {
                              Id = m.Id,
                              UserName = m.UserName,
                              PhoneNumber = m.PhoneNumber,
                              Email = m.Email,
                              Address = m.Address
                          };
            members = !string.IsNullOrEmpty(userName) ? members.Where((m) => m.UserName.ToUpper().Contains(userName.ToUpper())) : members;
            var results = members.OrderBy(m => m.Id).ToPagedList(currentPage, 10);
            return results;
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
                Address = member.Address
            };
            return result;
        }
        public void EditMember(MemberViewModel member)
        {
            var result = db.AspNetUsers.Find(member.Id);
            result.PhoneNumber = member.PhoneNumber;
            result.Address = member.Address;
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