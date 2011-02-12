using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;

namespace AnyWell.Configs
{
    public class CacheAgent
    {
        public static void ClearCache(string startStr)
        {
            List<string> keyList = new List<string>();
            IDictionaryEnumerator cacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                if (cacheEnum.Key.ToString().StartsWith(startStr))
                {
                    keyList.Add(cacheEnum.Key.ToString());
                }
            }
            foreach (string str in keyList)
            {
                HttpRuntime.Cache.Remove(str);
            }
        }
    }
}
