using System;
using System.Collections.Generic;
using System.Linq;

namespace UnoUserVsBot
{
    public enum CardColor { Red, Blue, Green, Yellow, Wild }
    public enum CardValue { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine,
                            Skip, Reverse, DrawTwo, Wild, WildDrawFour }

    // ================== BASE CARD ==================
    public abstract class Card
    {
        public CardColor Color { get; protected set; }
        public CardValue Value { get; protected set; }

        protected Card(CardColor color, CardValue value)
        {
            Color = color;
            Value = value;
        }

        public virtual void SetColor(CardColor newColor)
        {
            if (this.Color != CardColor.Wild)
                throw new InvalidOperationException("Only wild cards can change color.");
            this.Color = newColor;
        }
        public virtual bool IsPlayableOnTop(Card topCard)
        {
            return Color == topCard.Color || Value == topCard.Value || Color == CardColor.Wild;
        }

        public virtual void ApplyEffect(UnoGame game) { }

        public override string ToString() => $"{Color} {Value}";
    }

    // ================== NUMBER CARD ==================
    public class NumberCard : Card
    {
        public NumberCard(CardColor color, CardValue value) : base(color, value) { }
    }

    // ================== ACTION CARDS ==================
    public class SkipCard : Card
    {
        public SkipCard(CardColor color) : base(color, CardValue.Skip) { }
        public override void ApplyEffect(UnoGame game)
        {
            Console.WriteLine("Effect: Skip next player!");
            game.SkipNextPlayer();
        }
    }

    public class ReverseCard : Card
    {
        public ReverseCard(CardColor color) : base(color, CardValue.Reverse) { }
        public override void ApplyEffect(UnoGame game)
        {
            Console.WriteLine("Effect: Reverse turn!");
            game.ReverseTurn();
        }
    }

    public class DrawTwoCard : Card
    {
        public DrawTwoCard(CardColor color) : base(color, CardValue.DrawTwo) { }
        public override void ApplyEffect(UnoGame game)
        {
            Console.WriteLine("Effect: Next player draws 2!");
            game.DrawCardsToNextPlayer(2);
        }
    }

    // ================== WILD CARDS ==================
    public class WildCard : Card
    {
        public WildCard() : base(CardColor.Wild, CardValue.Wild) { }
        public override void ApplyEffect(UnoGame game)
        {
            Console.WriteLine("Effect: Player chooses color!");
            game.ChooseNewColor(this);
        }
    }

    public class WildDrawFourCard : Card
    {
        public WildDrawFourCard() : base(CardColor.Wild, CardValue.WildDrawFour) { }
        public override void ApplyEffect(UnoGame game)
        {
            Console.WriteLine("Effect: Next player draws 4 + choose color!");
            game.DrawCardsToNextPlayer(4);
            game.ChooseNewColor(this);
        }
    }

    // ================== DECK & DISCARD ==================
    public class Deck
    {
        private Stack<Card> cards = new Stack<Card>();
        private static Random rand = new Random();

        public Deck() { GenerateDeck(); Shuffle(); }

        private void GenerateDeck()
        {
            foreach (CardColor color in new[] { CardColor.Red, CardColor.Blue, CardColor.Green, CardColor.Yellow })
            {
                cards.Push(new NumberCard(color, CardValue.One));
                cards.Push(new SkipCard(color));
                cards.Push(new ReverseCard(color));
                cards.Push(new DrawTwoCard(color));
            }
            cards.Push(new WildCard());
            cards.Push(new WildDrawFourCard());
        }

        public void Shuffle()
        {
            var list = cards.ToList();
            cards.Clear();
            foreach (var c in list.OrderBy(x => rand.Next()))
                cards.Push(c);
        }

        public Card Draw() => cards.Count > 0 ? cards.Pop() : null;
    }

    public class DiscardPile
    {
        private List<Card> cards = new List<Card>();
        public void AddCard(Card c) => cards.Add(c);
        public Card TopCard() => cards.LastOrDefault();
    }

    // ================== PLAYER ==================
    public class Player
    {
        public string Name { get; }
        public bool IsBot { get; }
        public List<Card> Hand { get; } = new List<Card>();

