using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public static class FTPManager
{
    const string SERVER = "www5.dynu.net";
    const string PORT = "47028";
    const string id = "smbuser";
    const string passwd = "iyashinanda12#$";
    const string connDest = "ftp://" + SERVER + ":" + PORT + "/webdav/";

    public static bool Upload(byte[] bytes, string fileName)
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(connDest + fileName);

        ftpWebRequest.Credentials = new NetworkCredential(id, passwd);
        ftpWebRequest.UseBinary = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

        Stream ftpStream = ftpWebRequest.GetRequestStream();

        ftpStream.Write(bytes, 0, bytes.Length);
        ftpStream.Flush();
        ftpStream.Close();

        FtpWebResponse response = (FtpWebResponse)ftpWebRequest.GetResponse();

        return response.StatusCode == FtpStatusCode.ClosingControl;
    }

    public static byte[] Download(string fileName)
    {
        FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(connDest + fileName);

        ftpWebRequest.Credentials = new NetworkCredential(id, passwd);
        ftpWebRequest.UseBinary = false;
        ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;

        Stream ftpStream = ftpWebRequest.GetResponse().GetResponseStream();
        MemoryStream memoryStream = new MemoryStream();

        ftpStream.CopyTo(memoryStream);
        ftpStream.Close();

        return memoryStream.ToArray();
    }
}
