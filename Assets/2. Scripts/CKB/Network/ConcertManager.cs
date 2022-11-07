using System.Collections;
using System.Collections.Generic;

public static class ConcertManager
{
    public static byte[] GetThumbnail(string concert_id)
    {
        string filePath = "thumbnail/" + concert_id + ".png";

        return FTPManager.Download(filePath);
    }
}
