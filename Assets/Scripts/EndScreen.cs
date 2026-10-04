using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen Instance;

    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Condiciones")]
    public int resourcesNeeded = 10;        // cuántos recursos hay que juntar
    public string penguinTag = "Pinguino";  // tag de tus pingüinos

    int resources;
    int penguinsAlive;
    bool gameEnded;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void Start()
    {
        // Cuenta los pingüinos que hay al empezar
        penguinsAlive = GameObject.FindGameObjectsWithTag(penguinTag).Length;
    }

    // Llamar cada vez que se recolecta un recurso
    public void AddResource(int amount = 1)
    {
        if (gameEnded) return;
        resources += amount;
        if (resources >= resourcesNeeded)
            Win();
    }

    // Llamar cada vez que muere un pingüino
    public void PenguinDied()
    {
        if (gameEnded) return;
        penguinsAlive--;
        if (penguinsAlive <= 0)
            Lose();
    }

    public void Win()
    {
        if (gameEnded) return;
        gameEnded = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        if (gameEnded) return;
        gameEnded = true;
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}