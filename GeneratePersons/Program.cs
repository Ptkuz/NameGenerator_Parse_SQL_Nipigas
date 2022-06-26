using GeneratePersons;
using Microsoft.Data.SqlClient;

try
{
    List<FakeIdentity> peoples = await DataOperations.GetData();
    peoples = await DataOperations.AddDataToDB(peoples);
    await DataOperations.ChangeGUID(peoples);
    DataOperations.ViewList(peoples);
}

catch (HttpRequestException)
{
    Console.WriteLine("Проблема с сетевым подключением или сайтом генерирования личностей!");
}

catch (SqlException)
{
    Console.WriteLine("Проблема с подключением к базе данных!");
}
catch (Exception)
{
    Console.WriteLine("Непредвиденная ошибка!");
}







