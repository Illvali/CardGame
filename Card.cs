using System;


namespace Cardgame
{
    partial class Program
    {
        class Card
        {
            public string Color { get; private set; }
            public int Value { get; private set; }
            public string ShowValue { get; private set; }
            public bool Royal { get; private set; }
            public Card(string color, int value, string showValue)
            {
                Color = color;
                Value = value;
                ShowValue = showValue;
                if(Value > 8)
                {
                    Royal = true;
                }
                else
                {
                    Royal = false;
                }
            }
            public void PresentCard()
            {
                Console.WriteLine($"Card: {ShowValue} of {Color}s");
            }
        }
    }
}
