using System;

namespace LostnFound.Models
{
    public class LostItemModel
    {
        public int ItemId { get; set; }
        public int OwnerId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DateLost { get; set; }
        public string LocationLost { get; set; }
        public bool IsClaimed { get; set; }
        public int FinderId { get; set; }
        public DateTime DateFound { get; set; }
        public string LocationFound { get; set; }
        public string FinderContact { get; set; }
    }
}
