namespace TravelApp.Models
{
    public class DropDownModel
    {
        public int OrderId { get; set; }
        public int clientId { get; set; }
        public List<Сlient> сlients { get; set; }
        public int hotelId { get; set; }
        public List<Hotel> hotels { get; set; }
        public int tourPackageId { get; set; }
        public List<TourPackage> tourPackages { get; set; }
    }
}
