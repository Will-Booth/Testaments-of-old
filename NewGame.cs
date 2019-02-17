using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void PlayGame()
    {
        //increments the active scenes build index by 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
