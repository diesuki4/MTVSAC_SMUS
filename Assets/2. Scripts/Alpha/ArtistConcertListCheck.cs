using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtistConcertListCheck : MonoBehaviour
{
    public GameObject mainConcert;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Created") == 1)
        {
            mainConcert.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
