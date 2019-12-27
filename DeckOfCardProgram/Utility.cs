/*
 *  Purpose: The Utility Class is used to store the logic of the Data Structure Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   27-12-2019
 * 
 */

using System;
using ObjectOrientedProgram.Core;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.DeckOfCardProgram
{
    class Utility
    {
        public static int init = 0;
        public static int end = 0;
        public static string[] checkCards = new string[52];

        /// <summary>
        /// If the Conversion from string to int is not possible
        /// then it prints the error message.
        /// </summary>
        /// <param name="flag"></param>
        public static void ErrorMessage(bool flag)
        {
            if (!flag)
                Console.WriteLine("Please Input the Number !!!");
        }


        public static void SortDeckOfCards()
        {
            for (int i=init;i<end;i++)
            {
                for(int j=init;j<end;j++)
                {
                    int result = checkCards[i].CompareTo(checkCards[j]);

                    if(result < 0)
                    {
                        string temp = checkCards[i];
                        checkCards[i] = checkCards[j];
                        checkCards[j] = temp;
                    }

                }
            }

        }


        public static QueueLinkedList DeckOfCard(string[] suits, string[] rank)
        {
            QueueLinkedList queueLinkedList = new QueueLinkedList();

            Random random = new Random();
            
            for (int j = 0; j < 9; j++)
            {
                bool flag;
                do
                {
                    bool inputFlag = false;
                    flag = false;
                    int suitsRandom = random.Next(0, 4);
                    char initial = suits[suitsRandom].ToCharArray()[0];

                    int rankRandom = random.Next(0, 13);
                    string cardsForm = rank[rankRandom] + initial;

                    if (end == 0)
                    {
                        checkCards[end] = cardsForm;
                        end++;
                        flag = true;
                    }
                    else
                    {
                        for (int k = 0; k < end; k++)
                        {
                            if (checkCards[k] == cardsForm)
                            {
                                flag = false;
                                inputFlag = true;
                                break;
                            }
                        }
                        if (!inputFlag)
                        {
                            checkCards[end] = cardsForm;
                            end++;
                            flag = true;
                        }
                    }
                } while (!flag);
            }
            SortDeckOfCards();

            for (int i = init; i < end; i++)
                queueLinkedList.Enqueue(checkCards[i]);

            init = end;

            return queueLinkedList;
        }

    }
}
