namespace EasyCash.Entities.Concrete
{
    public class CustomerAccountProcess
    {
        public int Id { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public CustomerAccount SenderCustomer { get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }

    }
}
