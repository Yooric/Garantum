namespace BoatRentingApi.BusinessLogic
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IBoatRentData _boatRentData;
        private readonly IBoatCategoryData _boatCategoryData;
        private readonly float _basePrice = 100;    //In i databas som man kan sätta slutdatum på.
        private readonly float _hourlyPrice = 10;    //In i databas som man kan sätta slutdatum på.
        public BusinessLogic(IBoatRentData boatRentData, IBoatCategoryData boatCategoryData)
        {
            _boatRentData = boatRentData;
            _boatCategoryData = boatCategoryData;
        }
        public async Task<float> BoatReturnAndCalculatePrice(int boatNr)
        {
            
            await _boatRentData.InsertBoatReturn(boatNr);

            var lastTimeBoatWasRented = await _boatRentData.GetBoatLastRented(boatNr);
            if (lastTimeBoatWasRented == null || lastTimeBoatWasRented.RentedTo == null)
            {
                return -1;
            }

            var boatCategory = await _boatCategoryData.GetBoatCategory(lastTimeBoatWasRented.BoatCategory);
            if (boatCategory == null)
            {
                return -1;
            }

            var timeRented =  (((DateTime)lastTimeBoatWasRented.RentedTo).Hour + 1) - lastTimeBoatWasRented.RentedFrom.Hour;
            var price = _basePrice * boatCategory.BasePrice + _hourlyPrice * boatCategory.HourlyPrice * timeRented;

            return price;
        }
    }
}
