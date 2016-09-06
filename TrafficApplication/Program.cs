using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Vehicle> vehicles = builder.getVehicles();
            Vehicle[] traffic = vehicles.ToArray();
            for(int i = 0; i < traffic.Length; i++)
            {
                tempVehicle = traffic[i];
                if(tempVehicle.getType() == Type.COMPACT)
                {
                    compactCount++;
                }
                else if(tempVehicle.getType() == Type.SEDAN)
                {
                    sedanCount++;
                }
                else if (tempVehicle.getType() == Type.MINIVAN)
                {
                    minivanCount++;
                }
                else if (tempVehicle.getType() == Type.PICKUP)
                {
                    pickupCount++;
                }
                else if (tempVehicle.getType() == Type.SEMI)
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
