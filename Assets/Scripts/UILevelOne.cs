using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /*public void OnStartButtonPressed()
    {
        Invoke(nameof(LoadFirstLevel), 1.0f);
    }*/

    public void LoadFirstLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
      //  SceneManager.LoadSceneAsync(1);
        DontDestroyOnLoad(gameObject);
    }

    /*public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
