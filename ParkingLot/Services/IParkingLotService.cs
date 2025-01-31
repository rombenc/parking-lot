using ParkingLot.Models;

namespace ParkingLot.Services;

public interface IParkingLotService
{
    string Park(string registrationNumber, string color, VehicleType type);
    string Leave(int slotNumber);
    void Status();
    int GetVehicleCountByType(VehicleType type);
    string GetRegistrationNumbersByPlateType(bool isOdd);
    string GetRegistrationNumbersByColor(string color);
    string GetSlotNumbersByColor(string color);
    string GetSlotNumberByRegistrationNumber(string registrationNumber);
    int GetOccupiedSlotCount();
    int GetAvailableSlotCount();
        
}