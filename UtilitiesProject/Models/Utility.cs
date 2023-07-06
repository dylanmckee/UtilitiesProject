namespace UtilitiesProject.Models
{
    public enum Period
    {
        monthly, quarterly
    }
    public class Utility
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Amount { get; set; }
        public Period? Period { get; set; }

        public Utility()
        {
            this.Name = "Default";
        }
        public Utility(string name)
        {
            this.Name = name;
        }
        public Utility(string name, int amount, int id, Period period)
        {
            this.Name = name;
            this.Amount = amount;
            this.Id = id;
            this.Period = period;
        }

    }

}
