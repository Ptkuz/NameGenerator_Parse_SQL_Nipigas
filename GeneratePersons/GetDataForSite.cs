using HtmlAgilityPack;
using Microsoft.Data.SqlClient;

namespace GeneratePersons
{
    public static class GetDataForSite
    {
        private static int count = 1;
        public static async Task<List<FakeIdentity>> GetData()
        {
            Console.WriteLine("!!!ГЕНЕРИРОВАНИЕ ЛИЧНОСТЕЙ И ЗАПИСЬ В КОЛЛЕКЦИЮ LIST И БАЗУ ДАННЫХ!!!");

            try
            {
                await Clear();
                // throw new HttpRequestException();
                Console.WriteLine();
                Console.WriteLine("Получение данных с сайта генерирование личностей");

                List<FakeIdentity> fakeIdentities = new List<FakeIdentity>();

                for (int i = 0; i < 20; i++)
                {
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument document = web.Load("https://www.fakenamegenerator.com/");

                    string address_part1 =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[1]/div/text()[1]").First().InnerText;
                    string address_part2 =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[1]/div/text()[2]").First().InnerText;
                    string country_code = document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[5]/dd/text()").First().InnerText;
                    string birthday = document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[6]/dd/text()").First().InnerText;

                    string age =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[7]/dd/text()").
                        First().InnerText;
                    int age_result;
                    int.TryParse(string.Join("", age.Where(c => char.IsDigit(c))), out age_result);

                    string cvc2 = document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[16]/dd/text()").First().InnerText;


                    FakeIdentity identity = new FakeIdentity()
                    {
                        PersonName =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[1]/h3").First().InnerText,
                        Addres = address_part1.TrimStart() + address_part2,
                        MothersMaidenName =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[1]/dd/text()").First().InnerText,
                        Ssn =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[2]/dd/text()").First().InnerText,
                        GeoCoordinates =
                        document.DocumentNode.SelectNodes("//*[@id=\"geo\"]").First().InnerText,
                        Phone =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[4]/dd/text()").First().InnerText,
                        CountryCode = Int32.Parse(country_code),
                        Birthday = DateTime.Parse(birthday),

                        Age = age_result,
                        TropicalZodiac =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[8]/dd/text()").First().InnerText,
                        Email =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[9]/dd/text()").First().InnerText,
                        UserName =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[10]/dd/text()").First().InnerText,
                        Password =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[11]/dd/text()").First().InnerText,
                        Website =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[12]/dd/text()").First().InnerText,
                        MasterCard =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[14]/dd/text()").First().InnerText,
                        Expires =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[15]/dd/text()").First().InnerText,
                        Cvc2 = Int32.Parse(cvc2),

                        Company =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[17]/dd/text()").First().InnerText,
                        Occupation =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[18]/dd/text()").First().InnerText,
                        Height =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[19]/dd/text()").First().InnerText,
                        Weight =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[20]/dd/text()").First().InnerText,
                        BloodType =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[21]/dd/text()").First().InnerText,
                        FavoriteColor =
                        document.DocumentNode.SelectNodes("//*[@id=\"details\"]/div[2]/div[2]/div/div[2]/dl[25]/dd/text()").First().InnerText
                    };

                    fakeIdentities.Add(identity);
                    Console.WriteLine($"Получены данные для личности {count++}");
                }

                Console.WriteLine();
                Console.WriteLine("Данные для всех 20 личностей получены и добавлены в коллекцию List");

                return fakeIdentities;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static async Task<List<FakeIdentity>> AddDataToDB(List<FakeIdentity> peoples)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Заполнение таблицы базы данных из коллекции List");
                Console.WriteLine();
                int count = 0;
                using (NipigasDBContext db = new NipigasDBContext())
                {
                    for (int i = 0; i < peoples.Count; i++)
                    {
                        db.Add(peoples[i]);
                        Console.WriteLine($"Добавление записи {i}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Данные успешно добавлены в БД!");
                    await db.SaveChangesAsync();

                    Console.WriteLine();
                    Console.WriteLine("Установка ID для элементов коллекции List из базы данных");
                    Console.WriteLine();
                    var dbItems = db.NameGenerators;
                    foreach (var item in dbItems)
                    {
                        Console.WriteLine($"Установка ID для элемента List {count}");
                        peoples[count].Id = item.Id;
                        count++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Установка ID в коллекцию List прошла успешно!");
                }
                return peoples;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task ChangeGUID(List<FakeIdentity> nameGenerators)
        {
            try
            {
                int count = 0;
                Console.WriteLine();
                Console.WriteLine("Установка GUID личностей");
                Console.WriteLine();
                using (NipigasDBContext db = new NipigasDBContext())
                {
                    var people = db.NameGenerators.ToList();
                    foreach (var item in nameGenerators)
                    {
                        Console.WriteLine($"Установка GUID для записи {count}");
                        item.Guid = Guid.NewGuid().ToString();
                        people[count].Guid = item.Guid;
                        count++;
                    }
                    await db.SaveChangesAsync();
                    Console.WriteLine();
                    Console.WriteLine("GUID для всех записей успешно установлен");
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task Clear()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Провека, заполнена ли таблица базы данных значениями");
                using var db = new NipigasDBContext();
                var person = db.NameGenerators.FirstOrDefault();

                if (person is not null)
                {
                    var persons = db.NameGenerators;
                    Console.WriteLine("Таблица уже заполнена. Удаление данных из таблицы");
                    db.RemoveRange(persons);
                    await db.SaveChangesAsync();
                    Console.WriteLine("Удаление данных происхошло успешно");
                }
                else
                    Console.WriteLine("Таблица не заполнена");
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public static void ViewList(List<FakeIdentity> nameGenerators)
        {
            try
            {
                Console.WriteLine();
                int count = 0;
                using var db = new NipigasDBContext();
                var people = db.NameGenerators.ToList();
                foreach (var person in nameGenerators)
                {
                   
                    Console.WriteLine($"Объект из List с именем {person.PersonName}: " +
                        $"'ID' {person.Id} == {people[count].Id} из базы данных, 'GUID' -- {person.Guid} == {people[count].Guid} из базы данных");
                    count++;
                }
                Console.WriteLine();
                Console.WriteLine("Данные успешно выгружены!");
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
