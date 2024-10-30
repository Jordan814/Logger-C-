using Solid_Урок_7_ООП.Contracts;

namespace Solid_Урок_7_ООП.Loggers.Contracts;

public interface ILogger
{
    IReadOnlyCollection<IApender> Appenders { get; }

    void Log(IError error);
}