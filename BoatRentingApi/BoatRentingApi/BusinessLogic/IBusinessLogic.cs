namespace BoatRentingApi.BusinessLogic
{
    public interface IBusinessLogic
    {
        Task<float> BoatReturnAndCalculatePrice(int bookingNr);
    }
}