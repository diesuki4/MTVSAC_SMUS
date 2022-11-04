using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MediaProcessor
{
    // private Texture2D Base64ToTexture2D(byte[] imageData)
    // {
    //     int width, height;
    //     GetImageSize(imageData, out width, out height);

    //     // 매프레임 new를 해줄경우 메모리 문제 발생 -> 멤버 변수로 변경
    //     Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);

    //     texture.hideFlags = HideFlags.HideAndDontSave;
    //     texture.filterMode = FilterMode.Point;
    //     texture.LoadImage(imageData);
    //     texture.Apply();

    //     return texture;
    // }

    static int GetWidth(byte[] imageBytes)
    {
        return ReadInt(imageBytes, 3 + 15);
    }

    static int GetHeight(byte[] imageBytes)
    {
        return ReadInt(imageBytes, 3 + 15 + 2 + 2);
    }

    static int ReadInt(byte[] imageBytes, int offset)
    {
        return (imageBytes[offset] << 8 | imageBytes[offset + 1]);
    }
}
