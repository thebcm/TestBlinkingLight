using System;
using System.Device.Gpio;
using System.Threading;

namespace TestBlinkingLight
{
    
    class Program
    {
        static int pin = 18;
        private static bool _lightOn = false;
        static void Main(string[] args)
        {
            using GpioController controller = new();
            controller.OpenPin(pin, PinMode.Output);
            Console.WriteLine($"GPIO pin enabled: {pin}");

            while (true)
            {
                _lightOn = !_lightOn;
                string nextLightCondition = _lightOn ? "On":  "Off";
                Console.WriteLine($"Turn light {nextLightCondition} Press Enter");
                Console.ReadLine();
                if (_lightOn)
                {
                    controller.Write(pin, PinValue.High);
                }
                else
                {
                    controller.Write(pin, PinValue.Low);
                }
                
            }
        }
    }
}