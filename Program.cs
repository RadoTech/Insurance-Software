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
            //below information is NOT needed for calculation purposes
            //Console.Write("Please enter Vehicle's make: ");
            //string vehiclesMake = Console.ReadLine();
            //Console.Write("Please enter Vehicle's model: ");
            //string vehiclesModel = Console.ReadLine();

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

            //Base Tariff with Rate 1.0:
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
            double microbus = 900; //for microbus & bus with maximum seats of 9 (8+1). 
            double bus30 = 1200; //for bus with maximum seats of 30 (29+1). 
            double bus60 = 1800; //for bus with maximum seats of 60 (59+1). 
            double busOver60 = 2200; //for bus with maximum seats over 60(double-decker bus). 
            double tractor20 = 150; //for agricultural tractors up to 20 tones weight.
            double tractorOver20 = 290; //for agricultural tractors over 20 tones weight.
            double trailer10 = 75; //for trailers up to 10 meters length.
            double trailerOver10 = 175; //for trailers over 10 meters length.

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
                if (vehiclesType == "microbus" && vehiclesSeats <= 9)// 8+1 including driver's seat
                {
                    Premium += microbus;
                }
                else if (vehiclesType == "microbus" && vehiclesSeats > 9)
                {
                    vehiclesType = "bus";
                }
                if (vehiclesType == "bus" && vehiclesSeats <= 30)
                {
                    Premium += bus30;
                }
                else if (vehiclesType == "bus" && vehiclesSeats <= 60)
                {
                    Premium += bus60;
                }
                else if (vehiclesType == "bus" && vehiclesSeats > 60)
                {
                    Premium += busOver60;
                }
            }
            else if (vehiclesType == "tractor")
            {
                Console.Write("Please enter Vehicle's Weight in tones: ");
                double vehiclesWeight = double.Parse(Console.ReadLine());
                if (vehiclesWeight <= 20)
                {
                    Premium += tractor20;
                }
                else if (vehiclesWeight > 20)
                {
                    Premium += tractorOver20;
                }
            }
            else if (vehiclesType == "trailer")
            {
                Console.Write("Please enter Trailer's length in meters: ");
                double trailersLength = double.Parse(Console.ReadLine());
                if (trailersLength <= 10)
                {
                    Premium += trailer10;
                }
                else if (trailersLength > 10)
                {
                    Premium += trailerOver10;
                }
            }
            //Regions
            double Sofia = 1.2; //Rate 
            //Sofia region includes car plates(8): C, CA, CB, CO, PK, PB, B, PA.
            double StaraZagora = 1.0; //Rate 
            //StaraZagora region includes car plates(5): CT, A, P, BT.
            double Blagoevgrad = 0.8; //Rate 
            //Blagoevgrad region includes car plates(10): E, CH, CM, K, X, Y, KH, T, EB, OB.
            double Border = 2.0; //Rate - Highest Risk on Border Region according to Chief Actuary report. 
            //Border region includes North border car plates(7): BH, M, BP, EH, CC, TX, PP.

            Console.Write("Please enter vehicle's plate number without free spaces: ");
            string numberPlate = Console.ReadLine();

            for (int i = 0; i <= 1; i++)
            {
                char firstLetter = numberPlate[0];
                char secondLetter = numberPlate[1];
                if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'A')
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'B')
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'O')
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'P' && Char.ToUpper(secondLetter) == 'K')
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'P' && Char.ToUpper(secondLetter) == 'B')
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'P' && Char.ToUpper(secondLetter) == 'A')
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && numberPlate.Length == 7)
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'B' && numberPlate.Length == 7)
                {
                    Premium *= Sofia;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'T')//Region Stara Zagora
                {
                    Premium *= StaraZagora;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'B' && Char.ToUpper(secondLetter) == 'T')//Region Stara Zagora
                {
                    Premium *= StaraZagora;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'A' && numberPlate.Length == 7)//Region Stara Zagora
                {
                    Premium *= StaraZagora;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'P' && numberPlate.Length == 7)//Region Stara Zagora
                {
                    Premium *= StaraZagora;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'E' && numberPlate.Length == 7)//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'X' && numberPlate.Length == 7)//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'K' && numberPlate.Length == 7)//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'Y' && numberPlate.Length == 7)//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'T' && numberPlate.Length == 7)//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'H')//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'M')//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'K' && Char.ToUpper(secondLetter) == 'H')//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'E' && Char.ToUpper(secondLetter) == 'B')//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'O' && Char.ToUpper(secondLetter) == 'B')//Region Blagoevgrad
                {
                    Premium *= Blagoevgrad;
                    break;
                }
                //Highest Risk on Border Region according to Chief Actuary report. 
                else if (Char.ToUpper(firstLetter) == 'B' && Char.ToUpper(secondLetter) == 'H')//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'B' && Char.ToUpper(secondLetter) == 'P')//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'E' && Char.ToUpper(secondLetter) == 'H')//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'C' && Char.ToUpper(secondLetter) == 'C')//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'T' && Char.ToUpper(secondLetter) == 'X')//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'P' && Char.ToUpper(secondLetter) == 'P')//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else if (Char.ToUpper(firstLetter) == 'M' && numberPlate.Length == 7)//Region Border
                {
                    Premium *= Border;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Number Plate!");
                    i--;
                    Console.Write("Please enter vehicle's plate number without free spaces anew:");
                    numberPlate = Console.ReadLine();
                    continue;
                }
            }
            //Discount section:
            Console.Write("Do you have a discount code? YES or NO: ");
            string discountCode = Console.ReadLine();
            string upperDiscountCode = discountCode.ToUpper();
            if (upperDiscountCode == "YES")
            {
                Console.Write("Please enter your discount code: ");
                string code = Console.ReadLine();
                for (int attempt = 1; attempt <= 3; attempt++)
                {
                    if (code == "RGR2@")
                    {
                        Premium *= 0.98;
                        Console.WriteLine("2% discount has been used for this Insurance policy!");
                        break;
                    }
                    else if (code == "RGR5%")
                    {
                        Premium *= 0.95;
                        Console.WriteLine("5% discount has been used for this Insurance policy!");
                        break;
                    }
                    else if (code == "RGR10!)")
                    {
                        Premium *= 0.90;
                        Console.WriteLine("10% discount has been used for this Insurance policy!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("!!!Invalid Discount Code!!");
                        if (attempt == 1)
                        {
                            Console.WriteLine("You have 2 more attempts...");
                        }
                        else if (attempt == 2)
                        {
                            Console.WriteLine("You have 1 more attempts...");
                        }
                        else if (attempt == 3)
                        {
                            Console.WriteLine("You don't have more attemts.");
                            upperDiscountCode = "NO";
                            break;
                        }
                    }
                    Console.Write("Please enter your discount code anew: ");
                    code = Console.ReadLine();
                }
            }
            if (upperDiscountCode == "NO")
            {
                Console.WriteLine("No discount available for this Insurance policy!");
            }
            //Age section:
            Console.Write("Please enter your age:");
            int age = int.Parse(Console.ReadLine());
            if (age < 25)
            {
                Premium *= 2;
            }
            else if (age >= 25 && age <= 65)
            {
                Premium *= 1;
            }
            else if (age > 65)
            {
                Premium *= 1.5;
            }
            //Output:
            Console.WriteLine($"Your MTPL Premium is: {Premium:f2} BGN.");
        }
    }
}
