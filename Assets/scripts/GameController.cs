using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject crate;
    public Vector2 spawnValues;
    public int crateCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;

    public Text point, timer;
    public Text restartText, gameOverText;
    public static float timeLeft = 10f;

    public bool gameOver, restart;

    Player player;

    private void Start()
    {
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        StartCoroutine(SpawnCrates());

        player = GetComponent<Player>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "Time Left: " + Mathf.Round(timeLeft);

        if (timeLeft < 0)
        {
            timeLeft = 0;
            GameOver();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
#pragma warning disable CS0618 // Type or member is obsolete
                Application.LoadLevel(Application.loadedLevel);
#pragma warning restore CS0618 // Type or member is obsolete
                Start();
            }
        }
    }

    IEnumerator SpawnCrates()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        { for (int i = 0; i < crateCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y));
                Quaternion spawnRotation = new Quaternion();
                Instantiate(crate, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
        
    }

    public void AddScore()
    {
        score += 10;
        UpdateScore();
    }

    void UpdateScore()
    {
        point.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
