using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public string gameSceneName = "SampleScene";
    

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

  
}