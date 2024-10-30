namespace Solid_Урок_7_ООП.Contracts;

public interface IFile
{
    public string Path { get; }

    public long Size { get; }

    public string Write(ILayout layout, IError error);
}