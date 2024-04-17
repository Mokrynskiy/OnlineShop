﻿namespace OnlineShop.Web.Utility
{
    public class SD
    {
        public static string DiscountAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }
        public static string ProductCategoryAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TocenCookie = "JWTToken";
        public enum ApiType
        {
            GET, 
            POST, 
            PUT, 
            DELETE
        }
    }
}
