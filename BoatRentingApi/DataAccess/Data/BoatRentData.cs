using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class BoatRentData : IBoatRentData
    {
        private readonly ISqlDataAccess _db;

        public BoatRentData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<BoatRentModel>> GetBoatRentals()
        {
            return _db.LoadData<BoatRentModel, dynamic>("dbo.spBoatRent_GetAll", new { });
        }

        public async Task<BoatRentModel?> GetBoatLastRented(int boatNr)
        {
            var results = await _db.LoadData<BoatRentModel, dynamic>("dbo.spBoatRent_Get", new { BoatNr = boatNr });

            return results.FirstOrDefault();
        }

        public Task InsertBoatRent(BoatRentModel boatRent)
        {
            return _db.SaveData("dbo.spBoatRent_Insert", new { boatRent.BoatNr, boatRent.PersonNr, boatRent.BoatCategory, boatRent.RentedFrom });
        }

        public Task InsertBoatReturn(int boatNr)
        {
            return _db.SaveData("dbo.spBoatRent_Update", new { boatNr });
        }
    }
}
