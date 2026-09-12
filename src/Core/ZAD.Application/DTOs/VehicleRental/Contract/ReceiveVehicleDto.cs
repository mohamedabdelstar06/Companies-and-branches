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
        public decimal AccidentPenaltyAmount { get; set; }
        public decimal MaintenancePaidByTenant { get; set; }
        public decimal ReceiveDiscountAmount { get; set; }
        public bool IsMaintenanceDoneByTenant { get; set; }
        
        public ZAD.Domain.Enums.VehicleRental.MaintenanceType? MaintenanceType { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public int? MaintenanceKM { get; set; }
        public string? MaintenanceNote { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }
        public int? NextMaintenanceKM { get; set; }

        public ZAD.Domain.Enums.VehicleRental.VehicleReceivingStatus? VehicleReceivingStatus { get; set; }
        public bool IsVehicleStoppedUntilMaintenanceOrRepair { get; set; }
        public string? DamageNote { get; set; }
    }
}
