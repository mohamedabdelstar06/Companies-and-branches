namespace ZAD.Application.DTOs.VehicleRental.RentalVehicle
{
    public class RentalVehicleDropdownDto
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string PlateNo { get; set; } = string.Empty;
        public int ModelYear { get; set; }
        public string FileNo { get; set; } = string.Empty;
        public int KilometerCounter { get; set; }
        
        public int Type { get; set; }
        public string TypeName { get; set; } = string.Empty;
        
        public decimal HourlyRentPrice { get; set; }
        public decimal DailyRentPrice { get; set; }
        public decimal WeeklyRentPrice { get; set; }
        public decimal MonthlyRentPrice { get; set; }
        public decimal YearlyRentPrice { get; set; }
        
        public bool IsRented { get; set; }
        public int? CurrentContractId { get; set; }
        public string? CurrentContractReferenceNo { get; set; }
    }
}
