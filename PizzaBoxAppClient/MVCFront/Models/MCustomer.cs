namespace MVCFront.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MCustomer
    {
        public string username { get; set; }

        public string password { get; set; }

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal PhoneNumber { get; set; }

        public string Address { get; set; }

        public decimal CardNumber { get; set; }

        public short CardExpDate { get; set; }

        public short CardCode { get; set; }
    }
}