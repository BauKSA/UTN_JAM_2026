using UnityEngine;
using UnityEngine.SceneManagement;

public class Prueba : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Apretaste L");
            SceneManager.LoadScene("GameOver");
        }
    }
}