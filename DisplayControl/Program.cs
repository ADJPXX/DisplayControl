using System.Diagnostics;
using DisplayControl.Services;

namespace DisplayControl;

public static class Program
{
    public static void Main(string[] args)
    {
        var displayService = new DisplayService();

        const int csWidth = 3840;
        const int csHeight = 2160;

        const int defaultWidth = 2560;
        const int defaultHeight = 1440;

        const int deafultRefreshRate = 180;

        try
        {
            var (width, height) = displayService.GetResolution();
            if (width == defaultWidth && height == defaultHeight)
            {
                displayService.SetResolution(csWidth, csHeight);
                displayService.SetRefreshRate(deafultRefreshRate);
            }

            if (width == csWidth && height == csHeight)
            {
                displayService.SetResolution(defaultWidth, defaultHeight);
                displayService.SetRefreshRate(deafultRefreshRate);
            }

            var abrirSom = Process.Start(new ProcessStartInfo
            {
                FileName = "ms-settings:display",
                UseShellExecute = true
            });

            abrirSom?.WaitForExit();
        }

        catch (Exception ex)
        {
            Console.WriteLine($"ERRO AO MUDAR A RESOLUCAO: {ex.Message}");
        }

    }
}