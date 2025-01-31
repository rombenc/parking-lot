// Program.cs
using System;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            IParkingLotService parkingLot = null;

            while (true)
            {
                var command = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(command)) continue;

                var parts = command.Split(' ');
                
                try
                {
                    switch (parts[0].ToLower())
                    {
                        case "create_parking_lot":
                            int totalSlots = int.Parse(parts[1]);
                            parkingLot = new ParkingLotService(totalSlots);
                            Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                            break;

                        case "park":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            var result = parkingLot.Park(parts[1], parts[2], Enum.Parse<VehicleType>(parts[3]));
                            Console.WriteLine(result);
                            break;

                        case "leave":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.Leave(int.Parse(parts[1])));
                            break;

                        case "status":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            parkingLot.Status();
                            break;

                        case "type_of_vehicles":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.GetVehicleCountByType(Enum.Parse<VehicleType>(parts[1])));
                            break;

                        case "registration_numbers_for_vehicles_with_odd_plate":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.GetRegistrationNumbersByPlateType(true));
                            break;

                        case "registration_numbers_for_vehicles_with_even_plate":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.GetRegistrationNumbersByPlateType(false));
                            break;

                        case "registration_numbers_for_vehicles_with_colour":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.GetRegistrationNumbersByColor(parts[1]));
                            break;

                        case "slot_numbers_for_vehicles_with_colour":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.GetSlotNumbersByColor(parts[1]));
                            break;

                        case "slot_number_for_registration_number":
                            if (parkingLot == null)
                            {
                                Console.WriteLine("Please create parking lot first");
                                continue;
                            }
                            Console.WriteLine(parkingLot.GetSlotNumberByRegistrationNumber(parts[1]));
                            break;

                        case "exit":
                            return;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}