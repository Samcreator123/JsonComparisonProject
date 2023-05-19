using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare.JsonCompareCore.ExtensionApi
{
    public interface ColorChanger
    {
        (string source, string target) ChangeSourceColorColumn(string source,string target);
    }
}
