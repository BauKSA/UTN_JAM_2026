using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public void jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
