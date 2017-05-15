using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    interface Konzern
    {
        string Name { get; }
        void ConfirmBooking();
    }
    class Guest : Konzern
    {
        private string full_name;

        public Guest(string guest_name)
        {
            full_name = guest_name;
            if (full_name.Length <= 0) throw new ArgumentException("We kindly ask you to enter your valid name.\n");
            full_name = guest_name;
        }
        Boolean isBooked { get; set; } = false;

        #region Konzern implementation

        public string Name => full_name;

        public void ConfirmBooking()
        {
            if (isBooked) Console.WriteLine("Ihre Buchung ist nicht vorhanden!\n");
            Console.WriteLine($"Der Mr./Ms.{full_name} hereby we confirm your reservation!\n");
            isBooked = true;
        }

        #endregion
    }
    class Hotel : Konzern
    {
        private double price;
        private int days;

        public Hotel(double NewPrice, string HotelName, int DaysCount)
        {
            if (NewPrice < 80) throw new ArgumentException("Price must be above 80 USD!\n");
            Description = HotelName;
            days = DaysCount;
            price = NewPrice;
        }

        public string Description { get; private set; }
        public string HotelName { get; }

        public double ChargeAmount(int price_amount, int stay)
        {
            price = price_amount;
            days = stay;
            return price = price * days;
        }

        #region Konzern implementation

        public void ConfirmBooking()
        {
            Console.WriteLine($"We are confirming your stay at the beautiful {Description}!\nYour booking covers a total amount of {price}USD.\n");
        }

        public string Name => Description;

        #endregion

        public static void Main(string[] args)
        {
            //Add Task2:
            //Hotel c = new Hotel(70.00, "Motel One", 7); /*Object can't be generated and therefore an error message will be dumped*/
            //Console.WriteLine($"Ihre Reservierung im {b.Description} wurde bestätigt.\nPreis pro Nacht: {b.price}EUR ||  Anzahl der Tage: {b.days} \n");
            // Console.WriteLine($"Der Gesamtpreis für ihren Aufenthalt umfasst somit: {b.ChargeAmount()}EUR\n");

            var ValidEntries = new Konzern[]
            {
                new Hotel(120.80, "Hotel Sacher", 4),
                new Hotel(280.00, "Hotel Imperial", 2),
                new Hotel(320.00, "Marriott International Hotel", 8),
                new Hotel(480.00, "Sheraton Grand Hotel", 4),
                new Guest ("David"),
                new Guest ("James"),
            };
            foreach (var i in ValidEntries)
            {
                i.ConfirmBooking();
            }
        }
    }
}
