using System;
using System.Collections.Generic;


namespace TrafficApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle tempVehicle;
            int semiCount = 0;
            int minivanCount = 0;
            int compactCount = 0;
            int motorcycleCount = 0;
            int sedanCount = 0;
            int pickupCount = 0;
            TrafficBuilder builder = new TrafficBuilder(2, 65, 50);
            List<Vehicle> vehicles = builder.GetVehicles();
            Vehicle[] traffic = vehicles.ToArray();
            for(int i = 0; i < traffic.Length; i++)
            {
                tempVehicle = traffic[i];
                if(tempVehicle.GetVehicleType() == Type.COMPACT)
                {
                    compactCount++;
                }
                else if(tempVehicle.GetVehicleType() == Type.SEDAN)
                {
                    sedanCount++;
                }
                else if (tempVehicle.GetVehicleType() == Type.MINIVAN)
                {
                    minivanCount++;
                }
                else if (tempVehicle.GetVehicleType() == Type.PICKUP)
                {
                    pickupCount++;
                }
                else if (tempVehicle.GetVehicleType() == Type.SEMI)
                {
                    semiCount++;
                }
                else
                {
                    motorcycleCount++;
                }


            }

            Console.WriteLine(traffic.Length + " Vehicles");
            Console.WriteLine(semiCount + " Semis");
            Console.WriteLine(sedanCount + " Sedans");
            Console.WriteLine(compactCount + " Compacts");
            Console.WriteLine(minivanCount + " Vans");
            Console.WriteLine(pickupCount + " Pickups");
            Console.WriteLine(motorcycleCount + " Motorcycles");
            Console.Read();
        }
    }
}
