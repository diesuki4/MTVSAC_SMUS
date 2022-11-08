using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveTrue(GameObject go)
    {
        go.SetActive(true);
    }

    public void SetActiveFalse(GameObject go)
    {
        go.SetActive(false);
    }

    public void MovingScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
