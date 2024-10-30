using Solid_Урок_7_ООП.Contracts;
using Solid_Урок_7_ООП.Enumerations;

namespace Solid_Урок_7_ООП.Errors;

public class Error : IError
{

    public Error(DateTime dateTime, string message, Level level)
    {
        this.DateTime = dateTime;
        this.Message = message;
        this.Level = level;
    }
    
    public DateTime DateTime { get; }
    public string Message { get; }
    public Level Level { get; }
}