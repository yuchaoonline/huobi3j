<script runat="template">
	private string _Namespace = "CMU_";
    [Category("Database")]
	[Description("Class Namespace")]
    public string Namespace
    {
     	get 
		{
			return _Namespace;
		}
     	set 
    	{
    		_Namespace = value;
    	}
    }
	
	private string _Copyright = "Your Copyright";
    [Category("Context")]
	[Description("Your Copyright.")]
    public string Copyright
    {
     	get 
		{
			return _Copyright;
		}
     	set 
    	{
    		_Copyright = value;
    	}
    }
	
	SchemaExplorer.TableSchema _sourceTable = null;
	public SchemaExplorer.TableSchema SourceTable
	{
		get{ return _sourceTable; }
		set{ 
			_sourceTable = value;
			int index = base.OutputFile.LastIndexOf("\\");
			if( index < 0 )
			{
				base.OutputFile +="\\";
			}
			else
			{
				string newPath = base.OutputFile.Substring(0,index);
				if(!newPath.EndsWith("\\")) newPath += "\\";
				base.OutputFile = newPath + _sourceTable.Name+".cs" ;
			}
			
		}
	}
	
	
	
	
//Class Name
public string GetEntClassName(TableSchema table)
{

	return TableClass(table);
}

public string TableClass(TableSchema table)
{
	string className = table.Name;
	if (className.StartsWith(Namespace))
		className = className.Substring(Namespace.Length);
	return String.Format("{0}", MakeSingle(GetPascalCaseName(className)));
}


public string MakeSingle(string name)
{
	string result = name;
	switch(name.ToLower())
	{
		case "news":
		 	break;
		default:
		    if (name.EndsWith("s"))
    		{
        		result = name.Substring(0, name.Length - 1);
    		}
			break;
	}
	return result;
}

/**//// <summary>
/// 检查字段是否有默认值
/// </summary>
/// <param name="cs"></param>
/// <returns></returns>
public bool HasDefaultValue(ColumnSchema cs)
{
    if ((String)cs.ExtendedProperties["CS_Default"].Value == "")
    {
        return false;
    }

    return true;
}

public string GetExtendedProperties(ColumnSchema column)
{
	StringBuilder ret=  new StringBuilder();
	for(int i=0;i<column.ExtendedProperties.Count;i++){
  		SchemaExplorer.ExtendedProperty ep = column.ExtendedProperties[i];
		ret.AppendLine( ep.Name + " : " + ep.Value);
	}
	return ret.ToString();
}

public string FilterString(string msg)
{
    return msg.Replace("\r", "").Replace("\n", "").Replace("\r\n", "");
}
#region ent
//取主

public string GetMemberVariableDeclarationStatement(ColumnSchema column)
{
	return GetMemberVariableDeclarationStatement("private", column,false);
}

public string GetMemberVariableDeclarationStatement(ColumnSchema column,bool canNullable)
{
	return GetMemberVariableDeclarationStatement("private", column,canNullable);
}

public string GetMemberVariableDeclarationStatement(string protectionLevel, ColumnSchema column,bool canNullable)
{
	string statement = protectionLevel + " ";
	statement += GetCSharpVariableType(column,canNullable) + " " + GetMemberVariableName(column);
	
	string defaultValue = GetMemberVariableDefaultValue(column,canNullable);
	if (defaultValue != "")
	{
		statement += " = " + defaultValue;
	}
	statement += ";";
	return statement;
}

public string GetConstructorParameters(TableSchema SourceTable)
{
	string ret = "";
	foreach(ColumnSchema column in SourceTable.Columns)
	{
		ret += GetCSharpVariableType(column) + " " + GetCamelCaseName(GetPropertyName(column)) + ",\r\n\t\t\t";
	}
	return ret.Substring(0, ret.Length - 6);
}

public string GetAssignValue(TableSchema SourceTable)
{
	string ret = "";
	foreach(ColumnSchema column in SourceTable.Columns)
	{
		ret += GetMemberVariableName(column) +  (new String(' ', GetPropertyNameMaxLength(SourceTable) - GetPropertyNameLength(column))) + " = " + GetCamelCaseName(GetPropertyName(column)) + ";\r\n\t\t\t";
	}
	return ret;
}

public string GetReaderAssignmentStatement(ColumnSchema column, int index)
{
	string statement = "if (!reader.IsDBNull(" + index.ToString() + ")) ";
	statement += GetMemberVariableName(column) + " = ";
	
	if (column.Name.EndsWith("TypeCode")) statement += "(" + column.Name + ")";
	
	statement += "reader." + GetReaderMethod(column) + "(" + index.ToString() + ");";
	
	return statement;
}

