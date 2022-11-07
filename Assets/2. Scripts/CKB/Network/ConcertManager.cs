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
    public Texture2D thumbnail;
    public byte[] bgm;
    public string concertData;
}

public static class ConcertManager
{
    public static ConcertData GetConcertData(string concert_id)
    {
        ConcertData concertData = new ConcertData();

        string filePath = "thumbnail/" + concert_id + ".png";
        concertData.thumbnail = MediaProcessor.ToTexture2D(FTPManager.Download(filePath));

        filePath = "bgm/" + concert_id + ".mp3";
        concertData.bgm = FTPManager.Download(filePath);

        filePath = "concertdata/" + concert_id + ".cdata";
        concertData.concertData = Encoding.Default.GetString(FTPManager.Download(filePath));

        return concertData;
    }

    public static ConcertInfo GetConcert(string concert_id)
    {
        string query = string.Format("SELECT * FROM concertinfo WHERE concert_id = '{0}';", concert_id);
        List<Dictionary<string, object>> result = DBManager.Select(query);

        ConcertInfo concertInfo = new ConcertInfo();

        concertInfo.concert_id  = (int)result[0]["concert_id"];
        concertInfo.id          = result[0]["id"] as string;
        concertInfo.title       = result[0]["title"] as string;
        concertInfo.genre       = result[0]["genre"] as string;

        return concertInfo;
    }

    public static List<ConcertInfo> GetConcertsWithId(string id)
    {
        string query = string.Format("SELECT * FROM concertinfo WHERE id = '{0}';", id);
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

    public static List<ConcertInfo> GetConcertsWithGenre(string genre)
    {
        string query = string.Format("SELECT * FROM concertinfo WHERE genre = '{0}';", genre);
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

    public static List<ConcertInfo> SearchConcerts(string searchQuery)
    {
        string query = string.Format("SELECT * FROM concertinfo WHERE title LIKE '%{0}%';", searchQuery);
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
}
