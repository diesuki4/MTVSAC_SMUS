using System.Collections;
using System.Collections.Generic;

public static class AccountManager
{
    public static string id;
    public static string passwd;
    public static string genre;

    public static bool isLogined;

    public static bool Login(string _id, string _passwd)
    {
        string query = string.Format("SELECT * from userinfo WHERE id = '{0}' AND passwd = '{1}';", _id, _passwd);
        List<Dictionary<string, object>> result = DBManager.Select(query);

        isLogined = (0 < result.Count);

        if (isLogined)
        {
            id = _id;
            passwd = _passwd;
            genre = result[0]["genre"] as string;
        }
        else
        {
            id = null;
            passwd = null;
            genre = null;
        }

        return isLogined;
    }

    public static void Logout()
    {
        id = null;
        passwd = null;
        genre = null;

        isLogined = false;
    }

    public static bool SignUp(string _id, string _passwd, string _genre)
    {
        string query = string.Format("INSERT INTO userinfo VALUES('{0}', '{1}', '{2}');", _id, _passwd, _genre);

        return DBManager.Execute(query);
    }

    public static bool Update(string _passwd, string _genre)
    {
        if (id == null)
            return false;

        string query = string.Format("UPDATE userinfo SET passwd = '{0}', genre = '{1}' WHERE id = '{2}';", _passwd, _genre, id);

        return DBManager.Execute(query);        
    }
}
