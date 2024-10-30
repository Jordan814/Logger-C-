using System.Text;
using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Loggers.Contracts;

namespace Solid_Урок_7_ООП.Loggers;

public class Logger : ILogger
{
    private readonly ICollection<IApender> appenders;

    public Logger(ICollection<IApender> appenders)
    {
        this.appenders = appenders;
    }

    public Logger(params IApender[] appenders)
    {
        this.appenders = appenders;
    }

    public IReadOnlyCollection<IApender> Appenders => (IReadOnlyCollection<IApender>)this.appenders;
    
    public void Log(IError error)
    {
        foreach (IApender appender in this.Appenders)
        {
            if (error.Level >= appender.Level)
            {
                appender.Append(error);
            }    
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Logger info");
        foreach (IApender appender in this.Appenders)
        {
            stringBuilder.AppendLine(appender.ToString());
            
        }

        return stringBuilder.ToString().TrimEnd();
    }
}