using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : Singleton<Done_GameController>
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
        
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    public GameObject m_Boss;
    public int m_HazardsToBoss = 5;
    private int m_CurrentHazardCount = 0;

    private bool gameOver;
    private bool restart;
    private bool m_BossUp = false;
    private int score;

    //---UI ship choice
    private bool m_GameStart = false;
    public bool GameStart
    {
        set { m_GameStart = value; }
    }


    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();

    }

    private void Update()
    {
        if (m_GameStart)
        {
            if(m_CurrentHazardCount > m_HazardsToBoss)
            {
                
            }
            else
            {
                m_CurrentHazardCount++;
                Debug.Log(m_CurrentHazardCount);
                StartCoroutine(SpawnWaves());
            }
            m_GameStart = false;
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if(!m_BossUp)
            {    
                if(m_CurrentHazardCount > m_HazardsToBoss)
                {
                    GameObject Boss = Instantiate(m_Boss, m_Boss.transform.position, m_Boss.transform.rotation);
                    m_BossUp = true;
                }
                else
                {
                    for (int i = 0; i < hazardCount; i++)
                    {
                        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                        Quaternion spawnRotation = Quaternion.identity;
                        Instantiate(hazard, spawnPosition, spawnRotation);
                        m_CurrentHazardCount ++;
                        Debug.Log(m_CurrentHazardCount);

                        yield return new WaitForSeconds(spawnWait);
                    }
                }
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

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}