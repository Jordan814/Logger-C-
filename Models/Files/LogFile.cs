using Solid_Урок_7_ООП.Common;
using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Enumerations;
using Solid_Урок_7_ООП.Errors;
using Solid_Урок_7_ООП.PathManagement;

namespace Solid_Урок_7_ООП.Files;

public class LogFile : IFile
{
    private readonly IPathManager pathManager;
    

    public LogFile(IPathManager pathManager)
    {
        this.pathManager = pathManager;
        this.pathManager.EnsureDirectoryAndFileExists();
        
    }

    public string Path => this.pathManager.CurrentFilePath;

    public long Size => this.CalculateFileSize();
    
    public string Write(ILayout layout, IError error)
    {
        string format = layout.Format;

        DateTime dateTime = error.DateTime;

        string message = error.Message;

        Level level = error.Level;

        string formattedMessage = string.Format(format, dateTime
            .ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);

        return formattedMessage;
    }

    private long CalculateFileSize()
    {
        string fileText = File.ReadAllText(this.Path);

        return fileText.ToCharArray().Where(c => char.IsLetter(c)).Sum(c => c);
    }
}