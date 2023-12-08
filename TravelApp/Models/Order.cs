namespace TravelApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }
        public int TourPackageID { get; set; }
    }
}
