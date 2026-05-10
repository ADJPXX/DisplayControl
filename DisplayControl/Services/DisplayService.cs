using DisplayControl.Models;
using DisplayControl.Native;
using System.Runtime.InteropServices;

namespace DisplayControl.Services;

public class DisplayService
{
    public bool SetResolution(int width, int height)
    {
        var mode = new DevMode();

        mode.dmSize = (short)Marshal.SizeOf(typeof(DevMode));

        NativeMethods.EnumDisplaySettings(null, DisplayConstants.ENUM_CURRENT_SETTINGS, ref mode);

        mode.dmPelsWidth = width;
        mode.dmPelsHeight = height;
        mode.dmFields = 0x80000 | 0x100000;

        var result = NativeMethods.ChangeDisplaySettings(ref mode, DisplayConstants.CDS_UPDATEREGISTRY);

        return result == DisplayConstants.DISP_CHANGE_SUCCESSFUL;
    }

    public (int width, int height) GetResolution()
    {
        var mode = new DevMode();
        mode.dmSize = (short)System.Runtime.InteropServices.Marshal.SizeOf(typeof(DevMode));

        NativeMethods.EnumDisplaySettings(null, DisplayConstants.ENUM_CURRENT_SETTINGS, ref mode);

        return (mode.dmPelsWidth, mode.dmPelsHeight);
    }

    public bool SetRefreshRate(int refreshRate)
    {
        var mode = new DevMode();

        mode.dmSize = (short)Marshal.SizeOf(typeof(DevMode));

        NativeMethods.EnumDisplaySettings(null, DisplayConstants.ENUM_CURRENT_SETTINGS, ref mode);

        mode.dmDisplayFrequency = refreshRate;

        mode.dmFields = DisplayConstants.DM_DISPLAYFREQUENCY;

        var result = NativeMethods.ChangeDisplaySettings(ref mode, DisplayConstants.CDS_UPDATEREGISTRY);
        
        return result == DisplayConstants.DISP_CHANGE_SUCCESSFUL;
    }
}