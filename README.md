# Garantum
Swagger som frontend.

-------------SETUP-----------------
Om det ska köras behöver du skapa en databas(jag använde sql) och sen publisha "BoatRentingDB"projektet till en databasserver som du har (För att publisha så högerklickar du på "BoatRentingDb" och klickar publish). 
Sen byta ut connectionstringen "Default" i appsettings.json till den connectionstring du får när du publishar. 
Kan fungera bäst om du bara byter ut Data source för det kan krångla om du tar det som Visual studio generar när den publishar för den lägger till massa mellanslag som inte får vara där ibland.


----------TESTFALL-------------------
För att göra testfallet "Registrera uthyrning av båt":
In på swagger och gå till Post /BoatRent.
-Ta bort bookingNr.
-Ta bort rentedTo i Json.
-Hitta på ett boatNr.
-Ta en boatCategory som du vill ha från "GET /BoatCategories"
-rentedFrom kan ändras till olika saker för olika tester.
{
  "boatNr": 4234,
  "personNr": 19900731,
  "boatCategory": 1,
  "rentedFrom": "2023-06-01T08:51:13.249Z"
}

Kan kolla så det ser bra ut i "GET /BoatRent"
För att testa så allt ser bra ut kan man gå in i databasen i visual studio och ta upp sin databas tabell och klicka "View Data" (klicka View sen Sql Server object explorer).


För att göra testfallet "Återlämning av båt": 
Använd "PUT /BoatReturn"
Skicka in "boatNr" som du använde i testfallet "Registrera uthyrning av båt".

Du får tillbaks summan som ska betalas.
Du kan se i "GET /BoatRent" att ett rentedTo datum är ifyllt.
