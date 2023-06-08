namespace EasyCash.Entities.Concrete
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal AccountBalance { get; set; }
        public string BankBranch { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<CustomerAccountProcess> CustomerSender { get; set; }
        public List<CustomerAccountProcess> CustomerReceiver { get; set; }
    }
}
