namespace Solid_Урок_7_ООП.InputOutPutManagement;

public class FileWriter : IWriter
{

    public FileWriter(string filePath)
    {
        this.FilePath = filePath;
    }

    public string FilePath { get; }
    
    public void Write(string text)
    {
        File.WriteAllText(this.FilePath,text);
    }

    public void WriteLine(string text)
    {
        File.AppendAllText(this.FilePath, text + Environment.NewLine);
    }
}