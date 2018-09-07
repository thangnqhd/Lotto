// Decompiled with JetBrains decompiler
// Type: ConfigClient.Database
// Assembly: ConfigClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 91B14E60-88D6-4D0B-9EE9-0CC9C9334998
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\ConfigClient.dll

using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ConfigClient
{
  public class Database
  {
    private string _strConStr = "";
    private SqlConnection _con;
    private static SqlDataReader _datareader;

    public Database(string constr, string strKey)
    {
      this._strConStr = this.Decrypt(constr, strKey);
      this._con = new SqlConnection(this._strConStr);
    }

    private string Decrypt(string strEncrypted, string strKey)
    {
      try
      {
        TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(strKey));
        cryptoServiceProvider.Key = hash;
        cryptoServiceProvider.Mode = CipherMode.ECB;
        byte[] inputBuffer = Convert.FromBase64String(strEncrypted);
        return Encoding.Unicode.GetString(cryptoServiceProvider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
      }
      catch
      {
        return "0";
      }
    }

    public string ConnectingString
    {
      get
      {
        if (!this._strConStr.Equals(""))
          return this._strConStr;
        return (string) null;
      }
      set
      {
        this._strConStr = value;
      }
    }

    public SqlConnection GetConnection()
    {
      SqlConnection sqlConnection = new SqlConnection(this._strConStr);
      if (sqlConnection.State == ConnectionState.Closed)
        sqlConnection.Open();
      return sqlConnection;
    }

    public DataTable GetData(SqlCommand cmd)
    {
      try
      {
        if (cmd.Connection != null)
        {
          using (DataSet dataSet = new DataSet())
          {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
              sqlDataAdapter.SelectCommand = cmd;
              sqlDataAdapter.Fill(dataSet);
              return dataSet.Tables[0];
            }
          }
        }
        else
        {
          using (SqlConnection connection = this.GetConnection())
          {
            using (DataSet dataSet = new DataSet())
            {
              using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
              {
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.SelectCommand.Connection = connection;
                sqlDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
              }
            }
          }
        }
      }
      finally
      {
      }
    }

    public SqlDataReader GetReadOnlyData(SqlCommand cmd)
    {
      try
      {
        if (cmd.Connection != null)
          return cmd.ExecuteReader();
        using (SqlConnection connection = this.GetConnection())
        {
          cmd.Connection = connection;
          Database._datareader = cmd.ExecuteReader();
          return cmd.ExecuteReader();
        }
      }
      finally
      {
      }
    }

    public DataSet GetDsData(SqlCommand cmd)
    {
      try
      {
        if (cmd.Connection != null)
        {
          using (DataSet dataSet = new DataSet())
          {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
              sqlDataAdapter.SelectCommand = cmd;
              sqlDataAdapter.Fill(dataSet);
              return dataSet;
            }
          }
        }
        else
        {
          using (SqlConnection connection = this.GetConnection())
          {
            using (DataSet dataSet = new DataSet())
            {
              using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
              {
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.SelectCommand.Connection = connection;
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
              }
            }
          }
        }
      }
      finally
      {
      }
    }

    public DataTable GetData(string sql)
    {
      try
      {
        using (SqlConnection connection = this.GetConnection())
        {
          using (SqlCommand command = connection.CreateCommand())
          {
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            using (DataSet dataSet = new DataSet())
            {
              using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
              {
                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.SelectCommand.Connection = connection;
                sqlDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
              }
            }
          }
        }
      }
      finally
      {
      }
    }

    public void ExecuteNonQuery(SqlCommand cmd)
    {
      try
      {
        using (SqlConnection connection = this.GetConnection())
        {
          cmd.Connection = connection;
          cmd.ExecuteNonQuery();
        }
      }
      finally
      {
      }
    }

    public object ExecuteScalar(SqlCommand cmd)
    {
      try
      {
        using (SqlConnection connection = this.GetConnection())
        {
          cmd.Connection = connection;
          return cmd.ExecuteScalar();
        }
      }
      finally
      {
      }
    }

    public int DBSize()
    {
      using (SqlCommand cmd = new SqlCommand("select sum(size) * 8 * 1024 from sysfiles"))
      {
        cmd.CommandType = CommandType.Text;
        return (int) this.ExecuteScalar(cmd);
      }
    }

    public bool CheckConnect()
    {
      return this.GetData(new SqlCommand("select getdate()")).Rows.Count > 0;
    }
  }
}
