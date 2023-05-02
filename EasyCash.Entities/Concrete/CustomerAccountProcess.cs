namespace EasyCash.Entities.Concrete
{
    public class CustomerAccountProcess
    {
        public int Id { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }

    }
}
