using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IBoatRentData
    {
        Task<IEnumerable<BoatRentModel>> GetBoatRentals();
        Task<BoatRentModel?> GetBoatLastRented(int bookingNr);
        Task InsertBoatRent(BoatRentModel boatRent);
        Task InsertBoatReturn(int boatNr);
    }
}