public string GetCamelCaseName(string value)
{
	string result = value.Substring(0, 1).ToLower() + value.Substring(1);
	switch(result)
	{
		case "operator":
		case "class":
		 result += "_b";
		 break;
	}
	return result;
}
public string GetPascalCaseName(string value)
{
	string result = value.Substring(0, 1).ToUpper() + value.Substring(1);
	switch(result)
	{
		case "Operator":
		case "Class":
		 result += "_p";
		 break;
	}
	return result;
}

public string GetMemberVariableName(ColumnSchema column)
{
	//string propertyName = GetPropertyName(column);
	string propertyName = column.Name;
	string memberVariableName = "_" + GetPascalCaseName(propertyName);
	return memberVariableName;
}

public string GetPrimaryKeyName(TableSchema table)
{
	if(!table.HasPrimaryKey) return table.Columns[0].Name;
	
	if (table.PrimaryKey != null)
	{
		return table.PrimaryKey.MemberColumns[0].Name;
	}
	else
	{
		return table.Columns[0].Name;
		//throw new ApplicationException("This template will only work on tables with a primary key.");
	}
}

public string GetPrimaryKeyParametervalue(TableSchema SourceTable)
{
	string ret = "";
	foreach(ColumnSchema column in SourceTable.PrimaryKey.MemberColumns)
	{
		ret += GetCamelCaseName(GetPropertyName(column)) + ",\n\t\t\t";
	}
	return ret.Substring(0, ret.Length - 5);
}

public string GetPropertyName(ColumnSchema column)
{
	string propertyName = column.Name;
	if (propertyName == column.Table.Name + "Name") return "Name";
	if (propertyName == column.Table.Name + "Description") return "Description";
	if (propertyName.EndsWith("TypeCode")) propertyName = propertyName.Substring(0, propertyName.Length - 4);
	return propertyName;
}

public int GetPropertyNameLength(ColumnSchema column)
{
	return (GetPropertyName(column)).Length;
}
public int GetPropertyNameMaxLength(TableSchema SourceTable)
{
	int ret = 0;
	foreach(ColumnSchema column in SourceTable.Columns)
	{
		ret = ret < GetPropertyNameLength(column)?GetPropertyNameLength(column):ret;
	}
	return ret;
}
		
public string GetMemberVariableDefaultValue_del(ColumnSchema column)
{
	if(column.IsPrimaryKeyMember)
	{
	    return "";
	}
	switch (column.DataType)
	{
		case DbType.Guid:
		{
			return "Guid.Empty";
		}
		case DbType.AnsiString:
		case DbType.AnsiStringFixedLength:
		case DbType.String:
		case DbType.StringFixedLength:
		{
			return "String.Empty";
		}
		default:
		{
			return "";
		}
	}
}

public string GetMemberVariableDefaultValue(ColumnSchema column)
{
	return GetMemberVariableDefaultValue(column,false);
}
public string GetMemberVariableDefaultValue(ColumnSchema column,bool canNullable)
{
	/*if(column.IsPrimaryKeyMember)
	{
	    return "";
	}*/
	if(!canNullable){
		switch (column.DataType)
		{
			case DbType.Byte:
			{
				return "(byte)0";
			}
			//case DbType.Int16:
			//{
			//	return "(short)0";
			//}
			case DbType.Int16:
			case DbType.Int32:
			{
				return "0";
			}
			case DbType.Int64:
			{
				return "0L";
			}
			case DbType.AnsiStringFixedLength:
			case DbType.AnsiString:
			case DbType.String:
			case DbType.StringFixedLength:
			{
				return "String.Empty";
			}
			case DbType.Boolean:
			{
				return "false";
			}
			case DbType.Guid:
			{
				return "Guid.Empty";
			}
			case DbType.Currency:
			case DbType.Decimal:
			{
				return "0M";
			}
			case DbType.Double:
			{
				return "0D";
			}
			case DbType.DateTime:
			case DbType.Date:
			{
				return "new DateTime(1900,1,1)";
			}
			case DbType.Binary:
			{
				return "new byte[0]";
			}
			default:
			{
				return "__Error__" +column.DataType;
			}
		}
	}else{
		return "null";
	}
}

public string GetCSharpVariableType(ColumnSchema column)
{
	return GetCSharpVariableType(column,false);
}

