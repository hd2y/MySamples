using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

bool disableConsoleQuickEditResult = DisableConsoleQuickEdit.Go();
Console.WriteLine($"Disable console quick edit result: {disableConsoleQuickEditResult}");
Task.Run(async () =>
{
    while (true)
    {
        Console.WriteLine(DateTime.Now.ToString("hh:mm:ss t z"));
        await Task.Delay(1000);
    }
});
Console.ReadLine();

public static class DisableConsoleQuickEdit
{
    private const int StdInputHandle = -10;
    private const uint EnableQuickEditMode = 0x0040;
    private const uint EnableInsertMode = 0x0020;
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int hConsoleHandle);
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint mode);
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint mode);

    public static bool Go()
    {
        var hStdin = GetStdHandle(StdInputHandle);
        if (!GetConsoleMode(hStdin, out var mode)) return false;
        mode &= ~EnableQuickEditMode;//移除快速编辑模式
        mode &= ~EnableInsertMode;      //移除插入模式
        return SetConsoleMode(hStdin, mode);
    }
}