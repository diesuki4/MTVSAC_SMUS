using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertInfo
{
    public int concert_id;
    public string id;
    public string title;
    public string genre;
}

public class ConcertData
{
    public Sprite thumbnail;
    public byte[] bgm;
    public string concertData;
}

public static class ConcertManager
{
    static string FTP_THUMB_PATH = Encoder.Decode("dGh1bWJuYWlsLw==");
    static string FTP_BGM_PATH = Encoder.Decode("YmdtLw==");
    static string FTP_CDATA_PATH = Encoder.Decode("Y29uY2VydGRhdGEv");
    static string DB_CONCERTINFO = Encoder.Decode("Y29uY2VydGluZm8=");

    public static ConcertData GetConcertData(int concert_id)
    {
        ConcertData concertData = new ConcertData();

        string filePath = FTP_THUMB_PATH + concert_id + ".png";
        concertData.thumbnail = MediaProcessor.ToSprite(FTPManager.Download(filePath));

        filePath = FTP_BGM_PATH + concert_id + ".mp3";
        concertData.bgm = FTPManager.Download(filePath);

        filePath = FTP_CDATA_PATH + concert_id + ".cdata";
        concertData.concertData = Encoding.Default.GetString(FTPManager.Download(filePath));

        return concertData;
    }

    public static ConcertInfo GetConcert(int concert_id, bool active = true)
    {
        string activeQuery = (active) ? " AND active = 1" : "";
        string query = string.Format("SELECT * FROM " + DB_CONCERTINFO + " WHERE concert_id = '{0}'" + activeQuery + ";", concert_id);
        List<Dictionary<string, object>> result = DBManager.Select(query);

        ConcertInfo concertInfo = new ConcertInfo();

        concertInfo.concert_id  = (int)result[0]["concert_id"];
        concertInfo.id          = result[0]["id"] as string;
        concertInfo.title       = result[0]["title"] as string;
        concertInfo.genre       = result[0]["genre"] as string;

        return concertInfo;
    }

    public static List<ConcertInfo> GetConcertsWithId(string id, bool active = true)
    {
        string activeQuery = (active) ? " AND active = 1" : "";
        string query = string.Format("SELECT * FROM " + DB_CONCERTINFO + " WHERE id = '{0}'" + activeQuery + ";", id);
        List<Dictionary<string, object>> result = DBManager.Select(query);

        List<ConcertInfo> concertInfos = new List<ConcertInfo>();

        foreach (Dictionary<string, object> dict in result)
        {
            ConcertInfo concertInfo = new ConcertInfo();

            concertInfo.concert_id  = (int)dict["concert_id"];
            concertInfo.id          = dict["id"] as string;
            concertInfo.title       = dict["title"] as string;
            concertInfo.genre       = dict["genre"] as string;

            concertInfos.Add(concertInfo);
        }

        return concertInfos;
    }

    public static List<ConcertInfo> GetConcertsWithGenre(string genre, bool active = true)
    {
        string activeQuery = (active) ? " AND active = 1" : "";
        string query = string.Format("SELECT * FROM " + DB_CONCERTINFO + " WHERE genre = '{0}'" + activeQuery + ";", genre);
        List<Dictionary<string, object>> result = DBManager.Select(query);

        List<ConcertInfo> concertInfos = new List<ConcertInfo>();

        foreach (Dictionary<string, object> dict in result)
        {
            ConcertInfo concertInfo = new ConcertInfo();

            concertInfo.concert_id  = (int)dict["concert_id"];
            concertInfo.id          = dict["id"] as string;
            concertInfo.title       = dict["title"] as string;
            concertInfo.genre       = dict["genre"] as string;

            concertInfos.Add(concertInfo);
        }

        return concertInfos;
    }

    public static List<ConcertInfo> SearchConcerts(string searchQuery, bool active = true)
    {
        string activeQuery = (active) ? " AND active = 1" : "";
        string query = string.Format("SELECT * FROM " + DB_CONCERTINFO + " WHERE title LIKE '%{0}%'" + activeQuery + ";", searchQuery);
        List<Dictionary<string, object>> result = DBManager.Select(query);

        List<ConcertInfo> concertInfos = new List<ConcertInfo>();

        foreach (Dictionary<string, object> dict in result)
        {
            ConcertInfo concertInfo = new ConcertInfo();

            concertInfo.concert_id  = (int)dict["concert_id"];
            concertInfo.id          = dict["id"] as string;
            concertInfo.title       = dict["title"] as string;
            concertInfo.genre       = dict["genre"] as string;

            concertInfos.Add(concertInfo);
        }

        return concertInfos;
    }

    public static bool SetConcertState(int concert_id, bool active)
    {
        string query = string.Format("UPDATE " + DB_CONCERTINFO + " SET active = " + Convert.ToInt32(active) + " WHERE concert_id = '{0}';", concert_id);

        return DBManager.Execute(query);           
    }
}
