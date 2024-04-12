namespace OnlineShop.Web.Utility
{
    public class SD
    {
        public static string DiscountAPIBase { get; set; }
        public enum ApiType
        {
            GET, 
            POST, 
            PUT, 
            DELETE
        }
    }
}
