using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare.JsonCompareCore.ExtensionApi
{
    public interface ICompareSpecifyColumn
    {
        string CompareSpecifyColumns(string sourceStr,string targetStr,bool isTwoWay = false, params string[] specifyColumns);
    }
}
