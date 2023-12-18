using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text  timerText;
    public Text finalScoreText;
    public GameObject gameOverUI; // Reference to the GameOver UI GameObject
    [SerializeField] private float timeRemaining = 60f;
    
    public BallDetector ballDetector;

    void Start()
    {
        gameOverUI.SetActive(false);
        // Invoke the UpdateTimer method every second, starting after 1 second
        InvokeRepeating("UpdateTimer", 1f, 1f);

    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            // Update the time remaining
            timeRemaining--;

            // Convert seconds to minutes and seconds
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);

            // Update the TextMeshPro text
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Time.timeScale = 0f;
            // Timer reached zero, activate the GameOver UI
            Debug.Log("Game Over!");
            gameOverUI.SetActive(true);
            finalScoreText.text = ballDetector.score.ToString();


            // Stop the timer when it reaches zero
            CancelInvoke("UpdateTimer");
        }
    }

    public void RestarLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void GameQuit()
    {
        
        Application.Quit();
    }
}