using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
        UpdateScore();

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;

        gameOverText.SetActive(true);
        restartButton.SetActive(true);

        Time.timeScale = 0f;
    }

    // GỌI TỪ BUTTON
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
