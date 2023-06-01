namespace DataAccess.Models
{
    public class BoatRentModel
    {
        public int BookingNr { get; set; }
        public int BoatNr { get; set; }
        public long PersonNr { get; set; }
        public int BoatCategory { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime? RentedTo { get; set; }
    }
}
