using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MediaProcessor
{
    public static Texture2D ToTexture2D(byte[] imageBytes)
    {
        int width = GetWidth(imageBytes);
        int height = GetHeight(imageBytes);

        Texture2D texture = new Texture2D(GetWidth(imageBytes), GetHeight(imageBytes), TextureFormat.ARGB32, false, true);

        texture.hideFlags = HideFlags.HideAndDontSave;
        texture.filterMode = FilterMode.Bilinear;
        texture.LoadImage(imageBytes);
        texture.Apply();

        return texture;
    }

    public static Sprite ToSprite(byte[] imageBytes)
    {
        int width = GetWidth(imageBytes);
        int height = GetHeight(imageBytes);
        
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(imageBytes);
        texture.Apply();

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(width, height));
    }   

    static int GetWidth(byte[] imageBytes)
    {
        return ReadInt(imageBytes, 3 + 15);
    }

    static int GetHeight(byte[] imageBytes)
    {
        return ReadInt(imageBytes, 3 + 15 + 2 + 2);
    }

    static int ReadInt(byte[] bytes, int offset)
    {
        return (bytes[offset] << 8 | bytes[offset + 1]);
    }
}
