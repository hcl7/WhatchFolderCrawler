using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;

public class pafap_sql
{
    public SqlConnection Sql_Conn;
    public bool isConnected = false;
    private int sqlQueryTimeout = 120;
    public string errors = "";
    public int rowCounting = 0;
    //sql connection class constructor;
    public pafap_sql(string cstr)
    {
        try
        {
            Sql_Conn = new SqlConnection(cstr);
            Sql_Conn.Open();
            isConnected = true;
        }
        catch (Exception e)
        {
            errors = "sqlConn Error: " + e.Message;
            isConnected = false;
        }
    }
    // run querys;
    public bool runSQLQuery(string SQL)
    {
        if (isConnected == false || !(Sql_Conn.State == System.Data.ConnectionState.Open))
            return false;

        SqlCommand dbcmd = Sql_Conn.CreateCommand();
        dbcmd.CommandType = CommandType.Text;
        dbcmd.CommandText = SQL;
        dbcmd.CommandTimeout = sqlQueryTimeout;
        bool ret = true;
        try
        {
            dbcmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            ret = false;
            errors = "runSQLQuery Error: " + e.Message;
        }
        finally
        {
            dbcmd.Dispose();
            dbcmd = null;
        }
        return ret;
    }
    // run querys;
    public SqlDataReader getSQLResult(string sql)
    {
        if (isConnected == false || !(Sql_Conn.State == System.Data.ConnectionState.Open))
            return null;
        SqlCommand dbcmd = Sql_Conn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.CommandTimeout = sqlQueryTimeout;
        SqlDataReader reader = null;
        try
        {
            reader = dbcmd.ExecuteReader();
        }
        catch (Exception e)
        {
            reader = null;
            errors = "getSQLResult Error: " + e.Message;
        }
        finally
        {
            dbcmd.Dispose();
            dbcmd = null;
        }
        return reader;
    }
    // run querys;
    public string getValueFromTable(string sql, int fieldNum)
    {
        string strReturn = string.Empty;
        if (isConnected == false || !(Sql_Conn.State == System.Data.ConnectionState.Open))
            return strReturn;
        SqlCommand dbcmd = Sql_Conn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.CommandTimeout = sqlQueryTimeout;
        try
        {
            SqlDataReader reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                strReturn = (string)reader[fieldNum].ToString();
            }
            reader.Close();
            reader = null;
        }
        catch (Exception e)
        {
            errors = "getValueFromTable Error: " + e.Message;
        }
        finally
        {
            dbcmd.Dispose();
            dbcmd = null;
        }

        return strReturn;
    }
    // ping database;
    public bool ping()
    {
        bool connState = true;
        if (isConnected == false || !(Sql_Conn.State == System.Data.ConnectionState.Open))
            connState = false;
        if (connState == true)
        {
            SqlCommand dbcmd = Sql_Conn.CreateCommand();
            dbcmd.CommandText = "SELECT 1+1";
            dbcmd.CommandTimeout = sqlQueryTimeout;
            try
            {
                dbcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connState = false;
                errors = "Ping Error: " + e.Message;
            }
            finally
            {
                dbcmd.Dispose();
                dbcmd = null;
            }
        }
        return connState;
    }
    //get integer from table;
    public int getIntFromTable(string sql, int fieldNum)
    {
        int intReturn = 0;
        if (isConnected == false || !(Sql_Conn.State == System.Data.ConnectionState.Open))
            return intReturn;
        SqlCommand dbcmd = Sql_Conn.CreateCommand();
        dbcmd.CommandText = sql;
        dbcmd.CommandTimeout = 120;
        try
        {
            SqlDataReader reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                intReturn = (int)reader[fieldNum];
            }
            reader.Close();
            reader = null;
        }
        catch (Exception e)
        {
            errors = "getIntFromTable Error: " + e.Message;
        }
        finally
        {
            dbcmd.Dispose();
            dbcmd = null;
        }

        return intReturn;
    }

    public bool checkValue(string sqlquery)
    {
        bool connState = isConnected;
        if (isConnected == false || !(Sql_Conn.State == System.Data.ConnectionState.Open))
            connState = false;
        string icheck = "";
        try
        {
            SqlCommand com = new SqlCommand(sqlquery, Sql_Conn);
            icheck = (string)com.ExecuteScalar();
            if (icheck != null)
            {
                return true;
            }
            else return false;
        }
        catch (Exception ex)
        {
            errors = "checkValue error: " + ex.Message;
            return false;
        }
    }
}