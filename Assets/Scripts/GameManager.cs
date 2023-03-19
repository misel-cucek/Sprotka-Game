using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab; // reference to the enemy prefab
    public float spawnInterval = 2f; // interval at which to spawn enemies
    public float spawnDistance = 10f; // maximum distance from player to spawn enemies
    public int numEnemies = 5; // number of enemies to spawn


    public int score;
    public int lives = 3; // the player's remaining lives
    public int numCoins; // the number of coins the player has collected
    public bool isGameOver; // whether the game is over or not
    public bool isFinished; // whether the game has been finished or not

    public GameObject playerPrefab;
    private MovementManager _movementManager;
    private GameObject _player;
    private Transform _playerTransform; // reference to the player's transform

    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        lives = 3;
        numCoins = 0;
        isGameOver = false;
        isFinished = false;

        _playerTransform = FindObjectOfType<MovementManager>().transform;

        for (int i = 0; i < numEnemies; i++)
        {
            // Choose a random position within the game area to spawn the enemy
            float randomX = Random.Range(-spawnDistance, spawnDistance);
            float randomZ = Random.Range(-spawnDistance, spawnDistance);
            Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ) + _playerTransform.position;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        _player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        _movementManager = _player.GetComponent<MovementManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        _movementManager.Move(direction);
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
    }

    public void Finish()
    {
        isFinished = true;
        // add any additional finish logic here, such as showing a finish screen or stopping gameplay
    }

    public void GameCompleted()
    {
        // add any additional game completed logic here, such as showing a game completed screen or transitioning to a new level
    }

    public void Restart()
    {
        // reset game state
        score = 0;
        lives = 3;
        numCoins = 0;
        isGameOver = false;
        isFinished = false;

        // reload current scene
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}