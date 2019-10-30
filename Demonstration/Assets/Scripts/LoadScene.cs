using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int loadindex = 0;
    public void LoadS()
    {
        SceneManager.LoadScene(loadindex);
    }
}
