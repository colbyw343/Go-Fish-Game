using System;
using System.Collections.Generic;
using System.Linq;

namespace GoFishGame
{
    class Program
    {
        public static string[] Cards = new string[52];
        public static List<string> playerHand = new List<string>();
        public static List<string> opponentHand = new List<string>();
        public static int playerBookCount = 0;
        public static int opponentBookCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Go-Fish!");
            Console.ReadLine();
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            //Giving the player a name
            Player player1 = new Player()
            {
                Name = playerName.ToString()
            };
            Console.WriteLine($"Hello {player1.Name}, what would you like to name your opponent?");
            string opponentName = Console.ReadLine();
            //Giving the opponent a name
            Opponent opponent1 = new Opponent()
            {
                Name = opponentName.ToString()
            };
            Console.WriteLine($"So you, {player1.Name}, are going up against {opponent1.Name}.");
            Console.ReadLine();
            //Setting the deck
            Cards[0] = "Ace";
            Cards[1] = "Ace";
            Cards[2] = "Ace";
            Cards[3] = "Ace";
            Cards[4] = "2";
            Cards[5] = "2";
            Cards[6] = "2";
            Cards[7] = "2";
            Cards[8] = "3";
            Cards[9] = "3";
            Cards[10] = "3";
            Cards[11] = "3";
            Cards[12] = "4";
            Cards[13] = "4";
            Cards[14] = "4";
            Cards[15] = "4";
            Cards[16] = "5";
            Cards[17] = "5";
            Cards[18] = "5";
            Cards[19] = "5";
            Cards[20] = "6";
            Cards[21] = "6";
            Cards[22] = "6";
            Cards[23] = "6";
            Cards[24] = "7";
            Cards[25] = "7";
            Cards[26] = "7";
            Cards[27] = "7";
            Cards[28] = "8";
            Cards[29] = "8";
            Cards[30] = "8";
            Cards[31] = "8";
            Cards[32] = "9";
            Cards[33] = "9";
            Cards[34] = "9";
            Cards[35] = "9";
            Cards[36] = "10";
            Cards[37] = "10";
            Cards[38] = "10";
            Cards[39] = "10";
            Cards[40] = "Jack";
            Cards[41] = "Jack";
            Cards[42] = "Jack";
            Cards[43] = "Jack";
            Cards[44] = "Queen";
            Cards[45] = "Queen";
            Cards[46] = "Queen";
            Cards[47] = "Queen";
            Cards[48] = "King";
            Cards[49] = "King";
            Cards[50] = "King";
            Cards[51] = "King";
            PlayerHand();
            player1.Hand = playerHand;
            OpponentHand();
            opponent1.Hand = opponentHand;
            Console.WriteLine("Now that both players have cards, let's play");
            while (playerBookCount < 5 || opponentBookCount < 5)
            {
                PlayerTurn();
                if (playerBookCount >= 5)
                {
                    Console.Clear();
                    Console.WriteLine($"Congratulations {player1.Name}! You've won the go-fish game against {opponent1.Name}!");
                    Console.ReadLine();
                    break;
                }
                Console.WriteLine("So now the cards you have are:");
                foreach (object card in playerHand)
                {
                    Console.Write("|" + card + "| ");
                }
                Console.ReadLine();
                OpponentTurn();

                if (opponentBookCount >= 5)
                {
                    Console.Clear();
                    Console.WriteLine($"Aw man, looks like {opponent1.Name} beat you!");
                    Console.ReadLine();
                    break;
                }
            }
            return;
        }
        //Giving the player cards
        public static void PlayerHand()
        {
            Random random = new Random();
            int card1 = random.Next(0, 51);
            string firstCard = Cards[card1];
            int card2 = random.Next(0, 51);
            string secondCard = Cards[card2];
            int card3 = random.Next(0, 51);
            string thirdCard = Cards[card3];
            int card4 = random.Next(0, 51);
            string fourthCard = Cards[card4];
            int card5 = random.Next(0, 51);
            string fifthCard = Cards[card5];
            playerHand.Add(firstCard);
            playerHand.Add(secondCard);
            playerHand.Add(thirdCard);
            playerHand.Add(fourthCard);
            playerHand.Add(fifthCard);
            Console.WriteLine("The cards you have in your hand are:");
            foreach (object card in playerHand)
            {
                Console.Write("|" + card + "| ");
            }
            Console.ReadLine();
        }
        //Giving the opponent cards
        public static void OpponentHand()
        {
            Random random = new Random();
            int card1 = random.Next(0, 51);
            string firstCard = Cards[card1];
            int card2 = random.Next(0, 51);
            string secondCard = Cards[card2];
            int card3 = random.Next(0, 51);
            string thirdCard = Cards[card3];
            int card4 = random.Next(0, 51);
            string fourthCard = Cards[card4];
            int card5 = random.Next(0, 51);
            string fifthCard = Cards[card5];

            opponentHand.Add(firstCard);
            opponentHand.Add(secondCard);
            opponentHand.Add(thirdCard);
            opponentHand.Add(fourthCard);
            opponentHand.Add(fifthCard);
            Console.WriteLine("The opponent now has cards as well");
            Console.ReadLine();
        }

