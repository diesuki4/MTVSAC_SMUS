using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public static class FTPManager
{
    static string SERVER = Encoder.Decode("d3d3NS5keW51Lm5ldA==");
    static string PORT = Encoder.Decode("NDcwMjg=");
    static string id = Encoder.Decode("c21idXNlcg==");
    static string passwd = Encoder.Decode("aXlhc2hpbmFuZGExMiMk");
    static string connDest = "ftp://" + SERVER + ":" + PORT + "/";
    static NetworkCredential credential = new NetworkCredential(id, passwd);

    public static bool Upload(byte[] bytes, string filePath)
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(connDest + filePath);

        ftpWebRequest.Credentials = credential;
        ftpWebRequest.UseBinary = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

        Stream ftpStream = ftpWebRequest.GetRequestStream();

        ftpStream.Write(bytes, 0, bytes.Length);
        ftpStream.Flush();
        ftpStream.Close();

        FtpWebResponse response = (FtpWebResponse)ftpWebRequest.GetResponse();

        return response.StatusCode == FtpStatusCode.ClosingControl;
    }

    public static byte[] Download(string filePath)
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(connDest + filePath);

        ftpWebRequest.Credentials = credential;
        ftpWebRequest.UseBinary = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;

        Stream ftpStream = ftpWebRequest.GetResponse().GetResponseStream();
        MemoryStream memoryStream = new MemoryStream();

        ftpStream.CopyTo(memoryStream);
        ftpStream.Close();

        return memoryStream.ToArray();
    }
}
