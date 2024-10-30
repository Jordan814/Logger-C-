using System.Text;
using Solid_Урок_7_ООП.Contracts;

namespace Solid_Урок_7_ООП.Layouts;

public class XmlLayout : ILayout
{
    public string Format => this.GetFormat();

    private string GetFormat()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("<log>")
            .AppendLine("<\t<date>{0}</date>")
            .AppendLine("\t<level>{1}</level>")
            .AppendLine("\t<message>{2}</message>")
            .AppendLine("<log>");

        return stringBuilder.ToString();
    }
}