public string GetCSharpVariableType(ColumnSchema column,bool canNullable)
{
	if (column.Name.EndsWith("TypeCode")) return column.Name;
	
	if(!canNullable){
		switch (column.DataType)
		{
			case DbType.AnsiString: return "string";
			case DbType.AnsiStringFixedLength: return "string";
			case DbType.Binary: return "byte[]";
			case DbType.Boolean: return "bool";
			case DbType.Byte: return "byte";
			case DbType.Currency: return "decimal";
			case DbType.Date: return "DateTime";
			case DbType.DateTime: return "DateTime";
			case DbType.Decimal: return "decimal";
			case DbType.Double: return "double";
			case DbType.Guid: return "Guid";
			//case DbType.Int16: return "short";
			case DbType.Int16:
			case DbType.Int32: return "int";
			case DbType.Int64: return "long";
			case DbType.Object: return "object";
			case DbType.SByte: return "sbyte";
			case DbType.Single: return "float";
			case DbType.String: return "string";
			case DbType.StringFixedLength: return "string";
			case DbType.Time: return "TimeSpan";
			case DbType.UInt16: return "ushort";
			case DbType.UInt32: return "uint";
			case DbType.UInt64: return "ulong";
			case DbType.VarNumeric: return "decimal";
			default:
			{
				return "__UNKNOWN__" + column.NativeType;
			}
		}
	}else{
		switch (column.DataType)
		{
			case DbType.AnsiString: return "string";
			case DbType.AnsiStringFixedLength: return "string";
			case DbType.Binary: return "byte[]";
			case DbType.Boolean: return "bool?";
			case DbType.Byte: return "byte?";
			case DbType.Currency: return "decimal?";
			case DbType.Date: return "DateTime?";
			case DbType.DateTime: return "DateTime?";
			case DbType.Decimal: return "decimal?";
			case DbType.Double: return "double?";
			case DbType.Guid: return "Guid?";
			//case DbType.Int16: return "short?";
			case DbType.Int16:
			case DbType.Int32: return "int?";
			case DbType.Int64: return "long?";
			case DbType.Object: return "object";
			case DbType.SByte: return "sbyte?";
			case DbType.Single: return "float?";
			case DbType.String: return "string";
			case DbType.StringFixedLength: return "string";
			case DbType.Time: return "TimeSpan";
			case DbType.UInt16: return "ushort?";
			case DbType.UInt32: return "uint?";
			case DbType.UInt64: return "ulong?";
			case DbType.VarNumeric: return "decimal?";
			default:
			{
				return "__UNKNOWN__" + column.NativeType;
			}
		}
	}
}

public string GetReaderMethod(ColumnSchema column)
{
	switch (column.DataType)
	{
		case DbType.Byte:
		{
			return "GetByte";
		}
		case DbType.Int16:
		{
			return "GetInt16";
		}
		case DbType.Int32:
		{
			return "GetInt32";
		}
		case DbType.Int64:
		{
			return "GetInt64";
		}
		case DbType.AnsiStringFixedLength:
		case DbType.AnsiString:
		case DbType.String:
		case DbType.StringFixedLength:
		{
			return "GetString";
		}
		case DbType.Boolean:
		{
			return "GetBoolean";
		}
		case DbType.Guid:
		{
			return "GetGuid";
		}
		case DbType.Currency:
		case DbType.Decimal:
		{
			return "GetDecimal";
		}
		case DbType.DateTime:
		case DbType.Date:
		{
			return "GetDateTime";
		}
		case DbType.Binary:
		{
			return "GetBytes";
		}
		default:
		{
			return "__SQL__" + column.DataType;
		}
	}
}


public string GetReaderMethod(ColumnSchema column,string value)
{
	string convert = "";
	switch (column.DataType)
	{
		case DbType.Byte:
		{
			convert = "Convert.ToByte({0})";
			break;
		}
		//case DbType.Int16:
		//{
		//	convert = "Convert.ToInt16({0})";
		//	break;
		//}
		case DbType.Int16:
		case DbType.Int32:
		{
			convert = "Convert.ToInt32({0})";
			break;
		}
		case DbType.Int64:
		{
			convert = "Convert.ToInt64({0})";
			break;
		}
		case DbType.AnsiStringFixedLength:
		case DbType.AnsiString:
		case DbType.String:
		case DbType.StringFixedLength:
		{
			convert = "{0}";
			break;
		}
		case DbType.Boolean:
		{
			convert = "Convert.ToBoolean({0})";
			break;
		}
		case DbType.Guid:
		{
			convert = "new Guid({0})";
			break;
		}
		case DbType.Currency:
		case DbType.Decimal:
		{
			convert = "Convert.ToDecimal({0})";
			break;
		}
		case DbType.Double:
		{
			convert = "Convert.ToDouble({0})";
			break;
		}
		case DbType.DateTime:
		case DbType.Date:
		{
			convert = "Convert.ToDateTime({0})";
			break;
		}
		case DbType.Binary:
		{
			convert = "{0}.ToCharArray()";
			break;
		}
		default:
		{
			convert = "__SQL__{0}__" + column.DataType;
			break;
		}
	}
	return string.Format(convert,value);
}

