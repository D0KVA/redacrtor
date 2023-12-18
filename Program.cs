class Program
{
    static void Main(string[] args)
    {
        bool fl = true;
        do
        {
            Console.WriteLine("***********       Меню       ***********");
            Console.WriteLine("1. Создать файл для записи текста\n2. Открыть созданнный файл для чтения\n3. Выход");
            Console.WriteLine("****************************************");

            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1: CreateFile(); break;
                case 2: OpenFile(); break;
                case 3: fl = false; break;
                default: Console.WriteLine("Неверно введен пункт!"); break;
            }
        } while (fl);
    }
    public static void CreateFile()
    {
        try
        {
            Console.Write("Введите имя создаваемого файла: ");
            FileStream fs = new FileStream(Console.ReadLine() + ".txt", FileMode.Create);
            Console.WriteLine("ТЕКСТ СООБЩЕНИЯ: ");
            string text = Console.ReadLine();
            StreamWriter s = new StreamWriter(fs);
            s.WriteLine(text);
            s.Close();
        }
        catch (Exception ex)
        { Console.WriteLine("Ошибка создания файла: {0}", ex.Message); }
    }
    public static void OpenFile()
    {
        try
        {
            Console.WriteLine("Введите имя открываемого файла: ");
            using (StreamReader sr = new StreamReader(Console.ReadLine() + ".txt"))
            {
                string line;
                Console.WriteLine("ТЕКСТ ИЗ ФАЙЛА: \n");
                while ((line = sr.ReadLine()) != null)
                { Console.WriteLine(line); }
            }
        }
        catch (Exception ex)
        { Console.WriteLine("Ошибка октрытия файла: {0}", ex.Message); }
    }
}
