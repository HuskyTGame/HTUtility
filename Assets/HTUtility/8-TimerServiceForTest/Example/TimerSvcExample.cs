/****************************************************
	文件：TimerSvcExample.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/1 15:51:49
	功能：例子（测试脚本时使用的计时器）
*****************************************************/

using UnityEngine;

namespace HTUtility
{
    public class TimerSvcExample : MonoBehaviour
    {
        private TimerServiceForTest mTimerSvc;
        private void Awake()
        {
            //初始化计时器服务
            mTimerSvc = TimerServiceForTest.Instance;
            mTimerSvc.Init();
            //订阅（注册）计时器
            mTimerSvc.Subscribe("TestExample");
        }
        private void Start()
        {
            //使用计时功能：测试 Function 的性能消耗（以 加法 为例）
            int times = 10000000;//循环1000万次
            float time;//计时时间
            int a = 1;
            int b = 2;
            int res = 0;

            //1.不使用 Function：
            mTimerSvc.SetOpen("TestExample", true);//开启计时
            for (int i = 0; i < times; i++)
            {
                res = a + b;
            }
            mTimerSvc.SetOpen("TestExample", false);//结束计时
            time = mTimerSvc.GetSumTime("TestExample");
            Debug.LogFormat("不使用 Funciton，循环{0}次，共耗时(毫秒)：{1}", times, time);

            //2.使用 Function：
            mTimerSvc.SetOpen("TestExample", true);//开启计时
            for (int i = 0; i < times; i++)
            {
                res = Plus(a, b);
            }
            mTimerSvc.SetOpen("TestExample", false);//结束计时
            time = mTimerSvc.GetSumTime("TestExample");
            Debug.LogFormat("使用 Funciton，循环{0}次，共耗时(毫秒)：{1}", times, time);
        }
        private void OnDisable()
        {
            mTimerSvc.Unsubscribe("TestExample");//取消订阅
        }

        private int Plus(int a, int b)
        {
            return a + b;
        }
    }
}