public string GetSqlDbType(ColumnSchema column)
{
	switch (column.NativeType)
	{
		case "bigint": return "BigInt";
		case "binary": return "Binary";
		case "bit": return "Bit";
		case "char": return "Char";
		case "datetime": return "DateTime";
		case "decimal": return "Decimal";
		case "float": return "Float";
		case "image": return "Image";
		case "int": return "Int";
		case "money": return "Money";
		case "nchar": return "NChar";
		case "ntext": return "NText";
		case "numeric": return "Decimal";
		case "nvarchar": return "NVarChar";
		case "real": return "Real";
		case "smalldatetime": return "SmallDateTime";
		case "smallint": return "SmallInt";
		case "smallmoney": return "SmallMoney";
		case "sql_variant": return "Variant";
		case "sysname": return "NChar";
		case "text": return "Text";
		case "timestamp": return "Timestamp";
		case "tinyint": return "TinyInt";
		case "uniqueidentifier": return "UniqueIdentifier";
		case "varbinary": return "VarBinary";
		case "varchar": return "VarChar";
		default: return "__UNKNOWN__" + column.NativeType;
	}
}

public string GetPrimaryKeyType(TableSchema table)
{
	if(!table.HasPrimaryKey) return "";
	if (table.PrimaryKey != null)
	{
		if (table.PrimaryKey.MemberColumns.Count == 1)
		{
			return GetCSharpVariableType(table.PrimaryKey.MemberColumns[0]);
		}
		else
		{
			throw new ApplicationException("This template will not work on primary keys with more than one member column.");
		}
	}
	else
	{
		throw new ApplicationException("This template will only work on tables with a primary key.");
	}
}

public string GetPrimaryKeyParameters(TableSchema SourceTable)
{
	string ret = "";
	foreach(ColumnSchema column in SourceTable.PrimaryKey.MemberColumns)
	{
		ret += GetCSharpVariableType(column) + " " + GetCamelCaseName(GetPropertyName(column)) + ",\n\t\t\t";
	}
	return ret.Substring(0, ret.Length - 5);
}

public string GetPrimaryKeyParameters_Param(TableSchema SourceTable)
{
	string ret = "";
	foreach(ColumnSchema column in SourceTable.PrimaryKey.MemberColumns)
	{
		// <param name="moduleName">模块名</param>
		ret += "\t/// <param name=\"" +GetCamelCaseName(GetPropertyName(column))+"\">" + FilterString(column.Description) + "</param>\r\n";
		//ret += GetCSharpVariableType(column) + " " + GetCamelCaseName(GetPropertyName(column)) + ",\n\t\t\t";
	}
	return ret;
}

public string GetFileName(TableSchema SourceTable)
{
	return SourceTable + ".cs";
}
#endregion ent

#region sqldal

public void BuildSqlParameter(ColumnSchema column)
{
	BuildSqlParameter(column,false);
}
public void BuildSqlParameter(ColumnSchema column,bool useEnt)
{
	BuildSqlParameter(column,false,false);
}
public void BuildSqlParameter(ColumnSchema column,bool useEnt,bool isOutPut)
{	
	Response.WriteLine("System.Data.SqlClient.SqlParameter " + GetSqlParameterName(column) + " = command.Parameters.Add(\"@" + column.Name +"\", " + GetParamSqlDbType(column) + ");");
	if(isOutPut)
	{
		Response.WriteLine(GetSqlParameterName(column) + ".Direction = ParameterDirection.Output;");
	}
	else
	{
		Response.WriteLine(GetSqlParameterName(column) + ".Direction = ParameterDirection.Input;");
		Response.WriteLine(GetSqlParameterName(column) + ".IsNullable = false;");
		if(useEnt)
		{
		Response.WriteLine(GetSqlParameterName(column) + ".Value = ent." + column.Name + ";");
		}
		else
		{
		Response.WriteLine(GetSqlParameterName(column) + ".Value = " + GetCamelCaseName(GetPropertyName(column)) + ";");
		}
	}	
}


