
using System;

[Flags] public enum MinionType
{
    Default = 0,
    Worker = 1,
    Warrior = 2,
    Scientist = 4
}

public interface IMinion : IStateRunner
{
    int Hp { get; set; }
    int Strength { get; set; }
    MinionType Miniontypes { get; set; }
    void Mine();
    void Fight();
    void Research();
}

