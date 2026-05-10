using System.Runtime.InteropServices;
using DisplayControl.Models;

namespace DisplayControl.Native;

internal static class NativeMethods
{
    [DllImport("user32.dll")]
    internal static extern bool EnumDisplaySettings(string? deviceName, int modeNum, ref DevMode devMode);

    [DllImport("user32.dll")]
    internal static extern int ChangeDisplaySettings(ref DevMode devMode, int flags);
}