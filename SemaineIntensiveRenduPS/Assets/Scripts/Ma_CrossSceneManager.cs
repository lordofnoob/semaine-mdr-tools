using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ma_CrossSceneManager : MonoBehaviour
{
    public static Ma_CrossSceneManager instance;

    public string sceneToLoad;
    public string sceneToUnload;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Update()
    {
        
      //  if (in)
    }
}
