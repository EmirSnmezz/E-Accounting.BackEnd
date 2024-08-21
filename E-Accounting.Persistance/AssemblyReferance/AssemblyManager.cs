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
        public static readonly Assembly assembly = typeof(Assembly).Assembly;
        
    }
}
