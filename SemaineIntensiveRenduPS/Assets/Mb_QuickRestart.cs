using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mb_QuickRestart : MonoBehaviour
{
    public static Mb_QuickRestart quickRestart;

    private void Awake()
    {
        quickRestart = this;
    }

    public void QuickRestart()
    {
        SceneManager.LoadScene(0);
    }
}
