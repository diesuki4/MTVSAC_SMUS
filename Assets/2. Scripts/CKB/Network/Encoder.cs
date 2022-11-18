using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class Encoder
{
    public static string Encode(string decoded, Encoding encoding = null)
    {
        if (encoding == null)
            encoding = Encoding.Default;

        return Convert.ToBase64String(encoding.GetBytes(decoded));
    }

    public static string Decode(string encoded, Encoding encoding = null)
    {
        if (encoding == null)
            encoding = Encoding.Default;

        return encoding.GetString(Convert.FromBase64String(encoded));
    }
}
