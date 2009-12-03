using System;

using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Studio.Array
{
	/// <summary>
	/// Description:��ȡ����������ӣ���������������Random�����������Ч�������
	/// Author:Turboc
	/// Date:2006-12-6
	/// </summary>
	public class RandomSeek
	{
		public RandomSeek()
		{
			if (QueryPerformanceFrequency(out frequency) == false)
			{

				// ����֧��QueryPerformanceFrequencyʱ����������
				//throw new Win32Exception();
				throw new Exception("ϵͳ��֧��WIN32����!");

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

		// �����������
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
