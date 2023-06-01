namespace BoatRentingApi.Controllers
{
    public static class BoatCategoryApi
    {
        public static void ConfigureBoatCategoryApi(this WebApplication app)
        {
            app.MapGet("/BoatCategories", GetBoatCategories);
            app.MapGet("/BoatCategories/{id}", GetBoatCategory);
            app.MapPost("/BoatCategories", InsertBoatCategory);
            app.MapPut("/BoatCategories", UpdateBoatCategory);
            app.MapDelete("/BoatCategories", DeleteBoatCategory);
        }

        private static async Task<IResult> GetBoatCategories(IBoatCategoryData data)
        {
            try
            {
                return Results.Ok(await data.GetBoatCategories());
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBoatCategory(int id, IBoatCategoryData data)
        {
            try
            {
                var result = await data.GetBoatCategory(id);
                if (result == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertBoatCategory(BoatCategoryModel boatCategory, IBoatCategoryData data)
        {
            try
            {
                await data.InsertBoatCategory(boatCategory);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateBoatCategory(BoatCategoryModel boatCategory, IBoatCategoryData data)
        {
            try
            {
                await data.UpdateBoatCategory(boatCategory);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteBoatCategory(int id, IBoatCategoryData data)
        {
            try
            {
                await data.DeleteBoatCategory(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                //log
                return Results.Problem(ex.Message);
            }
        }
    }
}
