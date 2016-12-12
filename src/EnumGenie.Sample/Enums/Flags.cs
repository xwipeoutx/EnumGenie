using System;

namespace EnumGenie.Sample.Enums
{
    [Flags]
    public enum Flags
    {
        None = 0,
        First = 1,
        Second = 2,
        Third = 4
    }
}