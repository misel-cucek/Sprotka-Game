using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float spawnInterval = 2f; // interval at which to spawn enemies
    public float spawnDistance = 10f; // maximum distance from player to spawn enemies
    public int numEnemies = 5; // number of enemies to spawn


    public int score;
    public int lives = 3; // the player's remaining lives

    public int numCoins = 0; // the number of coins the player has collected
    public bool isGameOver = false; // whether the game is over or not
    public bool isFinished = false; // whether the game has been finished or not
    public bool isGameCompleted = false; // whether the game has been completed or not

    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        lives = 3;
        numCoins = 0;
        isGameOver = false;
        isFinished = false;
        isGameCompleted = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGameOver)
        {
            // Restart game if player presses R
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
    }

    public void CoinCollected()
    {
        numCoins++;
        score += 100;
    }

    public void LifeLost()
    {
        // TODO call _movmentManager for lives
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        // add any additional game over logic here, such as showing a game over screen or resetting the game
        Debug.Log("Game Over! Final Score: " + score);
        SceneManager.LoadScene("EndScreen");
    }

    public void Finish()
    {
        isFinished = true;
        // add any additional finish logic here, such as showing a finish screen or stopping gameplay
        if (numCoins == 10)
        {
            GameCompleted();
        }
    }

    public void GameCompleted()
    {
        isGameCompleted = true;
        // add any additional game completed logic here, such as showing a game completed screen or transitioning to a new level
        Debug.Log("Game Finished! Final Score: " + score);
        SceneManager.LoadScene("EndScreen");
    }

    public void Restart()
    {
        // reset game state
        score = 0;
        lives = 3;
        numCoins = 0;
        isGameOver = false;
        isFinished = false;
        isGameCompleted = false;

        // reload current scene
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}