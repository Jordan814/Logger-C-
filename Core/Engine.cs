using System.Globalization;
using Solid_Урок_7_ООП.Common;
using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Core.Contracts;
using Solid_Урок_7_ООП.Enumerations;
using Solid_Урок_7_ООП.Errors;
using Solid_Урок_7_ООП.Factories;
using Solid_Урок_7_ООП.InputOutPutManagement;
using Solid_Урок_7_ООП.Loggers.Contracts;

namespace Solid_Урок_7_ООП.Core;

public class Engine : IEngine
{
    private readonly ILogger logger;

    private readonly IReader reader;

    private readonly IWriter writer;

    public Engine(ILogger logger, IReader reader, IWriter writer) 
    {
        this.logger = logger;
        this.reader = reader;
        this.writer = writer;
    }
    public void Run()
    {
        string command;

        while ((command = this.reader.ReadLine()) != "End")
        {
            var errorArgs = command.Split("|").ToArray();
            
            string levelStr = errorArgs[0];
            
            string dateTimeStr = errorArgs[1];

            string message = errorArgs[2];
            
            bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);
            
            if (!isLevelValid)
            {
                this.writer.WriteLine(GlobalConstants.InvalidLevelType);
                continue;
            }

            Level level = (Level)levelObj;

            bool isDateTimeValid = DateTime.TryParseExact(dateTimeStr, GlobalConstants.DateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

            if (!isDateTimeValid)
            {
                this.writer.WriteLine(GlobalConstants.InvalidDateTimeFormat);
                continue;
            }

            IError error = new Error(dateTime, message, level);
            
            this.logger.Log(error);
        }

        this.writer.WriteLine(this.logger.ToString());
        
    }
}