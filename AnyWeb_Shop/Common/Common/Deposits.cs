using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Studio.Array;

namespace Common.Common
{
    /// <summary>
    /// Ԥ�����¼
    /// </summary>
   public class Deposits:IdObject 
    {
       public Deposits() { }
       public Deposits(DataRow dr)
       {
           _depositsID = (int)dr["DepositsID"];
           _amount = (decimal)dr["Amount"];
           _createAt = (DateTime)dr["CreateAt"];
           _abstract = (string)dr["Abstract"];
       }

       private int _depositsID;

       public int DepositsID
       {
           get { return _depositsID; }
           set { _depositsID = value; }
       }

       private decimal _amount;
       /// <summary>
       /// Ԥ������
       /// </summary>
       public decimal Amount
       {
           get { return _amount; }
           set { _amount = value; }
       }


       private string _abstract;
       /// <summary>
       /// ժҪ
       /// </summary>
       public string Abstract
       {
           get { return _abstract; }
           set { _abstract = value; }
       }

       private DateTime _createAt;

       public DateTime CreateAt
       {
           get { return _createAt; }
           set { _createAt = value; }
       }
	
    }
}
