﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;
using SydvestBo_Opgave.Model;
using System.Data;
using System.Data.SqlClient;

namespace SydvestBo_Opgave
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WindowHeight = 25;
            Console.WindowWidth = 95;
            Console.CursorVisible = false;

            Loading.loading();

            //bool titleMenuBool = false;
            bool firstWrite = true;
            int menuCounter = 1;
            string currentMenu = "Main";

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

            if (SQL.SQLConnectionOK())
            {
                //Console.WriteLine("Connection virker :D");
            } else
            {
                //Console.WriteLine("Something wrong :sad:");
            }

            
            List<string> mainScreen = new List<string>()
            {
                "Sommerhus ejere:",
                "Sommerhuse:",
                "Reservationer:",
                "Udlejningskonsulenter:",
                "Områder:",
                "Sæson kategori og priser:"
            };

            DynamicChoosing(firstWrite, mainScreen, menuCounter);
            firstWrite = false;
            MenuOptions(mainScreen, currentMenu);

            Console.ReadLine();
        }

        public static void ClearCurrentConsoleLine<T>(List<T> menu)
        {
            int quickMaths = 6;
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
            

            Typeclass Writer = new Typeclass();
            int lineCounter = 6;
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
                foreach (var item in menu)
                {
                    counter++;
                    Console.SetCursorPosition(1, lineCounter);
                    if (counter.Equals(menuCounter))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(item);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                    lineCounter++;
                    
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
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en ejer, for at administrerer deres sommerhuse eller oplysninger.");


            List<string> ejerlist = new List<string>();
            ejerlist.Add("Opret sommerhus ejer");
            foreach (var item in SQL.getListFromSQL("SELECT Ejer.Fornavn FROM Ejer"))
            {
                ejerlist.Add(item);
            }
            

            int listCounter = ejerlist.Count();

            DynamicChoosing(firstWrite, ejerlist, 1);
            MenuOptions(ejerlist, currentMenu);

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

            List<string> sommerhusList = new List<string>();
            sommerhusList.Add("Opret Sommerhus");
            foreach (var item in SQL.getListFromSQL("SELECT SOmmerhuse.Adresse FROM Sommerhuse"))
            {
                sommerhusList.Add(item);
            }


            int listCounter = sommerhusList.Count();

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

            List<Reservation> ReservationList = new List<Reservation>();
            //ReservationList.Add("Opret Reservation");
            ReservationList = Reservation.CreateReservationList();
            
            int listCounter = ReservationList.Count();

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

            List<Konsulent> KonsulentList = new List<Konsulent>();
            KonsulentList = Konsulent.CreateKonsulentList();

            int listCounter = KonsulentList.Count();

            DynamicChoosing(firstWrite, KonsulentList, 1);
            MenuOptions(KonsulentList, currentMenu);
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
                            SommerhusEjere(currentMenu);

                                currentMenu = "SommerhusEjer";

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

                        case ConsoleKey.End:
                            //go back to Main menu
                            break;

                        case ConsoleKey.Enter:

                            int sqlIndex = menuCounter - 1;
                            if (currentMenu.Equals("SommerhusEjer"))
                            {
                                Console.Clear();
                                List<SommerhusEjer> EjerList = new List<SommerhusEjer>();
                                EjerList = SommerhusEjer.LavEjerListe();

                                foreach (var item in EjerList)
	{
                                    Console.WriteLine(item.Fornavn + " " + item.Efternavn);
                             }

                            }else if (currentMenu.Equals("Sommerhus"))
                            {
                                Console.Clear();
                                List<SommerhusClass> SommerHusList = new List<SommerhusClass>();
                                SommerHusList = SommerhusClass.LavSommerListe();

                                foreach (var item in SommerHusList)
	                            {
                                    Console.WriteLine(item.Adresse);
	                            }

                               


                            }else if (currentMenu.Equals("Reservation"))
                            {
                                Console.Clear();
                                List<Reservation> ReservationList = new List<Reservation>();
                                ReservationList = Reservation.CreateReservationList();

                                foreach (var item in ReservationList)
	                            {
                                    Console.WriteLine(item.MySommerhusID);
	                            }

                            }else if (currentMenu.Equals("Konsulent"))
                            {
                                Console.Clear();
                                List<Konsulent> KonsulentList = new List<Konsulent>();
                                KonsulentList = Konsulent.CreateKonsulentList();

                                foreach (var item in KonsulentList)
	                            {
                                    Console.WriteLine(item.Fornavn + " " + item.Efternavn);
	                            }
                            }
                            
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
