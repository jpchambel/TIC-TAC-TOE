﻿using System;

namespace JOGO_DO_GALO_
{
    class Program
    {
        public static string[] galo = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        static void Main(string[] args)
        {
            int input1 = 10;
            int input2 = 10;
            string ins1 = " ";
            string ins2 = " ";
            
            while (true)
            {      
                //PLAYER 1 INPUT
                bool sucInput1 = false;
                while (sucInput1 == false | input1 > 9 | input1 < 0)
                {
                    printGalo();
                    Console.Write("\n \nPlayer 1 (O), make your move:");
                    ins1 = Console.ReadLine().ToLower();
                    sucInput1 = int.TryParse(ins1, out input1);
                    if (ins1 == "quit")
                        break;
                    else if (ins1 == "reset")
                    {
                        resetGalo();
                        break;
                    }                                       
                }

                //QUIT OR PLAY
                if (ins1 == "quit")
                    break;
                else if(ins1 != "reset")
                    galo[input1 - 1] = "O";

                //WIN TEST:PLAYER_1
                bool win1 = winTest();
                if (win1 == true) 
                {
                    printGalo();
                    Console.WriteLine("\n \nPlayer 1 (O) wins!!!");
                    break;
                }

                //PLAYER 2 INPUT
                bool sucInput2 = false;
                while (sucInput2 == false | input2 > 9 | input2 < 0)
                {
                    printGalo();
                    Console.Write("\n \nPlayer 2 (X), make your move:");
                    ins2 = Console.ReadLine().ToLower();
                    sucInput2 = int.TryParse(ins2, out input2);
                    if (ins2 == "quit")
                        break;
                    else if (ins2 == "reset")
                    {
                        resetGalo();
                        break;
                    }
                }

                //QUIT OR PLAY
                if (ins2 == "quit")
                    break;
                else if (ins2 != "reset")
                    galo[input2 - 1] = "X";

                //PLAYER 2 INPUT
                bool win2 = winTest();
                if (win2 == true)
                {
                    printGalo();
                    Console.WriteLine("\n \nPlayer 2 (X) wins!!!");
                    break;
                }
            }

            //FINAL MESSAGE
            Console.WriteLine(" \n ");
            Console.WriteLine(" ");
            Console.WriteLine("Thanks for playing! See you next time buddy!!");
            Console.WriteLine(" \n ");
        }

        public static void printGalo()
        {
            //GAME GENERATOR
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", galo[0], galo[1], galo[2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", galo[3], galo[4], galo[5]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", galo[6], galo[7], galo[8]);
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" ");
            Console.WriteLine("Type 'reset' to reset the game.");
            Console.WriteLine("Type 'quit' to quit the game.");
        }

        public static bool winTest()
        {
            //DID ANYONE WIN?
            if (galo[0] == galo[1] && galo[1] == galo[2])
            {
                return true;
            }
            else if (galo[3] == galo[4] && galo[4] == galo[5])
            {
                return true;
            }
            else if (galo[6] == galo[7] && galo[7] == galo[8])
            {
                return true;
            }
            else if (galo[0] == galo[3] && galo[3] == galo[6])
            {
                return true;
            }
            else if (galo[1] == galo[4] && galo[4] == galo[7])
            {
                return true;
            }
            else if (galo[2] == galo[5] && galo[5] == galo[8])
            {
                return true;
            }
            else if (galo[0] == galo[4] && galo[4] == galo[8])
            {
                return true;
            }
            else if (galo[2] == galo[4] && galo[4] == galo[6])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //RESETS THE GAME
        public static void resetGalo()
        {
            for (int i=0; i < galo.GetLength(0); i++)
            {
                int val = i + 1;
                galo[i] = val.ToString();
            }
        }
    }
}