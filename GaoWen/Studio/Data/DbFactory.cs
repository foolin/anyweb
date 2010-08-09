using System;
using System.Data.OracleClient;

namespace Studio.Data
{
	/// <summary>
	/// Name:数据存取器工厂
	/// Description:根据数据库类型和连接字符串创建存取器实例
	/// Author:谢康
	/// CreateDate:2005-07-11
	/// Update: 2006-06-06 Earth
	/// </summary>
	public class DbFactory
	{
		/// <summary>
		/// 建立一个执行者
		/// </summary>
		/// <param name="dbtype">数据库类型</param>
		/// <param name="connectString">连接字符串</param>
		/// <returns>数据操作执行者</returns>
		public static IDbExecutor CreateExecutor(DatabaseType dbtype, string connectString)
		{
			switch(dbtype)
			{
				//各种数据库类型
				case DatabaseType.SqlServer:
				{
					return new SqlDbExecutor(connectString);;
				}
				case DatabaseType.Oracle:
				{
					return new OracleDbExecutor(connectString);
				}
				case DatabaseType.Access:
				{
					return new OleDbExecutor( connectString);
				}
				case DatabaseType.OleDb:
				{
					return new OleDbExecutor( connectString);
				}
				default://默认SQL Server
				{
					return new SqlDbExecutor(connectString);
				}
			}
		}
	}

	/// <summary>
	/// DataBase Type
	/// </summary>
	public enum DatabaseType : int
	{
		SqlServer	= 1, 
		Oracle		= 2,
		Access		= 3,
		OleDb		= 4
	}
}
