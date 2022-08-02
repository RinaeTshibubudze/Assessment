namespace Assessment
{
    public class Property
    {
        public int ListingNumber { get; set; }
        public decimal Latitude { get; set; }
        public float Longitude { get; set; }
        public float ListPrice { get; set; }


        public Property(int listingNumber, decimal latitude, float longitude, float listPrice)
        {
            ListingNumber = listingNumber;
            Latitude = latitude;
            Longitude = longitude;
            ListPrice = listPrice;
        }

        internal string ToSqlForInsert()
        {
            return ListingNumber + "," + Latitude + "," + Longitude + "," + ListPrice;
        }
    }
}