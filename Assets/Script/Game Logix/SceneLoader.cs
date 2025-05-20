using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadSceneMenu()
    {
   
     SceneManager.LoadScene(0);

    }
    public void LoadSceneLevel1()
    {
   
     SceneManager.LoadScene(1);

    }

    public void LoadSceneGameOver()
    {
   
     SceneManager.LoadScene(2);

    }


}
