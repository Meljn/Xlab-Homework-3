using System;

namespace Xlab_Homework_3;

class Program
{
    static List<Monster> monsters = new List<Monster>();
    static Random random = new Random();
    
    static void Main(string[] args)
    {
        string input;
        do
        {
            ShowMenu();
            input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    AddMonster<Ogr>("Огр");
                    break;
                
                case "2":
                    AddMonster<Cyclops>("Циклоп");
                    break;
                
                case "3":
                    AddMonster<Wyvern>("Виверна");
                    break;
                
                case "4":
                    DamageMonsterById();
                    break;
                
                case "5":
                    DamageRandomMonster();
                    break;
                
                case "6":
                    UpgradeMonster();
                    break;
                
                case "7":
                    RemoveMonsterById();
                    break;
                
                case "8":
                    ShowAllMonsters();
                    break;
            }
        } while (input != "Этилендиаминтетрауксусная кислота");
    }

    static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=========================================================================");
        Console.ResetColor();
        
        Console.WriteLine("1) Добавить монстра 'Огр'");
        Console.WriteLine("2) Добавить монстра 'Циклоп'");
        Console.WriteLine("3) Добавить летающего монстра 'Виверна'");
        Console.WriteLine("4) Нанести урон монстру по id");
        Console.WriteLine("5) Нанести урон случайному монстру");
        Console.WriteLine("6) Апгрейднуть монстра по id");
        Console.WriteLine("7) Удалить монстра по id");
        Console.WriteLine("8) Вывести данные о всех текущих монстрах");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Чтобы выйти, введите 'Этилендиаминтетрауксусная кислота'");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=========================================================================");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Ваш выбор: ");
        Console.ResetColor();
    }

    static void ShowAllMonsters()
    {
        if (monsters.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Монстров нет!");
            Console.ResetColor();
            return;
        }
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nСписок монстров: ");
        Console.WriteLine("=========================================================================");
        for (int i = 0; i < monsters.Count; i++)
        {
            Console.WriteLine($"{i}: {monsters[i]}");
        }
        Console.WriteLine("=========================================================================");
        Console.ResetColor();
    }

    static void AddMonster<T>(string type) where T: Monster
    {
        Console.Write($"Введите имя для {type} (или нажмите на Enter, если он Безымянный): ");
        
        string name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            name = "Безымянный";
        }

        Monster monster;
        switch (type)
        {
            case "Огр":
                monster = new Ogr(name);
                break;
            
            case "Циклоп":
                monster = new Cyclops(name);
                break;
            
            case "Виверна":
                monster = new Wyvern(name);
                break;
            
            default:
                return;
        }
        
        monsters.Add(monster);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=========================================================================");
        Console.WriteLine($"{type} '{name}' добавлен!");
        Console.WriteLine("=========================================================================");
        Console.ResetColor();
        
    }

    static void DamageMonsterById()
    {
        if (monsters.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Монстров нет!");
            Console.ResetColor();
            return;
        }
        
        ShowAllMonsters();
        Console.Write("Введите Id монстра для атаки: ");
        
        if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 &&  id <= monsters.Count)
        {
            Console.Write("Введите кол-во наносимого урона: ");
            
            if (int.TryParse(Console.ReadLine(), out int damage) && damage > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Атакуем {monsters[id].Type} {monsters[id].Name}!");
                Console.ResetColor();
                
                monsters[id].TakeDamage(damage);
                
                if (monsters[id].Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} погиб!");
                    Console.ResetColor();
                    
                    monsters.RemoveAt(id);
                }
            }
            
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный урон!");
                Console.ResetColor();
            }
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Неверный Id!");
            Console.ResetColor();
        }
    }

    static void DamageRandomMonster()
    {
        if (monsters.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Монстров нет!");
            Console.ResetColor();
            return;
        }
        
        int id =  random.Next(0, monsters.Count);
        Console.Write("Введите кол-во наносимого урона: ");
        
        if (int.TryParse(Console.ReadLine(), out int damage) && damage > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Атакуем {monsters[id].Type} {monsters[id].Name}!");
            Console.ResetColor();
            
            monsters[id].TakeDamage(damage);
                
            if (monsters[id].Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} погиб!");
                Console.ResetColor();
                
                monsters.RemoveAt(id);
            }
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некорректный урон!");
            Console.ResetColor();
        }
    }

    static void UpgradeMonster()
    {
        if (monsters.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Монстров нет!");
            Console.ResetColor();
            return;
        }
        
        ShowAllMonsters();
        Console.Write("Введите Id монстра для улучшения: ");

        if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id <= monsters.Count)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Список доступных улучшений:");
            Console.WriteLine("1) Добавить броню");
            Console.WriteLine("2) Сделать невидимым");
            Console.WriteLine("3) Добавить броню и сделать невидимым");
            Console.ResetColor();
            
            Console.Write("Ваш выбор: ");
            
            string upgrade =  Console.ReadLine();

            switch (upgrade)
            {
                case "1":
                    if (monsters[id].HasArmor)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"У {monsters[id].Type} {monsters[id].Name} уже есть броня!");
                        Console.ResetColor();
                        return;
                    }
                    monsters[id].HasArmor = true;
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} получил броню!");
                    Console.ResetColor();
                    break;
                
                case "2":
                    if (monsters[id].HasInvisible)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"У {monsters[id].Type} {monsters[id].Name} уже есть невидимость!");
                        Console.ResetColor();
                        return;
                    }
                    monsters[id].HasInvisible = true;
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} стал невидимым!");
                    Console.ResetColor();
                    break;
                
                case "3":
                    if (monsters[id].HasArmor || monsters[id].HasInvisible)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"У {monsters[id].Type} {monsters[id].Name} уже есть броня/невидимость!");
                        Console.ResetColor();
                        return;
                    }
                    monsters[id].HasArmor = true;
                    monsters[id].HasInvisible = true;
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} получил броню!");
                    Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} получил стал невидимым!");
                    Console.ResetColor();
                    break;
                
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный вод!");
                    Console.ResetColor();
                    break;
            }
            
        }
    }
    
    static void RemoveMonsterById()
    {
        if (monsters.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Монстров нет!");
            Console.ResetColor();
            return;
        }
        
        ShowAllMonsters();
        Console.Write("Введите Id монстра: ");

        if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id < monsters.Count)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{monsters[id].Type} {monsters[id].Name} удалён из списка!");
            Console.ResetColor();
            
            monsters.RemoveAt(id);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Неверный Id!");
            Console.ResetColor();
        }
    }
    
}