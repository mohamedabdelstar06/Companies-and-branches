using System;

namespace ZAD.Application.DTOs.VehicleRental.Contract
{
    public class ReceiveVehicleDto
    {
        public DateTime ReceivingDate { get; set; }
        public TimeSpan ReceivingTime { get; set; }
        public int ReceivingKilometerCounter { get; set; }
        public bool ReceiveProofDocuments { get; set; }
        public string? ReceiveNotes { get; set; }
        public decimal MaintenancePenaltyAmount { get; set; }
        public decimal AccidentPenaltyAmount { get; set; }
        public decimal MaintenancePaidByTenant { get; set; }
        public decimal ReceiveDiscountAmount { get; set; }
    }
}
