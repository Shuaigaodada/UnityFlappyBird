using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    // UI object
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Bird bird;
	public Spawner spawner;

	public static GameManager instance
    {
        get {
            if(_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance; 
        }
    }
    private static GameManager _instance;

	private void Awake()
	{
		Application.targetFrameRate = 144;

        Pause();
	}

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();
		bird.enabled = true;
		gameOver.SetActive(false);
		playButton.SetActive(false);
        spawner.UpdateDifficulty(1, -0.5f, 0.5f);

        Time.timeScale = 1.0f;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        bird.enabled = false;
    }

	public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
    public void IncreaseScore() {
        score++;
		scoreText.text = score.ToString();
		if (score % 10 == 0) // ÿ�������ﵽ10�ı���ʱ�����Ѷ�
		{
			float newSpawnRate = Mathf.Lerp(1f, 1.5f, score / 100f); // ������������
			float newMinHeight = Mathf.Lerp(-0.5f, -3f, score / 100f); // �𽥽�����С�߶�
			float newMaxHeight = Mathf.Lerp(0.5f, 4f, score / 100f); // ��������߶�

			spawner.UpdateDifficulty(newSpawnRate, newMinHeight, newMaxHeight);
		}
	}
}
