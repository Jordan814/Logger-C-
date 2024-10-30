using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Enumerations;
using Solid_Урок_7_ООП.InputOutPutManagement;

namespace Solid_Урок_7_ООП.Appenders;

public class FileAppender : Appender
{

    private readonly IWriter writer;
    
    public FileAppender(ILayout layout, Level level, IFile file) : base(layout,level)
    {
       
        this.File = file;

        this.writer = new FileWriter(this.File.Path);
    }

    public IFile File { get;  }
    
    public override void Append(IError error)
    {
        string formattedMessage = this.File.Write(this.Layout, error);
        
        this.writer.WriteLine(formattedMessage);
        this.messagesAppended++;
    }

    public override string ToString()
    {
        return base.ToString() + $", File size {this.File.Size}";
    }
}