using System;

[Flags]
enum Lampstate
{
    lamp1 = 1 << 0,
    lamp2 = 1 << 1,
    lamp3 = 1 << 2,
};