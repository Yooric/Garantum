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
//Lägg till logging
//Spara ner när man hyrt ut en båt. Vad det kostade och vad för variabler som användes för att räkna ut det.
//Båtar har självklart en egen tabell
//timpris och grundavgift in i databasen där man kan lägga till ett slutdatum. Bra för bokföring.
//Deletecategory ska bara vara en archive.
//Fixa alla queries i samma DB call. Detta löser BoatReturnAndCalculatePrice's problem med om den inte passerar senare checkar.
//Allmän verifiering av data som kommer in.
