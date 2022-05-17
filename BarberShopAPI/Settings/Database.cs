namespace BarberShopAPI.Settings
{
    public static class Database
    {
        private static readonly string connString = "Data Source = MSI; Initial Catalog = BarberShop; User = sa; Password = v473r10;";

        public static string ConnectionString { get { return connString; } }

        public static class Queries
        {

            public class Clients
            {
                private static readonly string get = @"SELECT * FROM Clients";
                
                private static readonly string getById = @"SELECT * FROM Clients WHERE Id = @Id";

                private static readonly string create = @"INSERT INTO Clients (Name, Phone, Email, Regular) VALUES (@Name, @Phone, @Email, @Regular)";
                
                private static readonly string update = @"UPDATE Clients SET Name = @Name, Phone = @Phone, Email = @Email WHERE Id = @Id";

                private static readonly string upgrade = @"UPDATE Clients SET Regular = 1 WHERE Id = @Id";

                private static readonly string delete = @"DELETE Clients WHERE Id = @Id";

                public static string Get { get { return get; } }
                public static string GetById { get { return getById; } }
                public static string Create { get { return create; } }
                public static string Update { get { return update; } }
                public static string Upgrade { get { return upgrade; } }
                public static string Delete { get { return delete; } }
            }

            public class Services
            {
                private static readonly string get = @"SELECT * FROM Services";

                private static readonly string add = @"INSERT INTO Services (Name, Price) VALUES (@Name, @Price)";

                private static readonly string updateName = @"UPDATE Services SET Name = @Name WHERE Id = @Id";
                
                private static readonly string updatePrice = @"UPDATE Services SET Price = @Price WHERE Id = @Id";

                private static readonly string delete = @"DELETE Services WHERE Id = @Id";

                public static string Get { get { return get; } }
                public static string Add { get { return add; } }
                public static string UpdateName { get { return updateName; } }
                public static string UpdatePrice { get { return updatePrice; } }
                public static string Delete { get { return delete; } }

            }

            public class Dates
            {
                private static readonly string get = @"SELECT * FROM Dates";

                private static readonly string create = @"INSERT INTO Dates (Client, Service, ExtraServices, Day, Hour) VALUES (@Client, @Service, @ExtraServices, @Day, @Hour)";

                public static readonly string update = @"UPDATE Dates SET Day = @Day, Hour = @Hour WHERE Id = @Id";

                public static readonly string delete = @"Delete Dates WHERE Id = @Id";

                public static string Get { get { return get; } }
                public static string Create { get { return create; } }
                public static string Update { get { return update; } }
                public static string Delete { get { return delete; } }
            }

        }
    }
}