        public Player(string name, bool isBot = false)
        {
            Name = name;
            IsBot = isBot;
        }

        public void DrawCard(Deck deck)
        {
            var c = deck.Draw();
            if (c != null) Hand.Add(c);
        }

        public void ShowHand()
        {
            for (int i = 0; i < Hand.Count; i++)
                Console.WriteLine($"{i + 1}. {Hand[i]}");
        }

        public bool HasWon() => Hand.Count == 0;
    }

    // ================== GAME ==================
    public class UnoGame
    {
        private Deck deck = new Deck();
        private DiscardPile discard = new DiscardPile();
        private List<Player> players = new List<Player>();
        private int currentIndex = 0;
        private int direction = 1;

        public void AddPlayer(Player p) => players.Add(p);

        public void StartGame()
        {
            foreach (var p in players)
                for (int i = 0; i < 5; i++) p.DrawCard(deck);

            discard.AddCard(deck.Draw());
            Console.WriteLine($"First card: {discard.TopCard()}");

            while (true)
            {
                var current = players[currentIndex];
                Console.WriteLine($"\n=== {current.Name}'s turn ===");
                Console.WriteLine($"Top card: {discard.TopCard()}");

                if (current.IsBot)
                    BotPlay(current);
                else
                    UserPlay(current);

                if (current.HasWon())
                {
                    Console.WriteLine($"{current.Name} wins!");
                    break;
                }

                NextPlayer();
            }
        }

        private void UserPlay(Player user)
        {
            Console.WriteLine("Your hand:");
            user.ShowHand();
            Console.WriteLine("Choose card number to play or 0 to draw:");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > user.Hand.Count)
                Console.WriteLine("Invalid choice, try again:");

            if (choice == 0)
            {
                user.DrawCard(deck);
                Console.WriteLine("You drew a card.");
                return;
            }

            var chosen = user.Hand[choice - 1];
            if (!chosen.IsPlayableOnTop(discard.TopCard()))
            {
                Console.WriteLine("Card not playable, you must draw instead!");
                user.DrawCard(deck);
                return;
            }

            user.Hand.Remove(chosen);
            discard.AddCard(chosen);
            Console.WriteLine($"You played {chosen}");
            chosen.ApplyEffect(this);
        }

        private void BotPlay(Player bot)
        {
            var card = bot.Hand.FirstOrDefault(c => c.IsPlayableOnTop(discard.TopCard()));
            if (card != null)
            {
                bot.Hand.Remove(card);
                discard.AddCard(card);
                Console.WriteLine($"{bot.Name} plays {card}");
                card.ApplyEffect(this);
            }
            else
            {
                bot.DrawCard(deck);
                Console.WriteLine($"{bot.Name} draws a card.");
            }
        }

        private void NextPlayer()
        {
            currentIndex = (currentIndex + direction + players.Count) % players.Count;
        }

        // Effects
        public void SkipNextPlayer() => NextPlayer();
        public void ReverseTurn() => direction *= -1;
        public void DrawCardsToNextPlayer(int n)
        {
            int next = (currentIndex + direction + players.Count) % players.Count;
            for (int i = 0; i < n; i++) players[next].DrawCard(deck);
        }

        public void ChooseNewColor(Card card)
        {
            var current = players[currentIndex];
            CardColor chosenColor;

            if (current.IsBot)
            {
                chosenColor = CardColor.Red; // Bot always pick Red
                Console.WriteLine($"{current.Name} chooses {chosenColor}");
            }
            else
            {
                Console.WriteLine("Choose a color (Red/Blue/Green/Yellow):");
                while (!Enum.TryParse(Console.ReadLine(), true, out chosenColor) ||
                       chosenColor == CardColor.Wild)
                {
                    Console.WriteLine("Invalid, choose again:");
                }
            }
            card.SetColor(chosenColor);
        }
    }

    // ================== MAIN ==================
    class Program
    {
        static void Main(string[] args)
        {
            var game = new UnoGame();
            game.AddPlayer(new Player("You")); // user
            game.AddPlayer(new Player("Bot", isBot: true)); // bot
            game.StartGame();
        }
    }
}
