namespace UtilitiesProject.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid UtilityID { get; set; }
        public double Amount { get; set; }
        public int Paid { get; set; }


    }
}
