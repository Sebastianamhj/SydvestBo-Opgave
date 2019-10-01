﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;
using SydvestBo_Opgave.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SydvestBo_Opgave
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WindowHeight = 25;
            Console.WindowWidth = 95;
            Console.CursorVisible = false;

            string currentMenu = "Main";

            createMainScreen(currentMenu);

            Console.ReadLine();
        }

        public static void ClearCurrentConsoleLine<T>(List<T> menu)
        {
            int quickMaths = 7;
            int stringCounter = menu.Count;
            int currentLineCursor = Console.CursorTop;
            do
            {
                Console.SetCursorPosition(0, quickMaths);
                Console.Write(new string(' ', Console.WindowWidth));
                quickMaths++;
            } while (quickMaths <=stringCounter);
            
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void DynamicChoosing<T>(bool firstwrite, List<T> menu, int menuCounter)
        {
            
            
            //Console.Write(Type.GetTypeCode(typeof(T)));
            Type type = menu.GetType().GetGenericArguments()[0];
            //Type typeParameter = typeof(T);
            //Console.SetCursorPosition(6, 20);
            List<Reservation> reservationList = new List<Reservation>();
            List<SommerhusEjer> ejerList = new List<SommerhusEjer>();
            List<SommerhusClass> sommerhusList = new List<SommerhusClass>();
            List<Konsulent> konsulentList = new List<Konsulent>();
            List<Område> områdeList = new List<Område>();
            

            //Console.Write(type);
            Typeclass Writer = new Typeclass();
            int lineCounter = 7;
            int stringCounter = menu.Count;
            int counter = 0;
            bool continueAccepted = false;


            if (menuCounter <= stringCounter)
            {
                //menuCounter--;
                continueAccepted = true;
            }

            ClearCurrentConsoleLine(menu);
            if (continueAccepted && !firstwrite)
            {
                switch (Type.GetTypeCode(typeof(T))){

                    case TypeCode.String:
                        foreach (var item in menu)
                        {
                            counter++;
                            Console.SetCursorPosition(1, lineCounter);
                            if (counter.Equals(menuCounter))
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(item.ToString());
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(item.ToString());
                            }
                            lineCounter++;

                        }
                        break;

                    case TypeCode.Object:
                        

                        if (type == reservationList.GetType().GetGenericArguments()[0]){
                            
                            reservationList = menu.Cast<Reservation>().ToList();
                            foreach (var item in reservationList)
	                        {
                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"Uge: {ugeNumre(item.StartDato, item.Dage)} {item.SommerhusAddresse} {item.KundeNavn}");
                                    Console.ResetColor(); 
                                }
                                else
                                {
                                   Console.Write($"Uge: {ugeNumre(item.StartDato, item.Dage)} {item.SommerhusAddresse} {item.KundeNavn}");
                                }
                                lineCounter++;
	                        }
                            
                        } else if (type == ejerList.GetType().GetGenericArguments()[0]){

                            ejerList = menu.Cast<SommerhusEjer>().ToList();
                            foreach (var item in ejerList)
	                        {

                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                }
                                lineCounter++;
	                        }

                        } else if (type == sommerhusList.GetType().GetGenericArguments()[0]){

                            sommerhusList = menu.Cast<SommerhusClass>().ToList();

                            foreach (var item in sommerhusList)
	                        {
                                
                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.Adresse} {item.Opsynsmand} {item.FornavnEjer} {item.EfternavnEjer}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.Adresse} {item.Opsynsmand} {item.FornavnEjer} {item.EfternavnEjer}");
                                }
                                lineCounter++;
	                        }

                        } else if (type == konsulentList.GetType().GetGenericArguments()[0]){

                            konsulentList = menu.Cast<Konsulent>().ToList();

                            foreach (var item in konsulentList)
	                        {

                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                }
                                lineCounter++;
	                        }
                        } else if (type == områdeList.GetType().GetGenericArguments()[0]){

                            områdeList = menu.Cast<Område>().ToList();

                            foreach (var item in områdeList)
	                        {

                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.postNr} {item.områdeBy}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.postNr} {item.områdeBy}");
                                }
                                lineCounter++;
	                        }
                        }
                                   
                        break;
                }
                
            } else if (continueAccepted && firstwrite)
            {
                foreach (var item in menu)
                {
                    counter++;
                    Console.SetCursorPosition(1, lineCounter);
                    if (counter.Equals(menuCounter))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Writer.TypeWriter(item.ToString());
                        Console.ResetColor();
                    }
                    else
                    {
                        Writer.TypeWriter(item.ToString());
                    }
                    lineCounter++;

                }
            }

        }

        public static void SommerhusEjere(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Sommerhus Ejere:");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("Vælg en ejer, for at administrerer deres sommerhuse eller oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<SommerhusEjer> ejerList = new List<SommerhusEjer>();
            ejerList = SommerhusEjer.LavEjerListe();

            int listCounter = ejerList.Count();

            DynamicChoosing(firstWrite, ejerList, 1);
            MenuOptions(ejerList, currentMenu);

        }

        public static void Sommerhuse(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Sommerhuse:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg et sommerhus, for at administrerer det eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<SommerhusClass> sommerhusList = new List<SommerhusClass>();
            sommerhusList = SommerhusClass.LavSommerListe();

            DynamicChoosing(firstWrite, sommerhusList, 1);
            MenuOptions(sommerhusList, currentMenu);
        }

        public static void CreateReservationScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Reservationer:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en Reservation, for at administrerer den eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<Reservation> ReservationList = new List<Reservation>();
            //ReservationList.Add("Opret Reservation");
            ReservationList = Reservation.CreateReservationList();
            
            DynamicChoosing(firstWrite, ReservationList, 1);
            MenuOptions(ReservationList, currentMenu);

        }

        public static void CreateKonsulentScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Udlejningskonsulenter:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en Konsulent, for at administrerer eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<Konsulent> KonsulentList = new List<Konsulent>();
            KonsulentList = Konsulent.CreateKonsulentList();

            DynamicChoosing(firstWrite, KonsulentList, 1);
            MenuOptions(KonsulentList, currentMenu);
        }

        public static void createOmrådeScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Udlejningskonsulenter:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<Område> områdeList = new List<Område>();
            områdeList = Område.createOmrådeList();

            DynamicChoosing(firstWrite, områdeList, 1);
            MenuOptions(områdeList, currentMenu);
        }

        public static void createSæsonScreen(string currentMenu) {

            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Sæson kategorier og priser:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en Konsulent, for at administrerer eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<string> sæsonList = new List<string>()
            {
                "Lav",
                "Mellem",
                "Høj",
                "Super"
            };

            DynamicChoosing(firstWrite, sæsonList, 1);
            MenuOptions(sæsonList, currentMenu);

        }

        public static void createMainScreen(string currentMenu) {

            Console.Clear();
            bool firstWrite = true;
            Loading.loading();

            Typeclass Writer = new Typeclass();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
            Writer.TypeWriter("Sydvest-Bo Sommerhuse");
            Console.SetCursorPosition(70, 21);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("F1 Opret Sommerhus Ejer");
            Console.SetCursorPosition(70, 22);
            Console.WriteLine("F2 Opret Sommerhus");
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("F3 Opret Reservation.");
            Console.ResetColor();

            List<string> mainScreen = new List<string>()
            {
                "Sommerhus ejere:",
                "Sommerhuse:",
                "Reservationer:",
                "Udlejningskonsulenter:",
                "Områder:",
                "Sæson kategori og priser:"
            };


            DynamicChoosing(firstWrite, mainScreen, 1);
            MenuOptions(mainScreen, currentMenu);

        }

        public static void MenuOptions<T>(List<T> menu, string currentMenu)
        {
            bool firstWrite = false;
            int menuCounter = 1;
            bool titleMenuBool = false;

            if (currentMenu.Equals("Main"))
            {

                do
                {
                    var ch = Console.ReadKey().Key;
                    switch (ch)
                    {

                        case ConsoleKey.UpArrow:
                            if (menuCounter == 1)
                            {
                                menuCounter = menu.Count();
                                DynamicChoosing(firstWrite, menu, menuCounter);

                            }
                            else
                            {
                                menuCounter--;
                                DynamicChoosing(firstWrite, menu, menuCounter);

                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuCounter == menu.Count())
                            {
                                menuCounter = 1;
                                DynamicChoosing(firstWrite, menu, menuCounter);
                            }
                            else
                            {
                                menuCounter++;
                                DynamicChoosing(firstWrite, menu, menuCounter);
                            }
                            break;
                        case ConsoleKey.F1:
                            // Opret sommerhus Ejer

                            break;
                        case ConsoleKey.F2:
                            //Opret Sommerhus

                            break;
                        case ConsoleKey.F3:
                            //Opret reservation

                            break;

                        case ConsoleKey.Enter:
                            if (menuCounter == 1)
                            {
                                currentMenu = "SommerhusEjer";
                                SommerhusEjere(currentMenu);                                

                            }
                            else if (menuCounter == 2)
                            {

                                currentMenu = "Sommerhus";
                                Sommerhuse(currentMenu);
                            }
                            else if (menuCounter == 3)
                            {
                                //Reservationer();
                                currentMenu = "Reservation";
                                //List<Reservation> ReservationList = new List<Reservation>();
                                //ReservationList = Reservation.CreateReservationList();
                                CreateReservationScreen(currentMenu);
                            }
                            else if (menuCounter == 4)
                            {
                                //Udlejningskonsulent();
                                //currentMenu = "Udlejningskonsulent";
                                currentMenu = "Konsulent";
                                CreateKonsulentScreen(currentMenu);
                            }
                            else if (menuCounter == 5)
                            {
                                currentMenu = "Område";
                                createOmrådeScreen(currentMenu);
                            }
                            else if (menuCounter == 6)
                            {
                                currentMenu = "Sæson";
                                createSæsonScreen(currentMenu);
                            }
                            titleMenuBool = true;
                            break;
                    }
                } while (!titleMenuBool);

            } else
            {
                do
                {
                    var ch = Console.ReadKey().Key;
                    switch (ch)
                    {

                        case ConsoleKey.UpArrow:
                            if (menuCounter == 1)
                            {
                                menuCounter = menu.Count();
                                DynamicChoosing(firstWrite, menu, menuCounter);

                            }
                            else
                            {
                                menuCounter--;
                                DynamicChoosing(firstWrite, menu, menuCounter);

                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuCounter == menu.Count())
                            {
                                menuCounter = 1;
                                DynamicChoosing(firstWrite, menu, menuCounter);
                            }
                            else
                            {
                                menuCounter++;
                                DynamicChoosing(firstWrite, menu, menuCounter);
                            }
                            break;

                        case ConsoleKey.Escape:
                            if (currentMenu.Equals("SommerhusEjer") || currentMenu.Equals("Sommerhus") ||
                                currentMenu.Equals("Reservation") || currentMenu.Equals("Konsulent") ||
                                currentMenu.Equals("Område") || currentMenu.Equals("Sæson"))
	                        {
                                firstWrite = false;
                                currentMenu = "Main";
                                createMainScreen(currentMenu);
	                        }
                            break;

                        case ConsoleKey.Enter:

                            //int sqlIndex = menuCounter - 1;
                            if (currentMenu.Equals("SommerhusEjer"))
                            {
                                List<SommerhusEjer> EjerList = new List<SommerhusEjer>();
                                EjerList = SommerhusEjer.LavEjerListe();

                                foreach (var item in EjerList)
	                            {
                                    Console.WriteLine(item.Fornavn + " " + item.Efternavn);
                                }

                                SommerhusEjer Ret1 = new SommerhusEjer();

                                Ret1.Fornavn = "Harry";
                                Ret1.Efternavn = "Potter";
                                Ret1.Adresse = "Magiskvej 17";
                                Ret1.PostNr = 5000;
                                Ret1.PostNr = 22222222;

                                Ret1.EditDB(2);
                                
                                Console.WriteLine("tryk på en tast SQL EDIT");
                                Console.ReadKey();

                                SommerhusEjer Ret2 = new SommerhusEjer("Hagrid","Magisk","Venafdyrvej 8", 2400, 10101010);

                                Ret2.EditDB(2);

                            }else if (currentMenu.Equals("Sommerhus"))
                            {
                                List<SommerhusClass> SommerHusList = new List<SommerhusClass>();
                                SommerHusList = SommerhusClass.LavSommerListe();

                                foreach (var item in SommerHusList)
	                            {
                                    Console.WriteLine(item.Adresse);
	                            }

                                //Create a new sommerhus
                                SommerhusClass Sommer1 = new SommerhusClass(2000, "Fasanvej 20", 4, 100, "Hustle", 4000,"Hans","Godkendt",3);
                                Sommer1.InsertDB();

                                Sommer1.Opsynsmand = "LALALALLALA";
                                Sommer1.Godkendt = "MUTHER!";
                                Sommer1.EditDB(2);

                                

                            }else if (currentMenu.Equals("Reservation"))
                            {
                                List<Reservation> ReservationList = new List<Reservation>();
                                ReservationList = Reservation.CreateReservationList();

                                foreach (var item in ReservationList)
	                            {
                                    Console.WriteLine(item.MySommerhusID);
	                            }


                                //Create New Reservation

                                DateTime tempdate = new DateTime(2019,07,21);
                            

                                Reservation Res1 = new Reservation(2, 1, tempdate,"Super",30304040,"Lauge");
                                Res1.InsertDB();

                                Res1.KundeNavn = "YAYYSAYYAY";
                                Res1.EditDB(2);



                            }else if (currentMenu.Equals("Konsulent"))
                            {
                                List<Konsulent> KonsulentList = new List<Konsulent>();
                                KonsulentList = Konsulent.CreateKonsulentList();

                                foreach (var item in KonsulentList)
	                            {
                                    Console.WriteLine(item.Fornavn + " " + item.Efternavn);
	                            }
                            }else if (currentMenu.Equals("Område"))
                            {

                            }else if (currentMenu.Equals("Sæson"))
                            {

                            }

                            //CREATE KONSULENT

                            Konsulent kon1 = new Konsulent("Simon", "Juul", "Lyngvej 73", 50603010, 5000, 2400);
                            kon1.InsertDB();
                            
                            kon1.Fornavn = "HANSI";
                            kon1.Efternavn = "HINTERSEEER";
                            kon1.EditDB(2);
                            

                            break;
                    }


                } while (!titleMenuBool);
            }
        }
        //Tester om dato og ugeforløb overlapper med en eksisterende reservation
        //returnere true, hvis de overlapper
        public static bool ugeReserveret(DateTime date, int uger)
        {
            //Test data, der burde blive hentet fra databasen
            DateTime dBDate = new DateTime(2019, 5, 1);
            int dBUger = 1;

            DateTime dBDateEnd = dBDate.AddDays(7 * dBUger);
            DateTime dateEnd = date.AddDays(7 * uger);

            if (date < dBDateEnd && dBDate < dateEnd)
            {
                return true;
            }
            else return false;

        }

        //returner uge til uge streng eks: 29-31
        public static string ugeNumre(DateTime dato,int ugeantal)
        {
            int uge = (dato.DayOfYear / 7) + 1;
            if (dato.DayOfWeek == DayOfWeek.Saturday || dato.DayOfWeek == DayOfWeek.Sunday)
            {
                uge++;
            }
            if (ugeantal < 1){
                return uge.ToString();
            }
            else
            {
                return $"{uge}-{uge + (ugeantal - 1)}";
            }
        }
    }
}
