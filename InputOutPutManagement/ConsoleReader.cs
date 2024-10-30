namespace Solid_Урок_7_ООП.InputOutPutManagement;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}