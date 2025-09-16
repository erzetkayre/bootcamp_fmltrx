class Program
{
    static void Main(string[] args)
    {
        DemoBasicEventHandler();
        TryAnotherCase();
        DemoUsingAction();
    }

    #region 1. Demo Event Hadler
    static void DemoBasicEventHandler()
    {
        var priceMonitor = new BasicPriceMonitor("Samsung");

        void Trader1Handler(decimal oldPrice, decimal currentPrice) =>
            Console.WriteLine($" Trader 1: Price changed from {oldPrice} to {currentPrice}");
        void Trader2Handler(decimal oldPrice, decimal currentPrice) =>
            Console.WriteLine($" Trader 2: Significant move from {oldPrice} to {currentPrice}");

        priceMonitor.PriceChanged += Trader1Handler;
        priceMonitor.PriceChanged += Trader2Handler;

        Console.WriteLine("Subscribed two traders to price changes");
        Console.WriteLine("Triggering price changes...\n");

        priceMonitor.UpdatePrice(10.00m);
        priceMonitor.UpdatePrice(20.00m);

        Console.WriteLine("\nTrader 1 unsubscribed. Only Trader 2 should receive this update:");
        priceMonitor.UpdatePrice(152.75m);

        Console.WriteLine();
    }

    static void TryAnotherCase()
    {
        var youtubeChannel = new SubscribeCounter("Windah");

        void SubsHandler1(int oldSub, int newSub) =>
            Console.WriteLine($"[Handler 1] {youtubeChannel.Youtube} subs changed from {oldSub} to {newSub}");

        void SubsHandler2(int oldSub, int newSub) =>
            Console.WriteLine($"[Handler 2] {youtubeChannel.Youtube} reached {newSub} subs!");

        youtubeChannel.Subscribed += SubsHandler1;
        youtubeChannel.Subscribed += SubsHandler2;

        Console.WriteLine("Simulating subscriber changes...\n");

        youtubeChannel.UpdateSubscriber(100);
        youtubeChannel.UpdateSubscriber(100_000);
        youtubeChannel.UpdateSubscriber(1_000_000);

        youtubeChannel.Subscribed -= SubsHandler2;
        youtubeChannel.UpdateSubscriber(10_000_000);
    }
    #endregion

    #region 2. Demo Event Handle using Action
    static void DemoUsingAction()
    {
        var notif = new EventPublisher();

        notif.SafeNotification += msg => Console.WriteLine($"Notification received: {msg}");
        notif.TriggerEvent("Hellooooooo.....");
        
    }
    #endregion

}

#region 1. Additional for Demo Event Handle
public delegate void SubscribedHandler(int oldSub, int newSub);
public class SubscribeCounter
{
    private int _subcriber;
    public string Youtube { get; }

    public event SubscribedHandler? Subscribed;

    public SubscribeCounter(string ytb)
    {
        Youtube = ytb;
        _subcriber = 0;
    }

    public void UpdateSubscriber(int newSub)
    {
        if (_subcriber != newSub)
        {
            int oldSub = _subcriber;
            _subcriber = newSub;

            Subscribed?.Invoke(oldSub, newSub);
        }
    }
}
public delegate void PriceChangedHandler(decimal oldPrice, decimal currentPrice);
public class BasicPriceMonitor
{
    private decimal _currentPrice;
    public string Symbol { get; }

    public event PriceChangedHandler? PriceChanged;

    public BasicPriceMonitor(string symbol)
    {
        Symbol = symbol;
        _currentPrice = 0;
    }

    public void UpdatePrice(decimal currentPrice)
    {
        if (_currentPrice != currentPrice)
        {
            decimal oldPrice = _currentPrice;
            _currentPrice = currentPrice;

            PriceChanged?.Invoke(oldPrice, currentPrice);
        }
    }
}
#endregion

#region Additional 2. Demo Event Handler using Action
public class EventPublisher
{
    public event Action<string>? SafeNotification;

    public void TriggerEvent(string msg)
    {
        Console.WriteLine($"Message: {msg}");
        SafeNotification?.Invoke(msg);
    }

}
#endregion