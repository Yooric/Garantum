using BoatRentingApi.BusinessLogic;
using BoatRentingApi.Controllers;
using DataAccess.DbAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IBoatCategoryData, BoatCategoryData>();
builder.Services.AddSingleton<IBoatRentData, BoatRentData>();
builder.Services.AddSingleton<IBusinessLogic, BusinessLogic>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureBoatRentApi();
app.ConfigureBoatCategoryApi();

app.Run();

//TODO
//L�gg till logging
//Spara ner n�r man hyrt ut en b�t. Vad det kostade och vad f�r variabler som anv�ndes f�r att r�kna ut det.
//B�tar har sj�lvklart en egen tabell
//timpris och grundavgift in i databasen d�r man kan l�gga till ett slutdatum. Bra f�r bokf�ring.
//Deletecategory ska bara vara en archive.
//Fixa alla queries i samma DB call. Detta l�ser BoatReturnAndCalculatePrice's problem med om den inte passerar senare checkar.
//Allm�n verifiering av data som kommer in.
