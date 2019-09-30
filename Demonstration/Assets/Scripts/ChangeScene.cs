using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public int LevelJumpIndex = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            JumpScene();
        }
    }

    public void JumpScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelJumpIndex);
    }
}
