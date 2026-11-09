using System;
using System.Text;

namespace FacadeAndAdapter
{

    public class PowerSupply
    {
        public void TurnOn() => Console.WriteLine("Блок живлення: подано напругу.");
    }

    public class VideoCard
    {
        public void Initialize() => Console.WriteLine("Відеокарта: виведено зображення на екран.");
    }

    public class HardDrive
    {
        public void BootOS() => Console.WriteLine("Диск: завантажено операційну систему.");
    }

    public class ComputerFacade
    {
        private readonly PowerSupply power = new PowerSupply();
        private readonly VideoCard gpu = new VideoCard();
        private readonly HardDrive ssd = new HardDrive();

        public void StartComputer()
        {
            Console.WriteLine("--- Запуск комп'ютера через Фасад ---");
            power.TurnOn();
            gpu.Initialize();
            ssd.BootOS();
            Console.WriteLine("Комп'ютер готовий до роботи!\n");
        }
    }


    public interface IEuropeanSocket
    {
        void PlugIn220V();
    }

    public class AmericanPlug
    {
        public void Connect110V()
        {
            Console.WriteLine("Прилад із американською вилкою (110V) успішно працює через перехідник!");
        }
    }

    public class SocketAdapter : IEuropeanSocket
    {
        private readonly AmericanPlug americanPlug;

        public SocketAdapter(AmericanPlug plug)
        {
            americanPlug = plug;
        }

        public void PlugIn220V()
        {
            Console.WriteLine("--- Робота через Адаптер ---");
            americanPlug.Connect110V();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ComputerFacade computer = new ComputerFacade();
            computer.StartComputer();

            AmericanPlug oldLaptopPlug = new AmericanPlug();
            IEuropeanSocket adapter = new SocketAdapter(oldLaptopPlug);
            adapter.PlugIn220V();
        }
    }
}
