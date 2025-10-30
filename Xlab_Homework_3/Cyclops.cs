namespace Xlab_Homework_3;

public class Cyclops : Monster
{
    public Cyclops(string name = "Безымянный") : base("Циклоп", 150, name) {}
    public override string Move() => "Медленно бредёт";
}