public void BuildPopulateValue(ColumnSchema column)
{
	//obj.<%= SourceTable.Columns[i].Name %> = (dr["<%= SourceTable.Columns[i].Name %>"] ==System.DBNull.Value?<%=GetMemberVariableDefaultValue(SourceTable.Columns[i])%>:dr.<%=GetReaderMethod(SourceTable.Columns[i])%>(dr.GetOrdinal("<%= SourceTable.Columns[i].Name %>")));
	if(column.DataType == DbType.Binary)
	{
	Response.WriteLine("obj." + column.Name + " = (dr[\""+ column.Name +"\"] ==System.DBNull.Value?" + GetMemberVariableDefaultValue(column) +":(" + GetCSharpVariableType(column) + ")dr." + GetReaderMethod(column)+"(dr.GetOrdinal(\""+ column.Name +"\")));");
	}
	else
	{
	Response.WriteLine("obj." + column.Name + " = (dr[\""+ column.Name +"\"] ==System.DBNull.Value?" + GetMemberVariableDefaultValue(column) +":dr." + GetReaderMethod(column)+"(dr.GetOrdinal(\""+ column.Name +"\")));");
	}
}

public string GetSqlParameterName(ColumnSchema column)
{
	return "p_" + column.Name;
}

private string GetParamSqlDbType(ColumnSchema column)
{ 
	switch (column.DataType)
        {
            case DbType.AnsiString: 
			if(column.Size != 16)
			return "SqlDbType.VarChar," + column.Size;
			return "SqlDbType.Text";
            case DbType.AnsiStringFixedLength: return "SqlDbType.VarChar," + column.Size;
            case DbType.Binary: return "SqlDbType.Binary";
            case DbType.Boolean: return "SqlDbType.Bit";
            case DbType.Byte: return "SqlDbType.Char";
            case DbType.Currency: return "SqlDbType.Decimal";
            case DbType.Date: return "SqlDbType.DateTime";
            case DbType.DateTime: return "SqlDbType.DateTime";
            case DbType.Decimal: return "SqlDbType.Decimal";
            case DbType.Double: return "SqlDbType.Money";
            case DbType.Guid: return "SqlDbType.UniqueIdentifier";
            case DbType.Int16: return "SqlDbType.Int";
            case DbType.Int32: return "SqlDbType.Int";
            case DbType.Int64: return "SqlDbType.BigInt";
            //case DbType.Object: return "object";
            case DbType.SByte: return "SqlDbType.Char";
            case DbType.Single: return "SqlDbType.Float";
            case DbType.String: 
			if(column.Size != 16)
			return "SqlDbType.VarChar," + column.Size;
			return "SqlDbType.Text";
            case DbType.StringFixedLength: return "SqlDbType.VarChar," + column.Size;
            case DbType.Time: return "SqlDbType.Timestamp";
            case DbType.UInt16: return "SqlDbType.Int";
            case DbType.UInt32: return "SqlDbType.Int";
            case DbType.UInt64: return "SqlDbType.BigInt";
            case DbType.VarNumeric: return "SqlDbType.Decimal";
            default:
            {
                return "__UNKNOWN__" + column.DataType;
            }
        }
}
#endregion sqldal
//页面显示赋值
public void BuildShowValue(ColumnSchema column)
{
	//if(column.IsPrimaryKeyMember) return;
	Response.WriteLine(string.Format("this.txt{0}.Text = ent.{0}.ToString();",column.Name));
}
//页面取值赋值
public void BuildSetValue(ColumnSchema column)
{
	if(column.IsPrimaryKeyMember) return;
	string value = string.Format("this.txt{0}.Text",column.Name);
	Response.WriteLine(string.Format("ent.{0} = {1};",column.Name,GetReaderMethod(column,value)));
}
//建文本控件
public void BuildTextField(ColumnSchema column)
{
	string name = column.Name;
	Response.WriteLine(string.Format("<asp:TextBox ID=\"txt{0}\" runat=\"server\"></asp:TextBox>",name));
}
//建绑定字段
public void BuildBoundField(ColumnSchema column)
{
	string name = column.Name;
	Response.WriteLine(string.Format("<asp:BoundField DataField=\"{0}\" HeaderText=\"{0}\" SortExpression=\"{0}\" />",name));
}
</script>