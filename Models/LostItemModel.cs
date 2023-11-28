namespace LostnFound.Models
{
    public class LostItemModel
    {
        // primary key
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords
        public string Email { get; set; }
    }
}
