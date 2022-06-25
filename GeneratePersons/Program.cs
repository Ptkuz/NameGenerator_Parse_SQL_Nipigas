using GeneratePersons;
using Microsoft.Data.SqlClient;

try
{
    List<FakeIdentity> peoples = await GetDataForSite.GetData();
    peoples = await GetDataForSite.AddDataToDB(peoples);
    await GetDataForSite.ChangeGUID(peoples);
    GetDataForSite.ViewList(peoples);
}

catch (HttpRequestException)
{
    Console.WriteLine("Проблема с с сетевым подключением или сайтом генерирования личностей!");
}

catch (SqlException)
{
    Console.WriteLine("Проблема с подключением к базе данных!");
}
catch (Exception)
{
    throw;
}







