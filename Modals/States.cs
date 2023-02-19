namespace World.Api.Modals
{
    public class States
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public int CoutryId { get; set; }
        public Country Country { get; set; }
    }
}
