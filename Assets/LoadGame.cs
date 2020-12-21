using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel", 5f);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
