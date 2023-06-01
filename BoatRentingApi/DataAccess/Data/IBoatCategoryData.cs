using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IBoatCategoryData
    {
        Task DeleteBoatCategory(int id);
        Task<BoatCategoryModel?> GetBoatCategory(int id);
        Task<IEnumerable<BoatCategoryModel>> GetBoatCategories();
        Task InsertBoatCategory(BoatCategoryModel boatCategory);
        Task UpdateBoatCategory(BoatCategoryModel boatCategory);
    }
}