using Solid_Урок_7_ООП.Appenders;
using Solid_Урок_7_ООП.Common;
using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Enumerations;

namespace Solid_Урок_7_ООП.Factories;

public class AppenderFactory
{
    public AppenderFactory()
    {
        
    }

    public IApender CreateAppender(string appenderType, ILayout layout, Level level, IFile file = null)
    {
        IApender appender;
        
        if (appenderType == "ConsoleAppender")
        {
            appender = new ConsoleAppender(layout, level);
        }
        else if (appenderType == "FileAppender" && file != null)
        {
            appender = new FileAppender(layout, level, file);
        }
        else
        {
            throw new InvalidOperationException(GlobalConstants.InvalidAppenderType);
        }

        return appender;
    }
}