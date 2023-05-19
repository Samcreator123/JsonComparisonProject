using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JsonCompare.JsonCompareCore.Impl
{
    /// <summary>
    /// 負責兩個JObject物件比較的邏輯細節
    /// </summary>
    public class JsonComparisonCoreImpl
    {
        public static Dictionary<string, string> GetDiffentProperties(JObject sourceObj, JObject targetObj)
        {
            Dictionary<string, string> differentProperties = new Dictionary<string, string>();

            NestedCoreLogic(differentProperties, sourceObj, targetObj);

            return differentProperties;
        }
        private static void NestedCoreLogic(Dictionary<string, string> differentProperties, JObject sourceObj, JObject targetObj, string path = "", string prefixPath = "")
        {
            // 因為遞迴至下次會使路徑查找對應屬性不再靈驗，又要在結果顯示路徑，所以必須要記錄至prefixPath
            if (targetObj == null)
            {
                differentProperties.Add(prefixPath + path, $"{prefixPath + path} 的值不同，來源為有該物件,比較值為空");
                return;
            }

            foreach (var property in sourceObj.Properties())
            {
                string name = property.Name;
                // 比對該欄位
                path = path + "." + property.Name;

                switch (GetActualType(property.Value, path))
                {
                    case JTokenType.Array:
                        HandleJArray(differentProperties, (JArray)sourceObj.SelectToken(path), (JArray)targetObj.SelectToken(path), path, prefixPath);
                        break;
                    case JTokenType.Object:
                        NestedCoreLogic(differentProperties, (JObject)(sourceObj.SelectToken(path)), (JObject)(targetObj.SelectToken(path)), "", (prefixPath + path));
                        break;
                    default:
                        HandleJValue(differentProperties, (JValue)sourceObj.SelectToken(path), (JValue)targetObj.SelectToken(path), path, prefixPath);
                        break;
                }
                // 比對該物件下一個欄位，所以要把path的欄位刪掉
                path = new Regex($"(.+)(?=.{property.Name})").Match(path).Value;

            }
        }
        private static JTokenType GetActualType(JToken token, string path = "")
        {
            // 獲得屬性名
            string propertyName = path.Split('.').Last();

            // 獲得除了屬姓名的路徑
            path = new Regex($"(.+)(?=.{propertyName})").Match(path).Value;
            JToken thatTokenLookingFor;
            thatTokenLookingFor = token.SelectToken(path);


            if (thatTokenLookingFor is JObject)
            {
                return JTokenType.Object;
            }
            if (thatTokenLookingFor is JArray)
            {
                return JTokenType.Array;
            }

            return JTokenType.Property;

        }
        private static void HandleJArray(Dictionary<string, string> differentProperties, JArray sourceArray, JArray targetArray, string path = "", string prefixPath = "")
        {
            int index = 0;

            // 保證path在迴圈只會變動index
            string tempPath = $"{path}";

            if (targetArray == null)
            {
                differentProperties.Add(prefixPath + tempPath, $"{prefixPath + tempPath} 的值不同，來源為有該陣列,比較值為空");
                return;
            }

            if (targetArray.Count() == 0 && sourceArray.Count() == 0)
            {
                return;
            }

            if (targetArray.Count() <= 0)
            {
                differentProperties.Add(prefixPath + tempPath, $"{prefixPath + tempPath} 的值不同，來源為有該陣列,比較值陣列是沒有元素的");
                return;
            }

            foreach (var token in sourceArray)
            {
                tempPath = $"{path}[{index}]";

                if (targetArray.Count() <= index)
                {
                    differentProperties.Add(prefixPath + tempPath, $"{prefixPath + tempPath} 的值不同，來源為有該物件,比較值為空");
                    index++;
                    continue;
                }
                if (token.Type != JTokenType.Object)
                {
                    HandleJValue(differentProperties, (JValue)token, (JValue)targetArray[index], tempPath, prefixPath);
                    index++;
                    continue;
                }
                if ((JObject)(targetArray[index]) == null)
                {
                    differentProperties.Add(prefixPath + tempPath, $"{prefixPath + tempPath} 的值不同，來源為有該物件,比較值為空");
                    index++;
                    continue;
                }
                // 因為是物件所以遞歸
                NestedCoreLogic(differentProperties, (JObject)token, (JObject)targetArray[index], "", prefixPath + tempPath);
                index++;
            }
        }
        private static void HandleJValue(Dictionary<string, string> differentProperties, JValue sourceValue, JValue targetValue, string valueName = "", string prefixPath = "")
        {
            if (sourceValue.Value == null && targetValue.Value == null)
            {
                return;
            }
            if (targetValue == null)
            {
                differentProperties.Add(prefixPath + valueName, $"{prefixPath + valueName} 的值不同，來源為{sourceValue},比較值為null");
                return;
            }
            //jvalue也是一個key-value ，tostring能確保一致不然會有 100000 != 100000的事情，推測可能是記憶體位置不同導致
            if (targetValue.Value.ToString() == sourceValue.Value.ToString())
            {
                return;
            }
            differentProperties.Add(prefixPath + valueName, $"{prefixPath + valueName} 的值不同，來源為{sourceValue},比較值為{targetValue}");

        }
    }
}
