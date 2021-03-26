using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
namespace MVC.Controllers
{
    public class MembersController : Controller
    {
        private IMembersRepository members = new MembersRepository();
        public IActionResult Search(string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                return View("Index", members.GetListMembers());
            }
            List<Member> searched = members.GetListMembersByName(keyword);
            return View("Index", searched);
        }
        public IActionResult Index()
        {
            return View(members.GetListMembers());
        }
        public IActionResult Details(int? i)
        {
            if (!i.HasValue)
            {
                return View("Index", "Members");
            }
            Member member = members.GetMemberByIndex(i.Value);
            if (member == null)
            {
                return View("Index", "Members");
            }
            return View(member);
        }
        
        // [Authorize("Admin")]
        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if (!ModelState.IsValid || member == null)
            {
                return View("CreateForm");
            }
            members.AddNewMember(member);
            return View("Details", member);
        }

        // [Authorize("Admin")]
        public IActionResult UpdateForm(int? i)
        {
            if (!i.HasValue)
            {
                return RedirectToAction("Index", "Members");
            }
            Member member = members.GetMemberByIndex(i.Value);
            if (member == null)
            {
                return RedirectToAction("Index", "Members");
            }
            ViewBag.Index = i;
            return View(member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Member member, int index)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UpdateForm", "Members");
            }
            if (member == null)
            {
                return RedirectToAction("Index", "Members");
            }
            members.UpdateMember(member, index);
            Member memberEdited = members.GetMemberByIndex(index);
            return View("Details", member);
        }

        // [Authorize("Admin")]
        public IActionResult DeleteWarning(int? i)
        {
            if (!i.HasValue)
            {
                return RedirectToAction("Index", "Members");
            }
            Member member = members.GetMemberByIndex(i.Value);
            if (member == null)
            {
                return RedirectToAction("Index", "Members");
            }
            ViewBag.MemberIndexToDelete = i.Value;
            return View(member);
        }
        public IActionResult Delete(int? index)
        {
            if (!index.HasValue)
            {
                return RedirectToAction("Index", "Members");
            }
            members.DeleteMemberByIndex(index.Value);
            return RedirectToAction("Index", "Members");
        }

    }
}