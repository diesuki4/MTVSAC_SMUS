using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public static class DBManager
{
    static string SERVER = Encoder.Decode("d3d3NS5keW51Lm5ldA==");
    static string PORT = Encoder.Decode("NTYwMzM=");
    static string database = Encoder.Decode("c211cw==");
    static string userid = Encoder.Decode("c211cw==");
    static string passwd = Encoder.Decode("c211cw==");
    static string connInfo = "Server=" + SERVER + ";Port=" + PORT + ";Database=" + database + ";User Id=" + userid + ";Password=" + passwd + "";

    static MySqlConnection conn;

    static void Connect()
    {
        conn = new MySqlConnection(connInfo);

        conn.Open();
    }

    static void Disconnect()
    {
        conn.Close();

        conn = null;
    }

    public static bool Execute(string query)
    {
        Connect();

        MySqlCommand command = new MySqlCommand(query, conn);

        int rows = command.ExecuteNonQuery();

        Disconnect();

        return 0 < rows;
    }

    public static List<Dictionary<string, object>> Select(string query)
    {
        Connect();

        DataTable dt = new DataTable();

        MySqlDataAdapter adapter =  new MySqlDataAdapter(query, conn);

        adapter.Fill(dt);

        Disconnect();

        return Simplify(dt);
    }

    static List<Dictionary<string, object>> Simplify(DataTable dt)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            for (int j = 0; j < dt.Columns.Count; ++j)
                dict[dt.Columns[j].ColumnName] = dt.Rows[i][j];

            list.Add(dict);
        }

        return list;
    }
}
