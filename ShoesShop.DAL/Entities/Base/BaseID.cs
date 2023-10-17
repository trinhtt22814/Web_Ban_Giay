namespace ShoesShop.DAL.Entities.Base
{
    public class BaseID
    {
        public Guid ID { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int Status { get; set; }
    }
}