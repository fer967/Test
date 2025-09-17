using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int enemiesKilled = 0;
    [SerializeField] private TextMeshProUGUI killCounterText;
    [Header("Level Progression")][SerializeField] private int killsToNextLevel = 4; // 👈 cantidad de enemigos a eliminar
    [SerializeField] private string nextSceneName = "Nivel2"; // 👈 nombre exacto de la próxima escena
    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this; DontDestroyOnLoad(gameObject); // opcional si querés que persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddKill()
    {
        enemiesKilled++;
        UpdateUI();
        if (enemiesKilled >= killsToNextLevel)
        {
            LoadNextLevel();
        }
    }

    private void UpdateUI()
    {
        if (killCounterText != null) killCounterText.text = "Kills: " + enemiesKilled;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}