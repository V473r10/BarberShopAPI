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
                private static readonly string createClient = @"INSERT INTO Clients (Name, Phone, Email, Regular) VALUES (@Name, @Phone, @Email, @Regular)";

                public static string CreateClient { get { return createClient; } }
            }

            public class Services
            {
                private static readonly string getServices = @"SELECT * FROM Services";

                private static readonly string addService = @"INSERT INTO Services (Name, Price) VALUES (@Name, @Price)";

                public static string GetServices { get { return getServices; } }
                public static string AddService { get { return addService; } }

            }

            public class Dates
            {
                private static readonly string createDate = @"INSERT INTO Dates (Client, Service, ExtraServices, Day, Hour) VALUES (@Client, @Service, @ExtraServices, @Day, @Hour)";

                public static string CreateDate { get { return createDate; } }
            }

        }
    }
}
