using HomeTasksCS10_Enum_DateTime_.Classes;
using System;

namespace HomeTasksCS10_Enum_DateTime_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Group[] groups = new Group[0];


            string opt;
            do
            {
                Console.WriteLine("1. Qrup elave et");
                Console.WriteLine("2. Qruplara bax");
                Console.WriteLine("3. Type deyerine gore qruplara bax");
                Console.WriteLine("4. Bugunedek baslamis qruplara baxmaq");
                Console.WriteLine("5. Son iki ayda baslamis qruplara baxmaq");
                Console.WriteLine("6. Bu ayin sonunadek baslayacaq qruplara baxmaq");
                Console.WriteLine("7. Verilmis iki tarix araliginda baslamis qruplara baxmaq");
                Console.WriteLine("0. Cixis"); 
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.WriteLine("No:");
                        string no = Console.ReadLine();
                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");


                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);

                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;


                        Console.WriteLine("StartDate:");
                        string startDatestr = Console.ReadLine();
                        DateTime startDate = Convert.ToDateTime(startDatestr);

                        Group group = new Group
                        {
                            No = no,
                            Type = type,
                            StartDate = startDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;

                        break;
                    case "2":
                        foreach (var gr in groups)
                        {
                            Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;

                        foreach (var gr in groups)
                        {
                            if (gr.Type == type)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "4":
                        int count = 0;
                        foreach(var gr in groups)
                        {
                            if (gr.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No:{gr.No} - Type:{gr.Type} - StartDate:{gr.StartDate.ToString("dd.MM.yyyy HH.mm")}");
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Bele bir qrup yoxdur");
                        }
                        break;
                    case "5":
                        int count1 = 0;
                        foreach(var gr in groups)
                        {
                            if(gr.StartDate<DateTime.Now && gr.StartDate > DateTime.Now.AddMonths(-2))
                            {
                                Console.WriteLine($"No:{gr.No} - Type:{gr.Type} - StartDate:{gr.StartDate.ToString("dd.MM.yyyy HH.mm")}");
                                count1++;
                            }
                        }
                        if (count1 == 0)
                        {
                            Console.WriteLine("Bele bir qrup yoxdur");
                        }
                        break;
                    case "6":
                        int count2 = 0;
                        foreach(var gr in groups)
                        {
                            if (gr.StartDate.Year > DateTime.Now.Year && gr.StartDate.Month > DateTime.Now.Month && gr.StartDate.Day > DateTime.Now.Day && gr.StartDate.Hour > DateTime.Now.Hour)
                            {
                                Console.WriteLine($"No:{gr.No} - Type:{gr.Type} - StartDate:{gr.StartDate.ToString("dd.MM.yyyy HH.mm")}");
                                count2++;
                            }
                        }
                        if (count2 == 0)
                        {
                            Console.WriteLine("Bele bir qrup yoxdur");
                        }
                        break;
                    case "7":
                        int count3 = 0;

                        Console.WriteLine("Ilk tarixi sechin");
                        string dateStr1=Console.ReadLine();
                        DateTime Date1 = Convert.ToDateTime(dateStr1);

                        Console.WriteLine("Ikinci tarixi secin");
                        string dateStr2=Console.ReadLine();
                        DateTime Date2 = Convert.ToDateTime(dateStr2);

                        foreach(var gr in groups)
                        {
                            if(gr.StartDate >=Date1 && gr.StartDate<=Date2)
                            {
                                Console.WriteLine($"No:{gr.No} - Type:{gr.Type} - StartDate:{gr.StartDate.ToString("dd.MM.yyyy HH.mm")}");
                                count3++;
                            }
                        }
                        if (count3 == 0)
                        {
                            Console.WriteLine("Bele bir qrup yoxdur");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Sagolun ! ");
                        break;
                    default:
                        Console.WriteLine("Seciminiz yanlisdir");
                        break;
                }

            } while (opt != "0");







        }
    }
}
