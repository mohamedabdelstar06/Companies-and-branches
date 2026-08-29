namespace ZAD.Domain.Enums.VehicleRental
{
    public enum VehicleReceivingStatus
    {
        PendingInspection = 1,
        UnderInspection = 2,
        Damaged = 3,
        Cleaned = 4,
        InRepair = 5,
        ReadyForRental = 6,
        NeedsCleaning = 7,
        Unclean = 8,
        Rented = 9
    }
}
