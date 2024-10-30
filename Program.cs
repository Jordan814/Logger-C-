using Solid_Урок_7_ООП.Appenders;
using Solid_Урок_7_ООП.Common;
using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Core;
using Solid_Урок_7_ООП.Core.Contracts;
using Solid_Урок_7_ООП.Enumerations;
using Solid_Урок_7_ООП.Factories;
using Solid_Урок_7_ООП.Files;
using Solid_Урок_7_ООП.InputOutPutManagement;
using Solid_Урок_7_ООП.Loggers;
using Solid_Урок_7_ООП.Loggers.Contracts;
using Solid_Урок_7_ООП.PathManagement;


internal class Program
{

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        LayoutFactory layoutFactory = new LayoutFactory();

        AppenderFactory appenderFactory = new AppenderFactory();

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IPathManager pathManager = new PathManager("logs", "logs.txt");

        IFile file = new LogFile(pathManager);

        ILogger logger = SetUpLogger(n, reader, writer, file, layoutFactory, appenderFactory);

        IEngine engine = new Engine(logger, reader, writer);
        
        engine.Run();


    }

    private static ILogger SetUpLogger(int appendersCount, IReader reader, IWriter writer, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
    {
        ICollection<IApender> appenders = new HashSet<IApender>();

            for (int i = 0; i < appendersCount; i++)
            {
                var appendersArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];

                bool hasError = false;

                Level level = ParseLevel(appendersArgs, writer, ref hasError);

                if (hasError)
                {
                    continue; 
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);

                    IApender appender = appenderFactory.CreateAppender(appenderType, layout, level, file);
                    
                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }


    private static Level ParseLevel(string[] levelString, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;
    
            if (levelString.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelString[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidLevelType);
                    hasError = true;
                }

                appenderLevel = (Level)enumParsed;
            }

            return appenderLevel;
        }
}


