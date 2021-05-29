using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading;

namespace TestBlinkingLight
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            
            using GpioController controller = new GpioController();
            Dictionary<int, bool> pinsOnOff = new Dictionary<int, bool>();
            Dictionary<int, int> inlineToGpioMap = new Dictionary<int, int>();
            inlineToGpioMap.Add(1,21);
            inlineToGpioMap.Add(2,20);
            inlineToGpioMap.Add(3,16);
            inlineToGpioMap.Add(4,12);
            inlineToGpioMap.Add(5,25);
            inlineToGpioMap.Add(6,24);
            inlineToGpioMap.Add(7,18);
            inlineToGpioMap.Add(8,26);
            inlineToGpioMap.Add(9,19);
            inlineToGpioMap.Add(10,13);
            while (true)
            {
                Console.WriteLine("What pin to turn on/off");
                int mappedPin = Convert.ToInt32(Console.ReadLine());
                int pin = inlineToGpioMap[mappedPin];
                if (pinsOnOff.ContainsKey(pin))
                {
                    bool isOn = pinsOnOff[pin];
                    controller.Write(pin, !isOn == true ? PinValue.High : PinValue.Low);
                    pinsOnOff[pin] = !isOn;
                }
                else
                {
                    pinsOnOff.Add(pin, true);
                    controller.OpenPin(pin, PinMode.Output);
                    controller.Write(pin, PinValue.High);
                }
            }
        }

        public static void buttonPress()
        {
            int ledPin = 18;
            int buttonPin = 17;
            using GpioController controller = new GpioController();
            controller.OpenPin(ledPin, PinMode.Output);
            Console.WriteLine("led open");
            controller.OpenPin(buttonPin, PinMode.Input);
            Console.WriteLine("button open");

            controller.Write(ledPin, PinValue.Low);
            while (true)
            {
                
                if (controller.Read(buttonPin) == PinValue.Low)
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