        public static void PlayerTurn()
        {
            Console.Clear();
            playerHand.Sort();
            Console.WriteLine($"Your book count is {playerBookCount}.");
            Console.WriteLine("Your cards are:");
            foreach (string card in playerHand)
            {
                Console.Write("|" + card + "| ");
            }
            Console.ReadLine();
            Console.WriteLine("What card would you like to fish for from the opponent?");
            string cardSteal = Console.ReadLine();


            if (playerHand.Contains(cardSteal))
            {
                if (opponentHand.Contains(cardSteal))
                {
                    int cardCount = opponentHand.Where(s => s != null && s == cardSteal).Count();
                    if (cardCount > 1)
                    {
                        Console.WriteLine($"Your opponent had {cardCount} of those cards!");
                    }
                    if (cardCount == 1)
                    {
                        Console.WriteLine("Your opponent only had 1 of those cards!");
                    }
                    opponentHand.RemoveAll(t => t == cardSteal);
                    for (int i = 0; i < cardCount; i++)
                    {
                        playerHand.Add(cardSteal);
                    }
                    Console.ReadLine();
                    if (playerHand.Where(s => s != null && s == "Ace").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("Ace");
                        playerHand.Remove("Ace");
                        playerHand.Remove("Ace");
                        playerHand.Remove("Ace");
                        Console.WriteLine("Way to go! You now have a book of Aces!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "2").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("2");
                        playerHand.Remove("2");
                        playerHand.Remove("2");
                        playerHand.Remove("2");
                        Console.WriteLine("Way to go! You now have a book of 2's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "3").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("3");
                        playerHand.Remove("3");
                        playerHand.Remove("3");
                        playerHand.Remove("3");
                        Console.WriteLine("Way to go! You now have a book of 3's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "4").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("4");
                        playerHand.Remove("4");
                        playerHand.Remove("4");
                        playerHand.Remove("4");
                        Console.WriteLine("Way to go! You now have a book of 4's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "5").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("5");
                        playerHand.Remove("5");
                        playerHand.Remove("5");
                        playerHand.Remove("5");
                        Console.WriteLine("Way to go! You now have a book of 5's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "6").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("6");
                        playerHand.Remove("6");
                        playerHand.Remove("6");
                        playerHand.Remove("6");
                        Console.WriteLine("Way to go! You now have a book of 6's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "7").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("7");
                        playerHand.Remove("7");
                        playerHand.Remove("7");
                        playerHand.Remove("7");
                        Console.WriteLine("Way to go! You now have a book of 7's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "8").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("8");
                        playerHand.Remove("8");
                        playerHand.Remove("8");
                        playerHand.Remove("8");
                        Console.WriteLine("Way to go! You now have a book of 8's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "9").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("9");
                        playerHand.Remove("9");
                        playerHand.Remove("9");
                        playerHand.Remove("9");
                        Console.WriteLine("Way to go! You now have a book of 9's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "10").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("10");
                        playerHand.Remove("10");
                        playerHand.Remove("10");
                        playerHand.Remove("10");
                        Console.WriteLine("Way to go! You now have a book of 10's!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "Jack").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("Jack");
                        playerHand.Remove("Jack");
                        playerHand.Remove("Jack");
                        playerHand.Remove("Jack");
                        Console.WriteLine("Way to go! You now have a book of Jacks!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "Queen").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("Queen");
                        playerHand.Remove("Queen");
                        playerHand.Remove("Queen");
                        playerHand.Remove("Queen");
                        Console.WriteLine("Way to go! You now have a book of Queens!");
                        Console.ReadLine();
                    }
                    if (playerHand.Where(s => s != null && s == "King").Count() >= 4)
                    {
                        playerBookCount++;
                        playerHand.Remove("King");
                        playerHand.Remove("King");
                        playerHand.Remove("King");
                        playerHand.Remove("King");
                        Console.WriteLine("Way to go! You now have a book of Kings!");
                        Console.ReadLine();
                    }
                    //In traditional go fish rules, if the player either gets the card they want from the opponent, or from the deck, they get to go again.
                    Console.WriteLine("Since you got a card from the opponent, you get to go again!");
                    Console.ReadLine();
                    PlayerTurn();
                    return;
                }
                Console.WriteLine("Darn, looks like you'll have to go fish!");
                //Player goes fish and it randomly selects a card from the deck
                Random rnd = new Random();
                int goFish = rnd.Next(0, 51);
                string goFishCard = Cards[goFish];
                Console.WriteLine($"The card you got was {goFishCard}.");
                Console.ReadLine();
                playerHand.Add(goFishCard);


                //Check for any books
                if (playerHand.Where(s => s != null && s == "Ace").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("Ace");
                    playerHand.Remove("Ace");
                    playerHand.Remove("Ace");
                    playerHand.Remove("Ace");
                    Console.WriteLine("Way to go! You now have a book of Aces!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "2").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("2");
                    playerHand.Remove("2");
                    playerHand.Remove("2");
                    playerHand.Remove("2");
                    Console.WriteLine("Way to go! You now have a book of 2's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "3").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("3");
                    playerHand.Remove("3");
                    playerHand.Remove("3");
                    playerHand.Remove("3");
                    Console.WriteLine("Way to go! You now have a book of 3's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "4").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("4");
                    playerHand.Remove("4");
                    playerHand.Remove("4");
                    playerHand.Remove("4");
                    Console.WriteLine("Way to go! You now have a book of 4's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "5").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("5");
                    playerHand.Remove("5");
                    playerHand.Remove("5");
                    playerHand.Remove("5");
                    Console.WriteLine("Way to go! You now have a book of 5's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "6").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("6");
                    playerHand.Remove("6");
                    playerHand.Remove("6");
                    playerHand.Remove("6");
                    Console.WriteLine("Way to go! You now have a book of 6's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "7").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("7");
                    playerHand.Remove("7");
                    playerHand.Remove("7");
                    playerHand.Remove("7");
                    Console.WriteLine("Way to go! You now have a book of 7's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "8").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("8");
                    playerHand.Remove("8");
                    playerHand.Remove("8");
                    playerHand.Remove("8");
                    Console.WriteLine("Way to go! You now have a book of 8's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "9").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("9");
                    playerHand.Remove("9");
                    playerHand.Remove("9");
                    playerHand.Remove("9");
                    Console.WriteLine("Way to go! You now have a book of 9's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "10").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("10");
                    playerHand.Remove("10");
                    playerHand.Remove("10");
                    playerHand.Remove("10");
                    Console.WriteLine("Way to go! You now have a book of 10's!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "Jack").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("Jack");
                    playerHand.Remove("Jack");
                    playerHand.Remove("Jack");
                    playerHand.Remove("Jack");
                    Console.WriteLine("Way to go! You now have a book of Jacks!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "Queen").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("Queen");
                    playerHand.Remove("Queen");
                    playerHand.Remove("Queen");
                    playerHand.Remove("Queen");
                    Console.WriteLine("Way to go! You now have a book of Queens!");
                    Console.ReadLine();
                }
                if (playerHand.Where(s => s != null && s == "King").Count() >= 4)
                {
                    playerBookCount++;
                    playerHand.Remove("King");
                    playerHand.Remove("King");
                    playerHand.Remove("King");
                    playerHand.Remove("King");
                    Console.WriteLine("Way to go! You now have a book of Kings!");
                    Console.ReadLine();
                }


                if (goFishCard == cardSteal)
                {
                    Console.WriteLine("Awesome! You got the card you wanted! you get to go again!");
                    Console.ReadLine();
                    PlayerTurn();
                    return;
                }
                //End their turn
                return;
            }
            //This is a test case for if the player asks for a card that they dont have
            if (!playerHand.Contains(cardSteal))
            {
                Console.WriteLine("Woops! Since you don't have this card, try and pick another one!");
                Console.ReadLine();
                PlayerTurn();
                return;
            }

        }

        public static void OpponentTurn()
        {
            Console.Clear();
            Console.WriteLine($"The opponent's book count is {opponentBookCount}.");
            Console.WriteLine("The opponent will now try and fish for one of your cards.");
            Console.ReadLine();
            Random rnd = new Random();
            int card = rnd.Next(0, opponentHand.Count);
            string opponentFish = opponentHand[card];
            Console.WriteLine($"The opponent has asked you for a {opponentFish}");
            Console.ReadLine();

            //If the player had that card, it will remove those cards and add them to the opponent
            if (playerHand.Contains(opponentFish))
            {
                int cardCount = playerHand.Where(s => s != null && s == opponentFish).Count();
                if (cardCount > 1)
                {
                    Console.WriteLine($"Oh man, looks like your opponent stole {cardCount} cards from you");
                }
                if (cardCount == 1)
                {
                    Console.WriteLine($"Oh man, looks like your opponent stole 1 card from you");
                }
                playerHand.RemoveAll(t => t == opponentFish);
                for (int i = 0; i < cardCount; i++)
                {
                    opponentHand.Add(opponentFish);
                }
                Console.ReadLine();
                Console.WriteLine("Because they stole from you, they get to go again!");
                Console.ReadLine();
                OpponentTurn();
                return;
            }
            //If the player didn't have that card, it will randomly select one from the deck
            Console.WriteLine("Phew! You didn't have that card, so the opponent has to go fish!");
            Random random = new Random();
            int cpuCard = random.Next(0, 51);
            string opponentGoFish = Cards[cpuCard];
            opponentHand.Add(opponentGoFish);
            Console.ReadLine();
            //If the opponent got the card they wanted from the deck, they go again 
            if (opponentGoFish == opponentFish)
            {
                Console.WriteLine("Darn! The opponent got the card that they wanted! They get to go again!");
                Console.ReadLine();
                OpponentTurn();
            }
            if (opponentHand.Where(s => s != null && s == "1").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("Ace");
                opponentHand.Remove("Ace");
                opponentHand.Remove("Ace");
                opponentHand.Remove("Ace");
                Console.WriteLine("Darn! Looks like your opponent got a book of Aces!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "2").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("2");
                opponentHand.Remove("2");
                opponentHand.Remove("2");
                opponentHand.Remove("2");
                Console.WriteLine("Darn! Looks like your opponent got a book of 2's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "3").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("3");
                opponentHand.Remove("3");
                opponentHand.Remove("3");
                opponentHand.Remove("3");
                Console.WriteLine("Darn! Looks like your opponent got a book of 3's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "4").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("4");
                opponentHand.Remove("4");
                opponentHand.Remove("4");
                opponentHand.Remove("4");
                Console.WriteLine("Darn! Looks like your opponent got a book of 4's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "5").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("5");
                opponentHand.Remove("5");
                opponentHand.Remove("5");
                opponentHand.Remove("5");
                Console.WriteLine("Darn! Looks like your opponent got a book of 5's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "6").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("6");
                opponentHand.Remove("6");
                opponentHand.Remove("6");
                opponentHand.Remove("6");
                Console.WriteLine("Darn! Looks like your opponent got a book of 6's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "7").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("7");
                opponentHand.Remove("7");
                opponentHand.Remove("7");
                opponentHand.Remove("7");
                Console.WriteLine("Darn! Looks like your opponent got a book of 7's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "8").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("8");
                opponentHand.Remove("8");
                opponentHand.Remove("8");
                opponentHand.Remove("8");
                Console.WriteLine("Darn! Looks like your opponent got a book of 8's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "9").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("9");
                opponentHand.Remove("9");
                opponentHand.Remove("9");
                opponentHand.Remove("9");
                Console.WriteLine("Darn! Looks like your opponent got a book of 9's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "10").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("10");
                opponentHand.Remove("10");
                opponentHand.Remove("10");
                opponentHand.Remove("10");
                Console.WriteLine("Darn! Looks like your opponent got a book of 10's!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "Jack").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("Jack");
                opponentHand.Remove("Jack");
                opponentHand.Remove("Jack");
                opponentHand.Remove("Jack");
                Console.WriteLine("Darn! Looks like your opponent got a book of Jacks!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "Queen").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("Queen");
                opponentHand.Remove("Queen");
                opponentHand.Remove("Queen");
                opponentHand.Remove("Queen");
                Console.WriteLine("Darn! Looks like your opponent got a book of Queens!");
                Console.ReadLine();
            }
            if (opponentHand.Where(s => s != null && s == "King").Count() >= 4)
            {
                opponentBookCount++;
                opponentHand.Remove("King");
                opponentHand.Remove("King");
                opponentHand.Remove("King");
                opponentHand.Remove("King");
                Console.WriteLine("Darn! Looks like your opponent got a book of Kings!");
                Console.ReadLine();
            }
            return;
        }
    }
}
