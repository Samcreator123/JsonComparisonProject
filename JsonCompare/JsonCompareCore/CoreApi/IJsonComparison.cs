using JsonCompare.JsonCompareCore.ExtensionApi;

namespace JsonCompare.JsonCompareCore.Api
{
    public interface IJsonComparison : IApiCaller,ICompareSpecifyColumn
    {
        /// <summary>
        /// 對外接口
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="TargetString"></param>
        /// <param name="isTwoWay"></param>
        /// <returns></returns>
        string Compare(string sourceString, string TargetString, bool isTwoWay = false);
        /// <summary>
        /// 先遍歷 source 去比對 target，再遍歷 target 去比對 source，最後把重複的不同欄位刪除
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="TargetString"></param>
        /// <returns></returns>
        internal Dictionary<string,string> TwoWayComparison(string sourceString, string TargetString);

        /// <summary>
        /// 遍歷 source 的結構去比對 target
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="TargetString"></param>
        /// <returns></returns>
        internal Dictionary<string, string> OneWayComparison(string sourceString, string TargetString);
        

    }
}
