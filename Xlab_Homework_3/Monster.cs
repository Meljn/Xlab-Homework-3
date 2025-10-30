using System;

namespace Xlab_Homework_3;

public abstract class Monster
{
    public int Health { get; set; }
    public string Name {get; set;}
    public string Type {get; set;}
    public bool HasArmor { get; set; } = false;
    public bool HasInvisible { get; set; } = false;
    
    protected Monster(string type, int health, string name = "Безымянный")
    {
        Type = type;
        Health = health;
        Name = name;
    }

    public void TakeDamage(int damage)
    {
        if (HasInvisible && new Random().Next(0, 100) < 40)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} уклонился от удара!");
            Console.ResetColor();
            
            return;
        }
        
        if (HasArmor)
        {
            damage = (int)(damage * 0.5);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Броня поглотила часть урона! Урон снижен до {damage}!");
            Console.ResetColor();
        }
        
        Health -= damage;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Type} {Name} получил {damage} ед. урона! Осталось {Health} жизней!");
        Console.ResetColor();
    }

    public override string ToString()
    {
        return ($"Тип: {Type}, Имя: {Name}, Здоровье: {Health}, Броня: {(HasArmor? "Да":"Нет")}, Невидимость: {(HasInvisible? "Да":"Нет")}");
    }

    public abstract string Move();
}