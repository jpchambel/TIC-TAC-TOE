using System;

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
            
            while (ins1 != "quit" && ins2 != "quit" )
            {      
                //PLAYER 1 INPUT
                bool sucInput1 = false;
                while (sucInput1 == false | input1 > 9 | input1 < 1)
                {
                    printGalo();
                    Console.WriteLine("Playing...");
                    Console.Write("\n \nPlayer (O), make your move:");
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

                //QUIT OR KEEP PLAYING 
                if (ins1 == "quit")
                    break;
                else if(ins1 != "reset")
                    galo[input1 - 1] = "O";

                //WIN or GAME OVER TEST: PLAYER_1
                bool win1 = winTest();
                bool win4 = gameOverTest();
                if (win1 == true) 
                {
                    printGalo();
                    Console.WriteLine("Player (O) wins!!!");
                    Console.Write("\n \nPress any key to reset the game");
                    Console.ReadLine();
                    resetGalo();
                }else if (win4 == true)
                {
                    printGalo();
                    Console.WriteLine("Game over");
                    Console.Write("\n \nPress any key to reset the game");
                    Console.ReadLine();
                    resetGalo();
                }

                //PLAYER 2 INPUT
                bool sucInput2 = false;
                while (sucInput2 == false | input2 > 9 | input2 < 0)
                {
                    printGalo();
                    Console.WriteLine("Playing...");
                    Console.Write("\n \nPlayer (X), make your move:");
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

                //QUIT OR KEEP PLAYING 
                if (ins2 == "quit")
                    break;
                else if (ins2 != "reset")
                    galo[input2 - 1] = "X";

                //WIN or GAME OVER TEST: PLAYER 2
                bool win2 = winTest();
                bool win3 = gameOverTest();
                if (win2 == true)
                {
                    printGalo();
                    Console.WriteLine("Player (X) wins!!!");
                    Console.WriteLine("\n \nPress any key to reset the game");
                    Console.ReadLine();
                    resetGalo();
                }
                else if (win3 == true)
                {
                    printGalo();
                    Console.WriteLine("Game over");
                    Console.WriteLine("\n \nPress any key to reset the game");
                    Console.ReadLine();
                    resetGalo();
                }
            }

            //FINAL MESSAGE
            Console.Clear();
            Console.WriteLine("Thanks for playing! See you next time buddy!!");
            Console.ReadLine();
        }

        public static void printGalo()
        {
            //GAME GENERATOR
            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", galo[0], galo[1], galo[2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", galo[3], galo[4], galo[5]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", galo[6], galo[7], galo[8]);
            Console.WriteLine("   |   |   ");
            Console.WriteLine("\nType available position: 1-9");
            Console.WriteLine("Type 'reset' to reset the game.");
            Console.WriteLine("Type 'quit' to quit the game.\n \n");
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

        //CHECKS FOR GAME OVER
        public static bool gameOverTest()
        {
            bool gameover = false;
            bool gameover1 = false;
            foreach (var item in galo)
            {
                if (item == "X" | item == "O")
                    gameover = true;
                else
                    gameover1 = true;

            }

            if (gameover1 == false)
                return true;
            else
                return false;

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
