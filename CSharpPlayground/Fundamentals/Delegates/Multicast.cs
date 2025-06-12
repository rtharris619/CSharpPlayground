namespace CSharpPlayground.Fundamentals.Delegates;

class MulticastImpl
{
    delegate void ButtonClick(Button button);

    class Button
    {
        public event ButtonClick? Click;

        public void SimulateClick()
        {
            Click?.Invoke(this);
        }
    }

    static void ButtonClickBehaviour1(Button button)
    {
        Console.WriteLine("Behaviour1 button clicked!");
    }

    static void ButtonClickBehaviour2(Button button)
    {
        Console.WriteLine("Behaviour2 button clicked!");
    }

    public static void Driver()
    {
        var button = new Button();

        button.Click += ButtonClickBehaviour1;
        button.Click += ButtonClickBehaviour2;

        button.SimulateClick();
    }
}

class Multicast
{
    public static void Driver()
    {
        MulticastImpl.Driver();
    }
}
