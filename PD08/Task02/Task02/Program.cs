using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.BL;

namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt = 0;
            do 
            {
                Console.WriteLine("Enter 1 to play game or enter 2 to exit: ");
                opt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Clear();
                if (opt == 1)
                {
                    bool gameRunning = true;
                    int score = 0;
                    Deck obj = new Deck();
                    obj.shuffle();
                    Card card1 = obj.dealCard();
                    while (gameRunning)
                    {
                        int remain_check = obj.cardsLeft();
                        Card card2 = obj.dealCard();
                        Console.WriteLine("******************************");
                        Console.WriteLine(card1);
                        Console.WriteLine("");
                        Console.WriteLine("******* Remaining Cards *** " + remain_check);
                        Console.WriteLine("Enter 1 if next card is higher or enter 2 if next card is lower: ");
                        int check_card = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (check_card == 1)
                        {
                            if (card2.getValue() >= card1.getValue())
                            {
                                score++;
                                card1 = card2;
                            }
                            else
                            {
                                Console.WriteLine("Sorry you lose! Press any key to continue");
                                Console.WriteLine("The card was: " + card2);
                                Console.WriteLine("Your score: " + score);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        }
                        else if (check_card == 2)
                        {
                            if (card2.getValue() < card1.getValue())
                            {
                                score++;
                                card1 = card2;
                            }
                            else
                            {
                                Console.WriteLine("Sorry you lose! Press any key to continue");
                                Console.WriteLine("The card was: " + card2);
                                Console.WriteLine("Your score: " + score);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        }
                        if (obj.cardsLeft() == 0 || card2 == null)
                        {
                            gameRunning = false;
                            Console.WriteLine("Congratulations! You have got maximum score");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                }
                
            } while (opt != 2);
        }
    }
}
