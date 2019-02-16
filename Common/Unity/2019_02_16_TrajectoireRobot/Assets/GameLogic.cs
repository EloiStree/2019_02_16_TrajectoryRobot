using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public float m_timeStart=60;
    private float m_timeLeft;

    public Text m_score;
    public Text m_time;


    public bool m_pause = false;
    void Start()
    {
        m_timeLeft = m_timeStart;
    }

    void Update()
    {
        if (m_pause) return;
        m_timeLeft -= Time.deltaTime;
        Mathf.Clamp(m_timeLeft, 0, m_timeStart);
        m_time.text = string.Format("{0}", (int) m_timeLeft );
        GameObject[] cubes= GameObject.FindGameObjectsWithTag("GoldenCube");
        m_score.text = ""+cubes.Length;

        if (m_timeLeft < 0f) {
            m_pause = true;
            GameOver();
        }
        if (cubes.Length <= 0 && Time.timeSinceLevelLoad>1f) {

            m_pause = true;
            Win();
        }

    }
    public GameObject m_robotView;
    public GameObject m_explosion;
    public GameObject m_explosionPosition;
    public GameObject m_victory;

    private void Win()
    {

        if(m_victory)
        m_victory.SetActive(true);
        RestartLater();
    }

    private void GameOver()
    {
        m_robotView.gameObject.SetActive(false);
        GameObject.Instantiate(m_explosion, m_explosionPosition.transform.position, m_explosionPosition.transform.rotation);
        RestartLater();
    }

    public float timeToRestart = 3;
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RestartLater()
    {
        Invoke("Restart", timeToRestart);
    }
}
