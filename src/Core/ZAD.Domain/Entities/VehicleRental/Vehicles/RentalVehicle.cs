using ZAD.Domain.SeedWork;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Enums.VehicleRental;

namespace ZAD.Domain.Entities.VehicleRental.Vehicles
{
    public class RentalVehicle : Entity
    {
        public string Brand { get; private set; } = string.Empty;
        public string PlateNo { get; private set; } = string.Empty;
        public int ModelYear { get; private set; }
        public string FileNo { get; private set; } = string.Empty;
        public int KilometerCounter { get; private set; }
        
        public VehicleType Type { get; private set; }
        public decimal HourlyRentPrice { get; private set; }
        public decimal DailyRentPrice { get; private set; }
        public decimal WeeklyRentPrice { get; private set; }
        public decimal MonthlyRentPrice { get; private set; }
        public decimal YearlyRentPrice { get; private set; }
        
        public bool IsRented { get; private set; }



        private RentalVehicle() { } // EF Core

        public RentalVehicle(string brand, string plateNo, int modelYear, string fileNo, int kilometerCounter, VehicleType type, decimal hourlyRentPrice, decimal dailyRentPrice, decimal weeklyRentPrice, decimal monthlyRentPrice, decimal yearlyRentPrice, bool isRented = false)
        {
            Brand = brand;
            PlateNo = plateNo;
            ModelYear = modelYear;
            FileNo = fileNo;
            KilometerCounter = kilometerCounter;
            Type = type;
            HourlyRentPrice = hourlyRentPrice;
            DailyRentPrice = dailyRentPrice;
            WeeklyRentPrice = weeklyRentPrice;
            MonthlyRentPrice = monthlyRentPrice;
            YearlyRentPrice = yearlyRentPrice;
            IsRented = isRented;
        }

        public void Update(string brand, string plateNo, int modelYear, string fileNo, int kilometerCounter, 
            VehicleType type, decimal hourlyRentPrice, decimal dailyRentPrice, decimal weeklyRentPrice, decimal monthlyRentPrice, decimal yearlyRentPrice, bool isRented)
        {
            Brand = brand;
            PlateNo = plateNo;
            ModelYear = modelYear;
            FileNo = fileNo;
            KilometerCounter = kilometerCounter;
            Type = type;
            HourlyRentPrice = hourlyRentPrice;
            DailyRentPrice = dailyRentPrice;
            WeeklyRentPrice = weeklyRentPrice;
            MonthlyRentPrice = monthlyRentPrice;
            YearlyRentPrice = yearlyRentPrice;
            IsRented = isRented;
        }

        public void SetRentedStatus(bool isRented)
        {
            IsRented = isRented;
        }
    }
}
