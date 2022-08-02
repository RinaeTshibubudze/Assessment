using System;

namespace Assessment
{
    public class PropertyBuilder
    {
        public static Property BuildProperty(string row, char delimiter)
        {
            if (String.IsNullOrWhiteSpace(row))
                throw new ArgumentNullException("Row");

            var data = row.Split(delimiter);

            var listingNumber = int.Parse(data[0]);
            var latitude = decimal.Parse(data[1]);
            var longitude = float.Parse(data[2]);
            var listPrice = float.Parse(data[3]);

            return new Property(listingNumber, latitude,longitude,listPrice);

        }
        
    }
}