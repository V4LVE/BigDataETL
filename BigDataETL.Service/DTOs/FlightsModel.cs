namespace BigDataETL.Service.DTOs
{
    public class FlightsModel
    {
        public int time { get; set; }
        public List<List<object>> states { get; set; }
    }
}
