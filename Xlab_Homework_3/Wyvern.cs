namespace Xlab_Homework_3;

public class Wyvern :  Monster
{
    public Wyvern(string name = "Безымянный") : base("Виверна", 300, name) {}
    public override string Move() => "Грациозно летит";
}