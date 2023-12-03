using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostnFound.Models;
using LostnFound.ViewModels;

public class LostItemController : Controller
{
    private readonly LostnFoundContext _dbContext;
    private readonly LostItemService _lostItemService;

    public LostItemController(LostItemService lostItemService, LostnFoundContext dbContext)
    {
        _lostItemService = lostItemService;
        _dbContext = dbContext;
    }

    public ActionResult AddItem()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddItem(AddItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Retrieve the user id from SessionStorage
            var userId = HttpContext.Session.GetInt32("UserId");

            if(!userId.HasValue)
            {
                return RedirectToAction("Login", "Auth");
            }

            // Create a new lost item
            var newItem = new LostItemModel
            {
                ItemName = model.ItemName,
                ItemDescription = model.ItemDescription,
                DateLost = model.DateLost,
                LocationLost = model.LocationLost,
                OwnerId = userId.Value,
            };

            // Save the new user to the database
            _dbContext.LostItems.Add(newItem);
            _dbContext.SaveChanges();
        }

        return RedirectToAction("MyItems", "LostItem");
    }

    public ActionResult ClaimItem()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ClaimItem(ClaimItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Retrieve the user id from SessionStorage
            var userId = HttpContext.Session.GetInt32("UserId");

            if(!userId.HasValue)
            {
                return RedirectToAction("Login", "Auth");
            }

        }

        return RedirectToAction("AllItems", "LostItem");
    }

    // Action to return the list of books
    public IActionResult AllItems()
    {
        // Retrieve the user id from SessionStorage
        var userId = HttpContext.Session.GetInt32("UserId");

        IEnumerable<LostItemModel> allItems = null;

        if (userId.HasValue)
        {
            allItems = _lostItemService.GetAllItems();
        }
        else
        {
            // Handle the case where userId is null (if needed)
            ModelState.AddModelError(string.Empty, "User ID is null");
            return RedirectToAction("Login", "Auth");
        }

        // Pass the list of items to the view
        return View(allItems);
    }

    // Action to return details of a specific book by id
    public IActionResult MyItems()
    {
        // Retrieve the user id from SessionStorage
        var userId = HttpContext.Session.GetInt32("UserId");

        IEnumerable<LostItemModel> myItems = null;

        if (userId.HasValue)
        {
            myItems = _lostItemService.GetItemsForUser(userId.Value);
        }
        else
        {
            // Handle the case where userId is null (if needed)
            ModelState.AddModelError(string.Empty, "User ID is null");
            return RedirectToAction("Login", "Auth");
        }

        // Pass the list of items to the view
        return View(myItems);
    }
}
