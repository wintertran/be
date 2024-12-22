namespace be.Models
{
    public class PagingRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 12; // Default 12 items per page
    }
}
