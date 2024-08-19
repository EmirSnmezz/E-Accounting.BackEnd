using System.Reflection;

namespace E_Accounted_BackEnd.Presentation
{
    public static class AssemblyReferance
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;  // Program.cs de COntroller'ı başka bir katmana taşımak istiyorsak taşımak istedğimiz katmanın assembly'sini elde etmeli
    }
}
