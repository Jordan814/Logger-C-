using System.Reflection;
using Solid_Урок_7_ООП.Common;
using Solid_Урок_7_ООП.Contracts;

namespace Solid_Урок_7_ООП.Factories;

public class LayoutFactory
{
    public LayoutFactory()
    {
        
    }

    public ILayout CreateLayout(string layoutTypeStr)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type layoutType = assembly.GetTypes()
            .FirstOrDefault(t => t.Name.Equals(layoutTypeStr, StringComparison.InvariantCultureIgnoreCase));

        if (layoutType == null)
        {
            throw new InvalidOperationException(GlobalConstants.InvalidLayoutType);
        }

        object[] ctorArgs = new object[] { };

        ILayout layout =
            (ILayout)Activator.CreateInstance(layoutType, ctorArgs);

        return layout;
    }
}