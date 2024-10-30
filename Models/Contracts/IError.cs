using Solid_Урок_7_ООП.Enumerations;

namespace Solid_Урок_7_ООП.Contracts;

public interface IError
{
    public DateTime DateTime { get; }

    public string Message { get; }
    
    Level Level { get; }
}