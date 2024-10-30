namespace Solid_Урок_7_ООП.Contracts;

public interface IPathManager
{
    //bin/debug
    public string CurrentDirectoryPath { get; }

    //bin/debug/logfile.txt
    public string CurrentFilePath { get; }

    
    //It tells me where my app is running now on user pc
    public string GetCurrentPath();

    //It will ensure that selected directory and file will exist
    public void EnsureDirectoryAndFileExists();
}