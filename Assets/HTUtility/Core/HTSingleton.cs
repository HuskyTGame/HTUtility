/****************************************************
	文件：HTSingleton.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 14:41:19
	功能：普通单例模板
*****************************************************/

namespace HTUtility
{
    public class HTSingleton<T> where T : class, new()
    {
        private static T mInstance = null;
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new T();
                }
                return mInstance;
            }
        }
    }
}