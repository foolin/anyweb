using System;
using System.Data.OracleClient;

namespace Studio.Data
{
	/// <summary>
	/// Name:���ݴ�ȡ������
	/// Description:�������ݿ����ͺ������ַ���������ȡ��ʵ��
	/// Author:л��
	/// CreateDate:2005-07-11
	/// Update: 2006-06-06 Earth
	/// </summary>
	public class DbFactory
	{
		/// <summary>
		/// ����һ��ִ����
		/// </summary>
		/// <param name="dbtype">���ݿ�����</param>
		/// <param name="connectString">�����ַ���</param>
		/// <returns>���ݲ���ִ����</returns>
		public static IDbExecutor CreateExecutor(DatabaseType dbtype, string connectString)
		{
			switch(dbtype)
			{
				//�������ݿ�����
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
				default://Ĭ��SQL Server
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