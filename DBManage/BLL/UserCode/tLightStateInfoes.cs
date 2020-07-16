using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LumluxSSYDB.Model;
namespace LumluxSSYDB.BLL
{
	/// <summary>
	/// tLightStateInfoes
	/// </summary>
	public partial class tLightStateInfoes
	{
		#region  ExtensionMethod
        public bool DeleteWhere(string where)
        {
            return dal.DeleteWhere(where);
        }
		#endregion  ExtensionMethod
	}
}

