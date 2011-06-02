using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace AnyWell.AW_DL
{
    public abstract class Bean_Base
    {
        protected abstract Dao_Base dao{get;}

        private int _fdAutoId;

        public int fdAutoId
        {
            get { return _fdAutoId; }
            set { _fdAutoId = value; }
        }

        /// <summary>
        /// 获取单条数据并赋值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual bool funcGetDataByID(string id)
        {
            DataSet ds = dao.funcGetByID(id);
            if (ds.Tables[0].Rows.Count == 1)
            {
                funcFromDataRow(ds.Tables[0].Rows[0]);
                ds.Dispose();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取指定字段值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        protected virtual bool funcGetDataByID(string id, string columns)
        {
            DataSet ds = dao.funcGetByID(id, columns);
            if (ds.Tables[0].Rows.Count == 1)
            {
                funcFromDataRow(ds.Tables[0].Rows[0]);
                ds.Dispose();
                return true;
            }
            return false;
        }


        /// <summary>
        /// 获取单条数据并赋值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual bool funcGetDataByID(int id)
        {
            DataSet ds = dao.funcGetByID(id);
            if (ds.Tables[0].Rows.Count == 1)
            {
                funcFromDataRow(ds.Tables[0].Rows[0]);
                ds.Dispose();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取指定字段值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        protected virtual bool funcGetDataByID(int id, string columns)
        {
            DataSet ds = dao.funcGetByID(id, columns);
            if (ds.Tables[0].Rows.Count == 1)
            {
                funcFromDataRow(ds.Tables[0].Rows[0]);
                ds.Dispose();
                return true;
            }
            return false;
        }




        /// <summary>
        /// 给对象属性赋值
        /// </summary>
        /// <param name="aRow"></param>
        public virtual void funcFromDataRow(DataRow aRow)
        {
            PropertyInfo extProp = this.GetType().GetProperty("ExtProperties"); //读取扩展字段属性
            Hashtable extProps = null;
            if (extProp != null)
            {
                extProps = (Hashtable)extProp.GetValue(this, null);
            }

            foreach (DataColumn column in aRow.Table.Columns)
            {
                PropertyInfo property = this.GetType().GetProperty(column.ColumnName);
                if (property == null) property = this.GetProperty(column.ColumnName.ToLower());
                if (property != null)
                {
                    if (aRow[column] != DBNull.Value)
                    {
                        if (property.PropertyType == column.DataType)
                            property.SetValue(this, aRow[column], null);
                        else if (property.PropertyType == Type.GetType("System.String") && column.DataType == Type.GetType("System.Byte[]"))
                            property.SetValue(this, Encoding.Default.GetString((byte[])aRow[column]), null);
                        else
                            property.SetValue(this, Convert.ChangeType(aRow[column], property.PropertyType), null);
                    }
                }
                else
                {
                    if (column.ColumnName.ToUpper().StartsWith("FDEXT") && extProps != null)
                    {
                        extProps.Add(column.ColumnName, aRow[column] == DBNull.Value ? "" : aRow[column]);
                    }
                }
            }
        }


        PropertyInfo GetProperty(string name)
        {
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.Name.ToLower() == name)
                    return pi;
            }
            return null;
        }

        /// <summary>
        /// 从Xml节点上读取属性的值
        /// </summary>
        /// <param name="node"></param>
        public virtual int funcFromXml(string xmlFile)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(xmlFile);
            }
            catch
            {
                return 0;
            }

            XmlNode root = xml.SelectSingleNode(dao._propTable);
            if (root != null)
            {
                PropertyInfo[] properties = this.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.MemberType == MemberTypes.Property && property.CanWrite && property.Name.ToLower().StartsWith("fd"))
                    {
                        XmlNode node = root.SelectSingleNode(property.Name);
                        if (node != null) property.SetValue(this, Convert.ChangeType(node.InnerText, property.PropertyType), null);
                    }
                }

                return 1;
            }
            else
            {
                xml.Clone();
                return 0;
            }
        }

        /// <summary>
        /// 将对象输出为Xml节点
        /// </summary>
        /// <returns></returns>
        public virtual string funcToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            sb.AppendLine("<" + dao._propTable + ">");
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.MemberType == MemberTypes.Property && property.CanRead && property.Name.ToLower().StartsWith("fd") && property.Name != "fdAutoID")
                {
                    if (property.GetValue(this, null) != null)
                    {
                        if (property.PropertyType == Type.GetType("System.String"))
                        {
                            sb.AppendLine("<" + property.Name + "><![CDATA[" + property.GetValue(this, null).ToString() + "]]></" + property.Name + ">");
                        }
                        else
                        {
                            sb.AppendLine("<" + property.Name + ">" + property.GetValue(this, null).ToString() + "</" + property.Name + ">");
                        }
                    }
                }
            }
            sb.AppendLine("</" + dao._propTable + ">");
            return sb.ToString();
        }
    }
}
