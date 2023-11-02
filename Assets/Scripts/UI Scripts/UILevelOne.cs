using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadFirstLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
