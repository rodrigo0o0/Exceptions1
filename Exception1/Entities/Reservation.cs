using Exception1.Entities.Exceptions;
using System;

namespace Exception1.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }


        public Reservation()
        {
        }

        public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
        {
            if (checkin < DateTime.Now || checkout < DateTime.Now)
            {
                throw new DomainException("Reservation dates for update must be future dates.");
            }
            if (checkout <= checkin)
            {
                throw new DomainException("Check-out must be after check-in date.");
            }

            RoomNumber = roomNumber;
            Checkin = checkin;
            Checkout = checkout;

        }
        public int Duration()
        {
            TimeSpan diff = Checkout.Subtract(Checkin);
            return (int)diff.TotalDays;
        }
        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            if(checkin < DateTime.Now || checkout < DateTime.Now)
            {
                throw new DomainException("Reservation dates for update must be future dates.");
            }
            if(checkout <= checkin)
            {
                throw new DomainException("Check-out must be after check-in date.");
            }

            Checkin = checkin;
            Checkout = checkout;
        }

        public override string ToString()
        {
            return $"Reservation : Room {RoomNumber}, check-in : {Checkin.ToShortDateString()}, check-out: {Checkout.ToShortDateString()}, {Duration()} nights.";
        }
    }
}
