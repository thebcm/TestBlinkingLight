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
            controller.OpenPin(buttonPin, PinMode.InputPullUp);
            Console.WriteLine("button open");
            bool isOn = false;
            while (true)
            {
                
                if (controller.Read(buttonPin) == PinValue.Low)
                {
                    isOn = !isOn;
                }

                if (isOn)
                {
                    controller.Write(ledPin, PinValue.High);
                }
                else
                {
                    controller.Write(ledPin, PinValue.Low);
                }
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