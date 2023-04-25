using Microsoft.AspNetCore.Mvc;
using Yeremenko_HW5.Models;

namespace Yeremenko_HW5.Controllers
{
    public class FriendController : Controller
    {
        // GET: FriendController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: FriendController/Find/5
        [ActionName("Find")]
        public ActionResult GetFriendById(int id)
        {
            ViewBag.Id = id;    
            return View("GetFriendById");
        }

        // GET: FriendController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendController/Create
        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            if (ModelState.IsValid)
            {
                if (Friend.friendsList.Find(x => x.Id == friend.Id)?.Id is null)
                {
                    Friend.friendsList.Add(friend);
                    ViewBag.Operation = "Create";
                    ViewBag.Message = $"The Friend with ID={friend.Id}: {friend.Name} ({friend.Place}) was created";
                    return View("OperationResult");
                }
                else {
                    return BadRequest();
                    }
            }
            return View("Create");
        }

        // GET: FriendController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: FriendController/Edit/5
        [HttpPost]
        public ActionResult Edit(Friend friend)
        {
            if (ModelState.IsValid)
            {
              
                Friend fr = Friend.friendsList.Find(x => x.Id == friend.Id);
                ViewBag.Operation = "Edit";
                ViewBag.Message = $"The Friend with ID = {friend.Id} was edited. Name was changed from {fr?.Name} to {friend.Name}. " +
                    $"Place was changed from {fr?.Place} to {friend.Place}";
                fr.Name = friend.Name;
                fr.Place = friend.Place;
                return View("OperationResult");
            }
            else {
                return BadRequest();
            }
            
        }

        // GET: FriendController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: FriendController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Friend friend = Friend.friendsList.Find(x => x.Id == id);
            Friend.friendsList.Remove(friend);
            ViewBag.Operation = "Delete";
            ViewBag.Message = $"The Friend with ID={id} was deleted";
            return View("OperationResult");
        }
    }
}
