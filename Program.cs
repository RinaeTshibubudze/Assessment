using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    class Program
    {
        static int Main(string[] args)
        {
            var properties = GetAllProperties();
            if (SaveToDb(properties))
                Console.WriteLine("done");
            else
                Console.WriteLine("there was a problem");

            return 0;

        }

        public static bool SaveToDb(IEnumerable<Property> properties)
        {
            foreach (var property in properties)
            {
                string connectionString = "Data Source = (local): Initial Catalog = MyDb; Integrated Security = true";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert into Property values(" + property.ToSqlForInsert() + ")";
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            return true;
        }

        private static IEnumerable<Property> GetAllProperties()
        {
            List<Property> properties = new List<Property>();

            var dataPath = "Properties.csv";
            var delimiter = '\t';

            var extractor = new Extractor(dataPath);

            foreach (var row in extractor.readRow(true))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var p = PropertyBuilder.BuildProperty(row, delimiter);

                    properties.Add(p);
                }
            }

            return properties.Distinct(new ListingEqualityComparer());

        }

    }

    public class ListingEqualityComparer : IEqualityComparer<Property>
    {
        public bool Equals(Property x, Property y)
        {
            return x.ListingNumber == y.ListingNumber;
        }

        public int GetHashCode(Property obj)
        {
            return obj.ListingNumber.GetHashCode();
        }
    }
}
