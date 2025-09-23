using System;
using System.Collections.Generic;

class Program
{
    static List<string> unoDeck = new List<string>();
    static List<string> discards = new List<string>();
    static List<List<string>> players = new List<List<string>>();
    static List<string> playersName = new List<string>();
    static string[] colours = { "Red", "Green", "Yellow", "Blue" };
    static Random rand = new Random();

    static void Main()
    {
        Console.WriteLine("\n\n============== UNO Card Game ==============\n\n");

        unoDeck = BuildDeck();
        ShuffleDeck(unoDeck);
        ShuffleDeck(unoDeck);

        int numPlayers;
        do
        {
            Console.Write("How many players? (2-4): ");
        } while (!int.TryParse(Console.ReadLine(), out numPlayers) || numPlayers < 2 || numPlayers > 4);

        for (int i = 0; i < numPlayers; i++)
        {
            Console.Write($"Enter player {i + 1} name: ");
            playersName.Add(Console.ReadLine());
            players.Add(DrawCards(5));
        }

        int playerTurn = 0;
        int playDirection = 1;
        bool playing = true;

        discards.Add(unoDeck[0]);
        unoDeck.RemoveAt(0);

        string[] splitCard = discards[0].Split(" ", 2);
        string currentColour = splitCard[0];
        string cardVal = currentColour != "Wild" ? splitCard[1] : "Any";

        string winner = "";

        while (playing)
        {
            ShowHand(playerTurn, players[playerTurn]);
            Console.WriteLine("Card on top of discard pile: " + discards[^1]);

            if (CanPlay(currentColour, cardVal, players[playerTurn]))
            {
                int cardChosen;
                do
                {
                    Console.Write("Which card do you want to play? ");
                } while (!int.TryParse(Console.ReadLine(), out cardChosen) ||
                         cardChosen < 1 || cardChosen > players[playerTurn].Count ||
                         !CanPlay(currentColour, cardVal, new List<string> { players[playerTurn][cardChosen - 1] }));

                string playedCard = players[playerTurn][cardChosen - 1];
                Console.WriteLine("You played " + playedCard);

                discards.Add(playedCard);
                players[playerTurn].RemoveAt(cardChosen - 1);

                if (players[playerTurn].Count == 0)
                {
                    playing = false;
                    winner = playersName[playerTurn];
                    break;
                }

                splitCard = discards[^1].Split(" ", 2);
                currentColour = splitCard[0];
                cardVal = splitCard.Length > 1 ? splitCard[1] : "Any";

                if (currentColour == "Wild")
                {
                    for (int x = 0; x < colours.Length; x++)
                    {
                        Console.WriteLine($"{x + 1}) {colours[x]}");
                    }
                    int newColour;
                    do
                    {
                        Console.Write("What colour would you like to choose? ");
                    } while (!int.TryParse(Console.ReadLine(), out newColour) || newColour < 1 || newColour > 4);

                    currentColour = colours[newColour - 1];
                }

                if (cardVal == "Reverse")
                {
                    playDirection *= -1;
                }
                else if (cardVal == "Skip")
                {
                    playerTurn += playDirection;
                    if (playerTurn >= numPlayers) playerTurn = 0;
                    else if (playerTurn < 0) playerTurn = numPlayers - 1;
                }
                else if (cardVal == "Draw Two")
                {
                    int playerDraw = (playerTurn + playDirection + numPlayers) % numPlayers;
                    players[playerDraw].AddRange(DrawCards(2));
                }
                else if (cardVal == "Draw Four")
                {
                    int playerDraw = (playerTurn + playDirection + numPlayers) % numPlayers;
                    players[playerDraw].AddRange(DrawCards(4));
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You can't play. You have to draw a card.");
                players[playerTurn].AddRange(DrawCards(1));
            }

            playerTurn += playDirection;
            if (playerTurn >= numPlayers) playerTurn = 0;
            else if (playerTurn < 0) playerTurn = numPlayers - 1;
        }

        Console.WriteLine("Game Over");
        Console.WriteLine($"{winner} is the Winner!");
    }

    static List<string> BuildDeck()
    {
        List<string> deck = new List<string>();
        string[] values = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Draw Two", "Skip", "Reverse" };
        string[] wilds = { "Wild", "Wild Draw Four" };

        foreach (string colour in colours)
        {
            foreach (string value in values)
            {
                deck.Add($"{colour} {value}");
                if (value != "0") deck.Add($"{colour} {value}");
            }
        }

        for (int i = 0; i < 4; i++)
        {
            deck.Add(wilds[0]);
            deck.Add(wilds[1]);
        }

        return deck;
    }

    static void ShuffleDeck(List<string> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randPos = rand.Next(deck.Count);
            (deck[i], deck[randPos]) = (deck[randPos], deck[i]);
        }
    }

    static List<string> DrawCards(int numCards)
    {
        List<string> cardsDrawn = new List<string>();
        for (int i = 0; i < numCards; i++)
        {
            cardsDrawn.Add(unoDeck[0]);
            unoDeck.RemoveAt(0);
        }
        return cardsDrawn;
    }

    static void ShowHand(int player, List<string> playerHand)
    {
        Console.WriteLine($"Player {playersName[player]}'s Turn");
        Console.WriteLine("Your Hand");
        Console.WriteLine("------------------");
        for (int i = 0; i < playerHand.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {playerHand[i]}");
        }
        Console.WriteLine();
    }

    static bool CanPlay(string colour, string value, List<string> playerHand)
    {
        foreach (string card in playerHand)
        {
            if (card.Contains("Wild")) return true;
            if (card.Contains(colour) || card.Contains(value)) return true;
        }
        return false;
    }
}
