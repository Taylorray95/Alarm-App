using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_2_Taylor_Leavelle
{
    class Time2Test
    {
        static void Main()
        {//part A
            var t1 = new Time2_book();
            var t2 = new Time2_book(2);
            var t3 = new Time2_book(21, 34);
            var t4 = new Time2_book(12, 25, 42);
            var t5 = new Time2_book(t4);
            Console.WriteLine("Part A:\n");
            Console.WriteLine("Constructed with class: Time2\n");      
            Console.WriteLine("t1: all arguments defaulted"); ;
            Console.WriteLine($"   {t1.ToUniversalString()}");
            Console.WriteLine($"   {t1.ToString()}\n");

            Console.WriteLine("t2: hour specified ;minute and second defaulted");
            Console.WriteLine($"   {t2.ToUniversalString()}");
            Console.WriteLine($"   {t2.ToString()}\n");

            Console.WriteLine("t3: hour and minute specified ;and second defaulted");
            Console.WriteLine($"   {t3.ToUniversalString()}");
            Console.WriteLine($"   {t3.ToString()}\n");

            Console.WriteLine("t4: hour,minute and second specified");
            Console.WriteLine($"   {t4.ToUniversalString()}");
            Console.WriteLine($"   {t4.ToString()}\n");

            Console.WriteLine("t5: Time2 object t4 specified");
            Console.WriteLine($"   {t5.ToUniversalString()}");;
            Console.WriteLine($"   {t5.ToString()}\n");

            Console.WriteLine("----------------------------------------------");



            // using the modified class Time2C with the same input
            var t6 = new Time2C();
            var t7 = new Time2C(2);
            var t8 = new Time2C(21, 34);
            var t9 = new Time2C(12, 25, 42);
            var t10 = new Time2C(t9);
            Console.WriteLine("Constructed with the modified class using StringBuilder: Time2C\n");      //
            Console.WriteLine("t6: all arguments defaulted"); 
            Console.WriteLine($"   {t6.getTimeUniversal()}");
            Console.WriteLine($"   {t6.getTime()}");

            Console.WriteLine("t7: hour specified ;minute and second defaulted");
            Console.WriteLine($"   {t7.getTimeUniversal()}");
            Console.WriteLine($"   {t7.getTime()}\n");

            Console.WriteLine("t8: hour and minute specified ;and second defaulted");
            Console.WriteLine($"   {t8.getTimeUniversal()}");
            Console.WriteLine($"   {t8.getTime()}\n");

            Console.WriteLine("t9: hour,minute and second specified");
            Console.WriteLine($"   {t9.getTimeUniversal()}");
            Console.WriteLine($"   {t9.getTime()}\n");

            Console.WriteLine("t10: Time2 object t4 specified");
            Console.WriteLine($"   {t10.getTimeUniversal()}"); ;
            Console.WriteLine($"   {t10.getTime()}\n");

            Console.WriteLine("----------------------------------------------");


            //Part B
            //testing if I can add times
            Console.WriteLine("Part B:\n");
            var t11 = new Time2C(4, 20, 4);
            Console.WriteLine("Adding times using class Time2C:\n");      
            t10.addtime(4,20,8);
            Console.WriteLine("Adding 4:20:08 to t10 (12:45:42)");
            Console.WriteLine($"   {t10.getTimeUniversal()}"); ;
            Console.WriteLine($"   {t10.getTime()}\n");
            t9.addtime(t11);                                        //adding a time (from another time2c object) to the time
            Console.WriteLine("Adding t11 (4:20:04) to t9 (12:25:42)");
            Console.WriteLine($"   {t9.getTimeUniversal()}"); 
            Console.WriteLine($"   {t9.getTime()}\n");

            Console.WriteLine("----------------------------------------------");


            // Part C
            //testing if constructor for new class time2tz works
            Console.WriteLine("Part C:\n");
            var t12 = new Time2tz();
            var t13 = new Time2tz("EST", 5, 5, 5);
            Console.WriteLine("Constructed with class: Time2tz \n");
            Console.WriteLine("t12: all arguments defaulted; timezone is CST if none specified");
            Console.WriteLine($"   {t12.getTimeUniversal()}");
            Console.WriteLine($"   {t12.getTime()}\n");
            Console.WriteLine("t13: Time zone specified as EST and (5,5,5) is input for time");
            Console.WriteLine($"   {t13.getTimeUniversal()}");
            Console.WriteLine($"   {t13.getTime()}\n");

            Console.WriteLine("----------------------------------------------");
            
            //Part D
            List<Time2_book> list = new List<Time2_book>();
            List<Time2tzz> list2 = new List<Time2tzz>();
            string answer;
            Console.WriteLine("Part D:\n");
            do {
                Console.WriteLine("Which type of object would you like to enter?\n" +
                    "1 - time2\n" +
                    "2 - time2tz\n" +
                    "3 -Stop entering data\n");
                    answer= Console.ReadLine();
                    if (answer == "1")
                    {
                        Console.WriteLine("Enter the Hours:");
                        int hour = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Minutes:");
                        int minute = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Seconds:");
                        int second = Convert.ToInt32(Console.ReadLine());
                        list.Add(new Time2_book(hour, minute, second));
                    }
                    else if (answer == "2")
                    {
                        Console.WriteLine("Enter the Hours:");
                        int hour = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Minutes:");
                        int minute = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Seconds:");
                        int second = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Timezone (EST, CST, MST, PST) (Invalid input will default to CST:");
                        string timezone = Console.ReadLine();
                        list2.Add(new Time2tzz(timezone, hour, minute, second));

                    }
                    else if ((answer != "1" || answer != "2") && answer != "3")
                    {
                        Console.WriteLine("Please either enter 1, 2, or 3");
                    }
            }
            while (answer != "3");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");
            string input = "0";
            var printallobjects_time2 = from time in list
                                        orderby time.Hour, time.Minute, time.Second
                                        select time;

            var printallobjects_time2tz = from time in list2
                                          orderby time.Hour, time.Minute, time.Second
                                          select time;

            var printallobjects_time2_AM = from time in list
                                           where time.Hour < 11
                                           orderby time.Hour,time.Minute, time.Second
                                           select time;

            var printallobjects_time2tz_AM = from time in list2
                                             where time.Hour < 11
                                             orderby time.Hour, time.Minute, time.Second
                                             select time;

            var printallobjects_time2_PM = from time in list
                                           where time.Hour > 11
                                           orderby time.Hour, time.Minute, time.Second
                                           select time;

            var printallobjects_time2tz_PM = from time in list2
                                             where time.Hour > 11
                                             orderby time.Hour, time.Minute, time.Second
                                             select time;
            
                do
                {
                    Console.WriteLine("1 - All Objects\n");
                    Console.WriteLine("2 - All objects with AM times\n");
                    Console.WriteLine("3 - All objects with PM times\n");
                    Console.WriteLine("4 - QUIT\n");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Sorted Time2 objects:\n");
                        Console.WriteLine("----------------------------------------------");
                        foreach (Time2_book time in printallobjects_time2)
                        {

                            Console.WriteLine(time);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Sorted Time2tz objects:\n");
                        Console.WriteLine("----------------------------------------------");
                        foreach (Time2tzz time in printallobjects_time2tz)
                        {

                            Console.WriteLine(time);
                            Console.WriteLine();
                        }
                    }

                    else if (input == "2")
                    {
                        Console.WriteLine("All AM Time2 objects sorted:\n");
                        Console.WriteLine("----------------------------------------------");
                        foreach (Time2_book time in printallobjects_time2_AM)
                        {
                            Console.WriteLine(time);
                            Console.WriteLine();
                        }
                        Console.WriteLine("All AM Time2z objects sorted:\n");
                        Console.WriteLine("----------------------------------------------");
                        foreach (Time2_book time in printallobjects_time2tz_AM)
                        {
                            Console.WriteLine(time);
                            Console.WriteLine();
                        }
                    }
                    else if (input == "3")
                    {
                        Console.WriteLine("All PM Time2 objects sorted:\n");
                        Console.WriteLine("----------------------------------------------");
                        foreach (Time2_book time in printallobjects_time2_PM)
                        {
                            Console.WriteLine(time);
                            Console.WriteLine();
                        }
                        Console.WriteLine("All PM Time2z objects sorted:\n");
                        Console.WriteLine("----------------------------------------------\n");
                        foreach (Time2_book time in printallobjects_time2tz_PM)
                        {
                            Console.WriteLine(time);
                            Console.WriteLine();
                        }
                    }
                    
                }
                while (input != "4");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");


            //Extra Credit - incomplete 
            Console.WriteLine("Extra Credit:\n");
            Console.WriteLine("Adding 12:00:00 to (12:20:00)");
            var t14 = new Time2C(12, 0, 0);
            t14.addtime(12, 20, 00); 
            Console.WriteLine(t14.getTimeUniversal());
            Console.WriteLine(t14.getTime());
            Console.WriteLine("");


            //Extra credit - did not finish
             var t15 = new Time2C(23, 59, 59);
             t15.addtime(t14);
            Console.WriteLine("Testing if we can plug in class object instead of time values");
             Console.WriteLine("Adding 12:00:00 (t14) to 23:59:59");
             Console.WriteLine(t15.getTimeUniversal());
             Console.WriteLine(t15.getTime());


            Console.ReadLine();  //pause


        }
        

    }
}
