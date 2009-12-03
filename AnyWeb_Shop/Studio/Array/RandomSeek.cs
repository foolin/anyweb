using System;

using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Studio.Array
{
	/// <summary>
	/// Description:获取随机数的种子（此用做连续调用Random生成随机数无效的情况）
	/// Author:Turboc
	/// Date:2006-12-6
	/// </summary>
	public class RandomSeek
	{
		public RandomSeek()
		{
			if (QueryPerformanceFrequency(out frequency) == false)
			{

				// 当不支持QueryPerformanceFrequency时，产生错误
				//throw new Win32Exception();
				throw new Exception("系统不支持WIN32函数!");

			}
		}

		[DllImport("KERNEL32")]
		private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

 

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(out long lpFrequency);

 

		private long frequency;

		private long stop=0;

		Decimal multiplier = new Decimal(1.0e9);

		public void GetCounter()
		{

			QueryPerformanceCounter(out stop);

		}

		public double Duration(int iterations)
		{

			return ((((double)stop * (double) multiplier) / (double) frequency)/iterations);

		}

		// 生成随机种子
		public long Seek
		{
			get
			{
				
				this.GetCounter();
				return DateTime.Now.Ticks + (long)Duration(10)*100;

			}

		}


	}
}
