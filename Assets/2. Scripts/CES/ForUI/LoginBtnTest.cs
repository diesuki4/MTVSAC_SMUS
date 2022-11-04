using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginBtnTest : MonoBehaviour
{
    Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GameObject.Find("VerDropdown").GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginLoadScene()
    {
        if (dropdown.value == 0)
        {
            SceneManager.LoadScene("ScrollScene");
        }
        else if (dropdown.value == 1)
        {
            SceneManager.LoadScene("ArtistConcertListScene_C");
        }
    }
}
