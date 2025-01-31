namespace ParkingLot.Models;

public class Vehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public VehicleType Type { get; set; }
    public DateTime CheckInTime { get; set; }
}