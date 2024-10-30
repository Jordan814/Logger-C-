using Solid_Урок_7_ООП.Enumerations;

namespace Solid_Урок_7_ООП.Contracts;

public interface IApender
{
    ILayout Layout { get; }

    Level Level { get; }
    
    void Append(IError error);
}