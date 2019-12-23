/*
 *  Purpose: Program to distrubute the 9 unique cards to 4 players.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   23-12-2019
 */

using System;

namespace ObjectOrientedProgram.DeckOfCardProgram
{
    class DeckOfCardsProgram
    {
        /// <summary>
        /// This Method is used to test the DeckOfCardsProgram class.
        /// </summary>
        public static void DeckOfCards()
        {
            try
            {

                Console.WriteLine();
                Console.WriteLine("-----------------Deck of Cards Program-----------------");
                Console.WriteLine();

                string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
                string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

                string[] checkCards = new string[52];
                string[,] cards = new string[4, 9];

                Random random = new Random();
                int count = 0, cardsCount = 0;
                bool flag = false, inputFlag=false;

                for(int i=0; i<4; i++)
                {
                    cardsCount = 0;
                    for(int j=0; j<9; j++)
                    {
                        do
                        {
                            inputFlag = false;
                            flag = false;
                            int suitsRandom = random.Next(0, 4);
                            char initial = suits[suitsRandom].ToCharArray()[0];

                            int rankRandom = random.Next(0, 13);
                            string cardsForm = initial + rank[rankRandom];

                            if(count == 0)
                            {
                                checkCards[count] = cardsForm;
                                cards[i, cardsCount] = cardsForm;
                                count++;
                                cardsCount++;
                                flag = true;
                            }
                            else
                            {
                                for(int k=0;k<count;k++)
                                {
                                    if(checkCards[k] == cardsForm)
                                    {
                                        flag = false;
                                        inputFlag = true;
                                        break;
                                    }
                                }
                                if(!inputFlag)
                                {
                                    checkCards[count] = cardsForm;
                                    cards[i, cardsCount] = cardsForm;
                                    count++;
                                    cardsCount++;
                                    flag = true;
                                }
                            }
                        } while (!flag);
                    }
                }

                for(int i=0;i<4;i++)
                {
                    for (int j = 0; j < 9; j++)
                        Console.Write(cards[i, j] + "\t");
                    Console.WriteLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}
