using Solid_Урок_7_ООП.Common;
using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Enumerations;
using Solid_Урок_7_ООП.InputOutPutManagement;

namespace Solid_Урок_7_ООП.Appenders;

public class ConsoleAppender : Appender
{

    private readonly IWriter writer;
    
    public ConsoleAppender(ILayout layout, Level level) : base(layout, level)
    {
        this.writer = new ConsoleWriter();
    }
    
    
    public override void Append(IError error)
    {
        string format = this.Layout.Format;

        DateTime dateTime = error.DateTime;

        string message = error.Message;

        Level level = error.Level;

        string formattedString = string.Format(format,dateTime.ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);
        
        this.writer.WriteLine(formattedString);

        this.messagesAppended++;
    }

    
}