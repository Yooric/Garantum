using BoatRentingApi.BusinessLogic;

namespace BoatRentingApi.Controllers
{
    public static class BoatRentApi
    {
        public static void ConfigureBoatRentApi(this WebApplication app)
        {
            app.MapGet("/BoatRent", GetBoatRentals);
            app.MapPost("/BoatRent", InsertBoatRent);
            app.MapPut("/BoatReturn", InsertBoatReturn);
        }

        private static async Task<IResult> GetBoatRentals(IBoatRentData data)
        {
            try
            {
                return Results.Ok(await data.GetBoatRentals());
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertBoatRent(BoatRentModel boatRent, IBoatRentData data)
        {
            try
            {
                await data.InsertBoatRent(boatRent);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertBoatReturn(int boatNr, IBoatRentData data, IBusinessLogic businessLogic)
        {
            try
            {
                var price = await businessLogic.BoatReturnAndCalculatePrice(boatNr);

                return Results.Ok(price);
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }
    }
}
