using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardcount;
    public float spawnWait;
    public float startWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private int score;
    private bool gameOver;
    private bool restart;

    void Start() {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardcount; i++)
            {
                //          Value x,y & z depends on level design   Random.Range give a random number between two float vaules
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                //          Quaternions are used to represent rotations
                Quaternion spawnRotation = Quaternion.identity;

                //          Instantiate->  Clones the object original and returns the clone.
                Instantiate(hazard, spawnPostion, spawnRotation);

                //          This is to wait before astroiod spawns
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(Random.Range(2,4));

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreVaule) {
        score += newScoreVaule;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score = " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "GAme OVer";
        gameOver = true;
    }
}
