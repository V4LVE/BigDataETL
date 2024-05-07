namespace BigDataETL.Service.DTOs
{
    public class FlightsModelDTO
    {
        public int time { get; set; }
        public List<List<object>> states { get; set; }
    }
}
