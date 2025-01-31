// Services/ParkingLotService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using ParkingLot.Models;

namespace ParkingLot.Services
{

    public class ParkingLotService : IParkingLotService
    {
        private readonly List<ParkingSlot> slots;

        public ParkingLotService(int totalSlots)
        {
            slots = Enumerable.Range(1, totalSlots)
                .Select(i => new ParkingSlot { SlotNumber = i })
                .ToList();
        }

        public string Park(string registrationNumber, string color, VehicleType type)
        {
            var availableSlot = slots.FirstOrDefault(s => !s.IsOccupied);
            
            if (availableSlot == null)
                return "Sorry, parking lot is full";

            availableSlot.Vehicle = new Vehicle
            {
                RegistrationNumber = registrationNumber,
                Color = color,
                Type = type,
                CheckInTime = DateTime.Now
            };

            return $"Allocated slot number: {availableSlot.SlotNumber}";
        }

        public string Leave(int slotNumber)
        {
            var slot = slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
            if (slot == null || !slot.IsOccupied)
                return $"Slot number {slotNumber} is already empty";

            slot.Vehicle = null;
            return $"Slot number {slotNumber} is free";
        }

        public void Status()
        {
            Console.WriteLine("Slot No. Registration No Type Colour");
            foreach (var slot in slots.Where(s => s.IsOccupied))
            {
                Console.WriteLine($"{slot.SlotNumber} {slot.Vehicle.RegistrationNumber} {slot.Vehicle.Type} {slot.Vehicle.Color}");
            }
        }

        public int GetVehicleCountByType(VehicleType type)
        {
            return slots.Count(s => s.IsOccupied && s.Vehicle.Type == type);
        }

        public string GetRegistrationNumbersByPlateType(bool isOdd)
        {
            var vehicles = slots.Where(s => s.IsOccupied)
                .Select(s => s.Vehicle)
                .Where(v => {
                    var number = int.Parse(new string(v.RegistrationNumber.Where(char.IsDigit).ToArray()));
                    return isOdd ? number % 2 == 1 : number % 2 == 0;
                })
                .Select(v => v.RegistrationNumber);

            return string.Join(", ", vehicles);
        }

        public string GetRegistrationNumbersByColor(string color)
        {
            var vehicles = slots.Where(s => s.IsOccupied && s.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Vehicle.RegistrationNumber);
            return string.Join(", ", vehicles);
        }

        public string GetSlotNumbersByColor(string color)
        {
            var slotNumbers = slots.Where(s => s.IsOccupied && s.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.SlotNumber.ToString());
            return string.Join(", ", slotNumbers);
        }

        public string GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            var slot = slots.FirstOrDefault(s => s.IsOccupied && 
                s.Vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
            return slot != null ? slot.SlotNumber.ToString() : "Not found";
        }

        public int GetOccupiedSlotCount()
        {
            return slots.Count(s => s.IsOccupied);
        }

        public int GetAvailableSlotCount()
        {
            return slots.Count(s => !s.IsOccupied);
        }
    }
}