using JsonCompare.JsonCompareCore.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JsonCompare.JsonCompareCore.Impl
{
    /// <summary>
    /// 處理細節實作交互的的邏輯，細節實作用靜態物件，不用注入是因為懶
    /// </summary>
    public class JsonComparisonImpl : IJsonComparison
    {
        public JsonComparisonImpl()
        {
            
        }
        public string Compare(string sourceString, string targetString, bool isTwoWay = false)
        {
            Dictionary<string, string> resultDic = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(sourceString) || string.IsNullOrWhiteSpace(targetString))
            {
                return "請輸入值";
            }

            try
            {
                JObject.Parse(sourceString);
                JObject.Parse(targetString);
            }
            catch (JsonReaderException)
            {
                return "請輸入符合json格式的資料";
            }

            if (isTwoWay)
            {
                resultDic = this.TwoWayComparison(sourceString,targetString);
            }
            else
            {
                resultDic = this.OneWayComparison(sourceString, targetString);
            }

            return this.GetResultStr(resultDic);
        }
        public Dictionary<string,string> TwoWayComparison(string sourceString, string targetString)
        { 
            JObject sourceObj= JObject.Parse(sourceString); 
            JObject targetObj= JObject.Parse(targetString);

            Dictionary<string, string> sourceCompareTarget = JsonComparisonCoreImpl.GetDiffentProperties(sourceObj, targetObj);
            Dictionary<string, string> targetCompareSource = JsonComparisonCoreImpl.GetDiffentProperties(targetObj, sourceObj)
                                                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Replace("來源", "目標"));

            Dictionary<string,string> finalDiffProperties = sourceCompareTarget.Concat(targetCompareSource)
                                                                               .GroupBy(kvp => kvp.Key)
                                                                               .ToDictionary(g=>g.Key,g=>g.First().Value);
            return finalDiffProperties;
        }
        public Dictionary<string, string> OneWayComparison(string sourceString, string targetString)
        {
            JObject sourceObj = JObject.Parse(sourceString);
            JObject targetObj = JObject.Parse(targetString);

            Dictionary<string, string> differentProperties = JsonComparisonCoreImpl.GetDiffentProperties(sourceObj,targetObj);

            return differentProperties;
        }
        private string GetResultStr(Dictionary<string, string> differentProperties)
        {
            if (differentProperties.Count() <= 0)
            {
                return "完全一致";
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var property in differentProperties)
            {
                string propertyStr = property.Value.ToString();

                stringBuilder.Append(propertyStr + "\r\n");
            }
            return stringBuilder.ToString();
        }

        public string CallApiWithPost(string url,string body)
        {

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            
            return response.Content.ReadAsStringAsync().Result;
        }

        public string CompareSpecifyColumns(string sourceStr, string targetStr,bool isTwoWay=false, params string[] specifyColumns)
        {
            Dictionary<string, string> diffDictionary;
            Dictionary<string, string> specifyDiffDic = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(sourceStr) || string.IsNullOrWhiteSpace(targetStr))
            {
                return "請輸入值";
            }

            try
            {
                JObject.Parse(sourceStr);
                JObject.Parse(targetStr);
            }
            catch (JsonReaderException)
            {
                return "請輸入符合json格式的資料";
            }

            if (isTwoWay)
            {
                diffDictionary = this.TwoWayComparison(sourceStr, targetStr);
            }
            else
            {
                diffDictionary = this.OneWayComparison(sourceStr, targetStr);
            }

            if (specifyColumns.Count() <= 0)
            {
                return this.GetResultStr(diffDictionary);
            }

            foreach (var keyValuePair in diffDictionary)
            {
                // 讓diff的值比較specifyColumns，如果有配對到則返回true，並停止select
                bool isDiffColumnInSpecifyColumn = specifyColumns.Select(col => new Regex($"\\.{col}(?:\\[\\d+\\])?(?:\\.)|\\.{col}(?:\\[\\d+\\])?$").IsMatch(keyValuePair.Key)).FirstOrDefault(def => def == true);

                if (isDiffColumnInSpecifyColumn)
                {
                    specifyDiffDic.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return this.GetResultStr(specifyDiffDic);
        }
    
        
    }
}
