using System;

namespace MTPL_Insurance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input:
            Console.Write("Please enter Vehicle's type: ");
            string vehiclesType = Console.ReadLine();
            bool validVehicleType = false;

            while (!validVehicleType)
            {
                if ((vehiclesType == "motor") || (vehiclesType == "car") || (vehiclesType == "light truck") || (vehiclesType == "truck") || (vehiclesType == "microbus") || (vehiclesType == "bus") || (vehiclesType == "tractor") || (vehiclesType == "trailer"))
                {
                    validVehicleType = true;
                    break;
                }
                else
                {
                    Console.WriteLine("This is not a valid vehicle's type!");
                    Console.Write("Please enter a valid vehicle's type: ");
                    vehiclesType = Console.ReadLine();
                }
            }

            Console.Write("Please enter Vehicle's make: ");
            string vehiclesMake = Console.ReadLine();
            Console.Write("Please enter Vehicle's model: ");
            string vehiclesModel = Console.ReadLine();

            //Logic and additional input:

            double Premium = 0;
            string vehiclesEnginesType = String.Empty;
            double vehiclesKw = 0;
            int vehiclesVolume = 0;

            if (vehiclesType == "car" || vehiclesType == "motor")
            {
                Console.Write("Please enter Vehicle's engine type: ");
                vehiclesEnginesType = Console.ReadLine();
                if (vehiclesEnginesType == "electric")
                {
                    Console.Write("Please enter Vehicle's Kw: ");
                    vehiclesKw = double.Parse(Console.ReadLine());
                }
                else
                {
                    Console.Write("Please enter Vehicle's engine volume: ");
                    vehiclesVolume = int.Parse(Console.ReadLine());
                }
            }
            //else if (vehiclesType == "truck" || vehiclesType == "light truck")
            //{
            //    Console.Write("Please enter Vehicle's Weight in tones: ");
            //    double vehiclesWeight = double.Parse(Console.ReadLine());
            //}
            else if (vehiclesType == "microbus" || vehiclesType == "bus")
            {
                Console.Write("Please enter Vehicle's seats: ");
                int vehiclesSeats = int.Parse(Console.ReadLine());
            }
            else if (vehiclesType == "tractor")
            {
                Console.Write("Please enter Vehicle's Weight in tones: ");
                double vehiclesWeight = double.Parse(Console.ReadLine());
            }
            else if (vehiclesType == "trailer")
            {
                Console.Write("Please enter Trailer's length in meters: ");
                double trailersLength = double.Parse(Console.ReadLine());
            }

            //Tariff:

            double motorElectric55Tariff = 65; //up to 55 kw for electric motor only
            double motorElectricOver55Tariff = 85.50; // over 55 kw for electric motor only
            double motor75Tariff = 75; //up to 50 kb. cm.
            double motorOver75Tarif = 95.50; //over 50 kb cm.
            double carFullElectric82Tariff = 150; //up to 82 kw for full electric cars only
            double carFullElectricOver82Tariff = 350; //over 82 kw for full electric cars only
            double car1000Tariff = 190; //up to 1000 kb. cm. all engines except of full electric;
            double car1500Tariff = 290; //up to 1500 kb. cm. all engines except of full electric;
            double car2000Tariff = 340; //up to 2000 kb. cm. all engines except of full electric;
            double car3000Tariff = 390; //up to 3000 kb. cm. all engines except of full electric;
            double carOver3000Tariff = 490; //over 3000 kb. cm. all engines except of full electric;
            double lightTruck = 450; //for light trucks == trucks with weight in tones up to 3.5 t.
            double truck5 = 580; //for trucks with weight up to 5 t.
            double truck10 = 710; //for trucks with weight up to 10 t.
            double truck20 = 930; //for trucks with weight up to 20 t.
            double truckOver20 = 1500; //for trucks with weight over 20 t.

            //Calculations:

            if (vehiclesType == "car" || vehiclesType == "motor")
            {
                if (vehiclesEnginesType == "electric")
                {
                    if (vehiclesKw <= 55 && vehiclesType == "motor")
                    {
                        Premium += motorElectric55Tariff;
                    }
                    else if (vehiclesKw > 55 && vehiclesType == "motor")
                    {
                        Premium += motorElectricOver55Tariff;
                    }
                    else if (vehiclesKw <= 82 && vehiclesType == "car")
                    {
                        Premium += carFullElectric82Tariff;
                    }
                    else if (vehiclesKw > 82 && vehiclesType == "car")
                    {
                        Premium += carFullElectricOver82Tariff;
                    }
                }
                else
                {
                    if (vehiclesVolume <= 75 && vehiclesType == "motor")
                    {
                        Premium += motor75Tariff;
                    }
                    else if (vehiclesVolume > 75 && vehiclesType == "motor")
                    {
                        Premium += motorOver75Tarif;
                    }
                    else if (vehiclesVolume <= 1000 && vehiclesType == "car")
                    {
                        Premium += car1000Tariff;
                    }
                    else if (vehiclesVolume <= 1500 && vehiclesType == "car")
                    {
                        Premium += car1500Tariff;
                    }
                    else if (vehiclesVolume <= 2000 && vehiclesType == "car")
                    {
                        Premium += car2000Tariff;
                    }
                    else if (vehiclesVolume <= 3000 && vehiclesType == "car")
                    {
                        Premium += car3000Tariff;
                    }
                    else if (vehiclesVolume > 3000 && vehiclesType == "car")
                    {
                        Premium += carOver3000Tariff;
                    }
                }
            }
            else if (vehiclesType == "truck" || vehiclesType == "light truck")
            {
                Console.Write("Please enter Vehicle's Weight in tones: ");
                double vehiclesWeight = double.Parse(Console.ReadLine());
                if (vehiclesType == "light truck" && vehiclesWeight <= 3.5)
                {
                    Premium += lightTruck;
                }
                else if (vehiclesType == "light truck" && vehiclesWeight > 3.5)
                {
                    vehiclesType = "truck";
                }
                if (vehiclesType == "truck" && vehiclesWeight <= 5)
                {
                    Premium += truck5;
                }
                else if (vehiclesType == "truck" && vehiclesWeight <= 10)
                {
                    Premium += truck10;
                }
                else if (vehiclesType == "truck" && vehiclesWeight <= 20)
                {
                    Premium += truck20;
                }
                else if (vehiclesType == "truck" && vehiclesWeight > 20)
                {
                    Premium += truckOver20;
                }
            }
            else if (vehiclesType == "microbus" || vehiclesType == "bus")
            {
                Console.Write("Please enter Vehicle's seats: ");
                int vehiclesSeats = int.Parse(Console.ReadLine());
            }
            else if (vehiclesType == "tractor")
            {
                Console.Write("Please enter Vehicle's Weight in tones: ");
                double vehiclesWeight = double.Parse(Console.ReadLine());
            }
            else if (vehiclesType == "trailer")
            {
                Console.Write("Please enter Trailer's length in meters: ");
                double trailersLength = double.Parse(Console.ReadLine());
            }
            //Output:
            Console.WriteLine($"Your MTPL Premium is: {Premium:f2} BGN.");
        }
    }
}
