using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace LumluxSSYDB.DAL
{
	/// <summary>
	/// 数据访问类:tLightStateInfoes
	/// </summary>
	public partial class tLightStateInfoes
	{
		public bool DeleteWhere(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from tLightStateInfoes where " + where);
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

