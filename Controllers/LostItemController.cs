using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostnFound.Models;

public class LostItemController : Controller
{
    private readonly LostItemService _lostItemService;

    public LostItemController(LostItemService lostItemService)
    {
        _lostItemService = lostItemService;
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
    public IActionResult MyItems(int id)
    {
        // Get lost items for user with the provided id
        var myItems = _lostItemService.GetItemsForUser(id);

        return View(myItems);
    }
}
