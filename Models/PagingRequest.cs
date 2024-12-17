namespace be.Models
{
    public class PagingRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 20; // Default 20 items per page
    }
}
