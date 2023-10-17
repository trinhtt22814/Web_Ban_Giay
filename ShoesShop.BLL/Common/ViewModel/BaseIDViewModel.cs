namespace ShoesShop.BLL.Common.ViewModel
{
    public class BaseIDViewModel
    {
        public Guid ID { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public int Status { get; set; }
    }
}