using System.Collections.Generic;
using System.Linq;
using LostnFound.Models;

public class LostItemService
{
    private readonly LostnFoundContext _context;

    public LostItemService(LostnFoundContext context)
    {
        _context = context;
    }

    public IEnumerable<LostItemModel> GetAllItems()
    {
        // Fetch all items where IsClaimed is false
        return _context.LostItems.Where(item => !item.IsClaimed).ToList();
    }

    public IEnumerable<LostItemModel> GetItemsForUser(int userId)
    {
        // Fetch all items where OwnerId is the same as the provided userId
        return _context.LostItems.Where(item => item.OwnerId == userId).ToList();
    }
}
