namespace Solid_Урок_7_ООП.InputOutPutManagement;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.Write(text);
    }

    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}