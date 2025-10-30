using System;
using System.Runtime.CompilerServices;

namespace Xlab_Homework_3;

public class Ogr : Monster
{
    public Ogr(string name = "Безымянный") : base("Огр", 200, name) {}
    public override string Move() => "Идёт, громко волочя дубовую дубину";
}