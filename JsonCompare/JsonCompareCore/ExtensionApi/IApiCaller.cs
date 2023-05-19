using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare.JsonCompareCore.ExtensionApi
{
    public interface IApiCaller
    {
        string CallApiWithPost(string url,string body);
    }
}
