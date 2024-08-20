using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.AssemblyReferance
{
    public static class AssemblyManager
    {
        public static readonly Assembly myAssembly = typeof(Assembly).Assembly;
    }
}
