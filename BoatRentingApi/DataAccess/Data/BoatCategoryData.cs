using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class BoatCategoryData : IBoatCategoryData
    {
        private readonly ISqlDataAccess _db;

        public BoatCategoryData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<BoatCategoryModel>> GetBoatCategories()
        {
            return _db.LoadData<BoatCategoryModel, dynamic>("dbo.spBoatCategory_GetAll", new { });
        }

        public async Task<BoatCategoryModel?> GetBoatCategory(int id)
        {
            var results = await _db.LoadData<BoatCategoryModel, dynamic>("dbo.spBoatCategory_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public Task InsertBoatCategory(BoatCategoryModel boatCategory)
        {
            return _db.SaveData("dbo.spBoatCategory_Insert", new { boatCategory.Category, boatCategory.HourlyPrice, boatCategory.BasePrice });
        }

        public Task UpdateBoatCategory(BoatCategoryModel boatCategory)
        {
            return _db.SaveData("dbo.spBoatCategory_Update", boatCategory);
        }

        public Task DeleteBoatCategory(int id)
        {
            return _db.SaveData("dbo.spBoatCategory_Delete", new { Id = id });
        }
    }
}
