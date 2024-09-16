namespace OnlineShopAPI.Models
{
    public class ProductoDesiredDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public UserResponse User { get; set; }
    }

    public class UserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
