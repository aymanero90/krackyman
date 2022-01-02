using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EndScreen;

    public static GameManager instance;
    void Awake()
    {
        EndScreen.SetActive(false);

        if (instance == null)
            instance = this;        
    }
  
    public void setEndScreenActive()
    {
        EndScreen.SetActive(true);
    }
    public void RestartGame()
    {
        Invoke ("StartGame", 2f);    
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
