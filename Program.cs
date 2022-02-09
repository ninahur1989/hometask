
using System;
using System.Threading;

namespace Boss
{
    class Program
    {
        static void Main(string[] args)
        {
            //fdf
            //fdf
            ConsoleColor oldColor = Console.ForegroundColor;
            WriteColoredLine("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);
            int Health = 1000;
            int Armor = 20;
            bool isRandomAttack = GetRandomFromZeroTo(2) == 0;
            WriteColoredLine("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);
            WriteColoredLine("Нажмите enter для начала боя", ConsoleColor.Green);
            Console.ReadLine();
            int attackNumber = 0;
            void WriteColoredLine(string massage , ConsoleColor color)
            {
                oldColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(massage);
                Console.ForegroundColor = oldColor;
            }
            int GetRandomFromZeroTo(int num) => DateTime.Now.Millisecond % num;
            void Attack(int num)
            {
                if (num == 0)
                {
                    WriteColoredLine("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed);
                    Health = Health - (100 - Armor);
                }
                else if (num == 1)
                {
                    WriteColoredLine("Босс исполнил новый альбом Ольги бузовой", ConsoleColor.DarkMagenta);
                    Health = Health - (140 - Armor);
                }
                else if (num == 2)
                {
                    WriteColoredLine("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки", ConsoleColor.DarkGray);
                    Health = Health - (80 - Armor);
                }
            }
            while (Health > 0)
            {
                Console.Clear();
                WriteColoredLine("У вас здоровья: " + Health, ConsoleColor.Red);

                if (isRandomAttack)
                {
                    Attack(GetRandomFromZeroTo(3));
                }
                else
                {
                    Attack(attackNumber);

                    attackNumber += 1;
                    if (attackNumber > 2)
                    {
                        attackNumber = 0;
                    }
                }

                Thread.Sleep(3000);
            }
            WriteColoredLine("Бой закончен, вы погибли", ConsoleColor.DarkGray);
        }
    }
}