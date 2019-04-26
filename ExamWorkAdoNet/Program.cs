using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using DbUp;
using System.Reflection;

namespace ExamWorkAdoNet
{
    class Program
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
        static void Main(string[] args)
        {
            //CheckMigrations();
            /* User user = new User
             {
                 Login = "den",
                 Password = "123"
             };*/

            /*using (var connection = new SqlConnection(_connectionString))
           {
               connection.Execute("insert into users values(@Id, @Login,@Password)", user);
           }*/
          /*  Country country = new Country
            {
                NameCountry = "CnhfyfGhjdthrf"
            };
            InsertCountry(country);
            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Execute("delete from countries where nameCountry = " + country.NameCountry,country);
              
            }*/

            // InsertCountry(country);

            /*  List<Country> countries = new List<Country>();
              using (var connection = new SqlConnection(_connectionString))
              {

                  ShowCountries(connection, countries);
              }


              City city = new City
              {
                  NameCity = "Нур-Султан",
                  CountryId = countries[0].Id
              };

              InsertCities(city);
              */


            /* List<City> cities = new List<City>();
             using (var connection = new SqlConnection(_connectionString))
             {

                 ShowCities(connection, cities);
             }

             Street street = new Street()
             {
                 NameStreet = "Бараева",
                 CityId = cities[0].Id
             };

             InsertStreets(street);*/

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Просмотр стран");
                Console.WriteLine("2) Добавление стран");
                int choice = int.Parse(Console.ReadLine());
                if(choice == 1) { 
                        Console.Clear();
                    List<Country> countries = new List<Country>();
                using (var connection = new SqlConnection(_connectionString))
                    {
                        ShowCountries(connection, countries);
                    }
                    Console.Clear();
                        for(int i = 0;i < countries.Count;i++)
                    {
                        Console.WriteLine(i + 1 + ") " + countries[i].NameCountry);
                    }
                    Console.WriteLine("1) Просмотр городов");
                    Console.WriteLine("2) Удаление страны ");
                    Console.WriteLine();
                    int choiceInCountries = int.Parse(Console.ReadLine());
                    if(choiceInCountries == 1)
                    {
                        Console.WriteLine("Выберите страну(номер страны): ");
                        int choiceCity = int.Parse(Console.ReadLine());
                        for (int i = 0; i < countries.Count; i++)
                        {
                          if(choiceCity - 1 == i)
                            {
                                Console.Clear();
                                Console.WriteLine("1) Просмотр городов");
                                Console.WriteLine("2) Удаление города");
                                Console.WriteLine("3) Добавление города");
                                choice = int.Parse(Console.ReadLine());

                                if(choice == 1)
                                {
                                    List<City> cities = new List<City>();
                                    using (var connection = new SqlConnection(_connectionString))
                                    {
                                        ShowCities(connection, cities);
                                    }
                                    Console.Clear();
                                    for (int j = 0; j < countries.Count; j++)
                                    {
                                        if(cities[j].CountryId == countries[i].Id)
                                        {
                                            Console.WriteLine(cities[j].NameCity);
                                            Console.WriteLine("Введите название города: ");
                                            string city = Console.ReadLine();


                                        }
                                    }
                                    Console.ReadLine();
                                }
                                else if(choice == 2)
                                {

                                    Console.WriteLine("Введите название города: ");
                                    string citiyDeleted = Console.ReadLine();
                                    List<City> cities = new List<City>();
                                    using (var connection = new SqlConnection(_connectionString))
                                    {
                                        ShowCities(connection, cities);
                                    }
                                    for (int j = 0; j < cities.Count; j++)
                                    {
                                        if ( citiyDeleted == cities[j].NameCity)
                                        {
                                          
                                            using (var connection = new SqlConnection(_connectionString))
                                            {
                                                DeleteCity(cities[j]);
                                            }

                                        }
                                    }
                                    Console.WriteLine("Удалино!");
                                    Console.ReadLine();

                                }
                                else if(choice == 3)
                                {
                                    Console.WriteLine("Введите название города: ");
                                    string nameCity = Console.ReadLine();

                                    City city = new City
                                    {
                                        NameCity = nameCity,
                                        CountryId = countries[i].Id
                                    };
                                    InsertCities(city);
                                    Console.WriteLine("Добавлен!");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                    else if(choiceInCountries == 2)
                    {
                        Console.WriteLine("Выберите страну(номер страны): ");
                        int choiceCity = int.Parse(Console.ReadLine());
                        for (int i = 0; i < countries.Count; i++)
                        {
                            if (choiceCity - 1 == i)
                            {
                                List<Country> countriesDeleted = new List<Country>();
                                using (var connection = new SqlConnection(_connectionString))
                                {
                                    ShowCountries(connection,countriesDeleted);

                                    DeleteCountry(countriesDeleted[i]);
                                }

                            }
                        }
                        Console.WriteLine("Удалино!");
                        Console.ReadLine();
                    }
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Введите название создоваемой страны: ");
                    string nameCountry = Console.ReadLine();

                    Country country = new Country
                    {
                        NameCountry = nameCountry
                    };
                    InsertCountry(country);
                    Console.Clear();
                    Console.WriteLine("Добавлена!");
                    Console.ReadLine();
                }

            }


        }

        private static void InsertCountry(Country country)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("insert into countries values(@Id,@NameCountry)", country);
            }
        }
        private static void DeleteCountry(Country country)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("delete from countries where id = "+ country.Id, country);
            }
        }private static void DeleteCity(City city)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("delete from cities where id = "+ city.Id, city);
            }
        }private static void DeleteStreet(Street street)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("delete from streets where id = "+ street.Id, street);
            }
        }
        private static void InsertCities(City city)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("insert into cities values(@Id,@NameCity,@CountryId)", city);
            }
        }
        private static void InsertStreets(Street street)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("insert into streets values(@Id,@NameStreet,@CityId)", street);
            }
        }

        private static void ShowCities(SqlConnection connection, List<City> cities)
        {
            string sql = "select* from cities";
            var sqlDataReader = connection.ExecuteReader(sql);
            while (sqlDataReader.Read())
            {
                Guid id = (Guid)sqlDataReader["Id"];
                string nameCity = sqlDataReader["NameCity"].ToString();
                Guid countryId = (Guid)sqlDataReader["CountryId"];
                cities.Add(new City
                {
                    Id = id,
                    NameCity = nameCity,
                    CountryId = countryId
                });
            }
            sqlDataReader.Close();

        }
        private static void ShowStreets(SqlConnection connection, List<Street> streets)
        {
            string sql = "select* from streets";
            var sqlDataReader = connection.ExecuteReader(sql);
            while (sqlDataReader.Read())
            {
                Guid id = (Guid)sqlDataReader["Id"];
                string nameStreet = sqlDataReader["NameStreet"].ToString();
                Guid cityId = (Guid)sqlDataReader["CityId"];
                streets.Add(new Street
                {
                    Id = id,
                    NameStreet = nameStreet,
                    CityId = cityId
                });
            }
            sqlDataReader.Close();

        }
        private static void ShowCountries(SqlConnection connection, List<Country> countries)
        {
            string sql = "select* from Countries";
            var sqlDataReader = connection.ExecuteReader(sql);
            while (sqlDataReader.Read())
            {
                Guid id = (Guid)sqlDataReader["Id"];
                string nameCountry = sqlDataReader["NameCountry"].ToString();
                
                countries.Add(new Country
                {
                    Id = id,
                  NameCountry = nameCountry
                });
            }
            sqlDataReader.Close();

        }

        private static void CheckMigrations()
        {
            EnsureDatabase.For.SqlDatabase(_connectionString);

            var upgrader = DeployChanges.To
           .SqlDatabase(_connectionString)
           .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
           .LogToConsole()
           .Build();

            var result = upgrader.PerformUpgrade();
            if (!result.Successful) throw new Exception("Ошибка соединения");
        }
    }
}
