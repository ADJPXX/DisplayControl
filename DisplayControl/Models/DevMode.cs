using System.Runtime.InteropServices;

namespace DisplayControl.Models;

public struct DevMode
{
    private const int CCHDEVICENAME = 32;
    private const int CCHFORMNAME = 32;
    
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
    public string dmDeviceName;

    public short dmSpecVersion;
    public short dmDriverVersion;
    public short dmSize;
    public short dmDriverExtra;
    public int dmFields;

    public int dmPositionX;
    public int dmPositionY;
    public int dmDisplayOrientation;
    public int dmDisplayFixedOutput;

    public short dmColor;
    public short dmDuplex;
    public short dmYResolution;
    public short dmTTOption;
    public short dmCollate;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
    public string dmFormName;

    public short dmLogPixels;
    public int dmBitsPerPel;

    public int dmPelsWidth;
    public int dmPelsHeight;

    public int dmDisplayFlags;
    public int dmDisplayFrequency;
}