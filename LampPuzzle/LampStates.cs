using System;
/// <summary>
/// Contains all lamps and their respective binary values. 
/// 0 means all lamps are off.
/// </summary>
[Flags]
enum LampStates
{
    lamp1 = 1 << 0,
    lamp2 = 1 << 1,
    lamp3 = 1 << 2,
};