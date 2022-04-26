using System;

namespace CSharp.LabExercise2
{
    public class Lasagna
    {
        public int ExpectedMinutesInOven()
        {
            return 40;
        }

        public int RemainingMinutesInOven(int value)
        {
            return 40 - value;
        }

        public int PreparationTimeInMinutes(int layers)
        {
            return 2 * layers;
        }

        public int ElapsedTimeinMinutes(int layers, int OvenTime)
        {
            return (2 * layers) + OvenTime;
        }
    }
    internal class Program
    {
        static void Number1()
        {
            //Input for 10-100
            string[] NumberList = new string[5];
            int index = 0;
            do
            {
                for(index = 0; index < NumberList.Length;)
                {
                    //bool is entered to reset value each run of loop
                    bool alreadyEntered = false;
                    Console.Write("\nEnter number: ");
                    string valueEntered = Convert.ToString(Console.ReadLine());

                    //Value must be between 10-100
                    if (Convert.ToInt32(valueEntered) <= 100 && Convert.ToInt32(valueEntered) >= 10)
                    {
                        //Check if value is already existing
                        foreach (string Entry in NumberList)
                        {
                            if (valueEntered == Entry)
                            {
                                alreadyEntered = true;
                            }
                        }
                            //Render value if entry is valid
                            if (alreadyEntered == false)
                            {
                                NumberList[index] = valueEntered;
                                //To Generate Contents of Array
                                foreach (string Entry in NumberList)
                                {
                                    Console.Write($"{Entry} ");
                                }
                                index++;
                            }
                            else
                            {
                                Console.Write($"{valueEntered} has already been entered.");
                            }
                    }
                    else
                    {
                        Console.Write("Number must be between 10 and 100");
                        break;
                    }

                }
            }
            while(index < NumberList.Length);
        }

        static void Number2()
        {
            var lasagna = new Lasagna();
            bool cooking = true;
            do 
            {
                Console.WriteLine("Hello, Lucian! Let's make lasagna!");
                Console.WriteLine("Please select which item you would like to know:");
                Console.WriteLine("\t[1]How long it takes for lasagna to cook in oven");
                Console.WriteLine("\t[2]Remaining oven time after \"x\" minutes");
                Console.WriteLine("\t[3]How long it takes to prepare \"x\" layers of lasagna");
                Console.WriteLine("\t[4]Total elapsed time after preparing \"x\" layers and \"y\" oven time");
                Console.WriteLine("\t[5]Exit");
                Console.Write("Enter item number: ");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Expected Lasagna Time In Oven (Minutes): {0}", lasagna.ExpectedMinutesInOven());
                        Console.Write("Return to main menu? (y/n)");
                        if (Console.ReadLine() == "n")
                        {
                            cooking = false;
                        }
                        break;
                    case 2:
                        Console.Write("Enter time elapsed in oven: ");
                        int timeInOven = Convert.ToInt32(Console.ReadLine());
                        if (timeInOven <= 40)
                        {
                            Console.WriteLine("Remaining Lasagna Time In Oven (Minutes): {0}", lasagna.RemainingMinutesInOven(timeInOven));
                            Console.Write("Return to main menu? (y/n)");
                            if (Console.ReadLine() == "n")
                            {
                                cooking = false;
                            }
                        }
                        else if (timeInOven < 0)
                        {
                            Console.WriteLine("Please enter value greater than 0!");
                        }
                        else
                        {
                            Console.WriteLine("You've exceeded 40 minutes of cooking time! Lasagna is burnt!!!");
                        }
                        break;
                    case 3:
                        Console.Write("Enter amount of layers to prepare: ");
                        int lasagnaLayers = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Layer preparation time in minutes: {0}", lasagna.PreparationTimeInMinutes(lasagnaLayers));
                        Console.Write("Return to main menu? (y/n)");
                        if (Console.ReadLine() == "n")
                        {
                            cooking = false;
                        }
                        break;
                    case 4:
                        Console.Write("Enter amount of layers prepared: ");
                        int preparedLayers = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter elapsed time in oven: ");
                        int elapsedTime = Convert.ToInt32(Console.ReadLine());
                        if (elapsedTime <= 40 && preparedLayers > 0)
                        {
                            Console.WriteLine("Total elapsed time (layer preparation & oven time): {0}", lasagna.ElapsedTimeinMinutes(preparedLayers, elapsedTime));
                            Console.WriteLine("Also, there are {0} minutes remaining for your lasagna to be fully cooked", lasagna.RemainingMinutesInOven(elapsedTime));
                            Console.Write("Return to main menu? (y/n)");
                            if (Console.ReadLine() == "n")
                            {
                                cooking = false;
                            }
                        }
                        else if (elapsedTime < 0 || preparedLayers < 0)
                        {
                            Console.WriteLine("Please enter value greater than 0!");
                            Console.Write("Return to main menu? (y/n)");
                            if (Console.ReadLine() == "n")
                            {
                                cooking = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You've prepared {0} layers of lasagna but you've exceeded 40 minutes of cooking time! Lasagna is burnt!!!", preparedLayers);
                            Console.Write("Return to main menu? (y/n)");
                            if (Console.ReadLine() == "n")
                            {
                                cooking = false;
                            }
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            Console.Clear();
            }
            while(cooking == true);

        }

        static void Main(string[] args)
        {
            //Number1();
            Number2();
        }
    }
}
