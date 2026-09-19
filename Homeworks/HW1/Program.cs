using System.Net;
using System.Security;

internal class Program
{
    public static void Pokaz(int bal, string sign="₽") {
        Console.WriteLine($"Текущий баланс: {bal}{sign}");
    }
    public static int Popol(int popsum, int bal) {
        if (popsum > 0) {return bal+popsum;}
        else { Console.WriteLine("Невозможная сумма пополнения!");
        return bal;}
    }
    public static int Snyatie(int snsum, int bal) {
        if (0 < snsum && snsum < bal) {
            return bal-snsum;
        }
        else {Console.WriteLine("Невозможная сумма снятия!");
        return bal;}
    }
    public static void Istoria(List<string> isto) {
        foreach (string i in isto) {
            string[] s = i.Split(":");
            if (s[0] == "p") { Console.WriteLine($"Пополнение на {s[1]}"); }
            else { Console.WriteLine($"снятие на {s[1]}"); }
        }
    
    
    }
    private static void Main()
    {
        int flag = 0;
        Console.Write("Здравствуйте! Какой начальный капитал? ");
        int bal = Convert.ToInt32(Console.ReadLine());
        int balc;
        List<string> ist = new List<string>();
        while (true) {
            Console.WriteLine("1. Показать баланс");
            Console.WriteLine("2. Пополнить счет");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать историю операций");
            Console.WriteLine("5. Выйти");
            int otv = Convert.ToInt32(Console.ReadLine());
            switch(otv) {
                case 1: Pokaz(bal);
                    break;
                case 2: 
                Console.Write("На сколько пополнить?: ");
                int pop = Convert.ToInt32(Console.ReadLine());
                balc = Popol(pop, bal);
                if (balc == bal) {ist.Add($"p:{0}");}
                else {ist.Add($"p:{pop}"); bal = balc;}
                break;
                case 3: Console.Write("сколько хотите снять?: ");
                    int sn = Convert.ToInt32(Console.ReadLine());
                    balc = Snyatie(sn, bal);
                    if (balc == bal) {ist.Add($"s:{0}");}
                    else {ist.Add($"s:{sn}"); bal = balc;}
                    break;
                case 4: Console.WriteLine("История действий: ");
                Istoria(ist);
                break;
                case 5: flag = 1;
                break;
                }
            if (flag == 1) {break; }

            }
    }
}