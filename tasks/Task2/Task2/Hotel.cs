using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Hotel
    {
        private double price;
        private int days;

        public Hotel(double NewPrice, string HotelName, string Concern, int DaysCount)
        {
            if (NewPrice < 80) throw new ArgumentException("Price must be above 80 USD!\n");
            Description = HotelName;
            CompanyName = Concern;
            days = DaysCount;
            price = NewPrice;
        }
        
        public string Description { get; }
        public string CompanyName { get; }

        public double ChargeAmount ()
        {    
            return price = price * days;     
        }
        public static void Main(string[] args)
        {     
            Hotel a = new Hotel(120.80, "Hotel Sacher", "Sacher Group", 4);
            Hotel b = new Hotel(280.00, "Hotel Imperial", "Marriott Hotels International", 2);
            //Hotel c = new Hotel(70.00, "Motel One", "Motel One Company", 7); /*Object can't be generated and therefore an error message will be dumped*/
            Console.WriteLine($"Ihre Reservierung im {b.Description} wurde bestätigt.\nPreis pro Nacht: {b.price}EUR ||  Anzahl der Tage: {b.days} \n");
            Console.WriteLine($"Der Gesamtpreis für ihren Aufenthalt umfasst somit: {b.ChargeAmount()}EUR\n");
        }
    }
}
