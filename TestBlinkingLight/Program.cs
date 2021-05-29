using System;
using System.Device.Gpio;
using System.Threading;

namespace TestBlinkingLight
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            int ledPin = 18;
            int buttonPin = 17;
            using GpioController controller = new GpioController();
            controller.OpenPin(ledPin, PinMode.Output);
            Console.WriteLine("led open");
            controller.OpenPin(buttonPin, PinMode.Output);
            Console.WriteLine("button open");
            while (true)
            {
                Console.WriteLine(controller.Read(buttonPin));
                if (controller.Read(buttonPin) == PinValue.Low)
                {
                    controller.Write(ledPin, PinValue.High);
                }
                else
                {
                    controller.Write(ledPin, PinValue.Low);
                }
                Console.WriteLine("Press Enter to cycle");
                Console.ReadLine();
            }
            
        }

        public static void  LightConsoleOnOff()
        {
            int pin = 18;
            bool lightOn = false;
            using GpioController controller = new();
            controller.OpenPin(pin, PinMode.Output);
            Console.WriteLine($"GPIO pin enabled: {pin}");

            while (true)
            {
                lightOn = !lightOn;
                string nextLightCondition = lightOn ? "On":  "Off";
                Console.WriteLine($"Turn light {nextLightCondition} Press Enter");
                Console.ReadLine();
                Console.Clear();
                if (lightOn)
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