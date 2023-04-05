using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;

public class UiController : MonoBehaviour
{
    public TextMeshProUGUI textPoint, highScore, yourScore;
    public static UiController Instance;
    public CanvasGroup canvasGameover;
    public int highpoints = 0;
    public string scoreKey = "HighScore";


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void Start()
    {
        DOTween.Init();
        if (PlayerPrefs.HasKey(scoreKey))
        {
            int savedScore = PlayerPrefs.GetInt(scoreKey);
            if (savedScore > highpoints)
            {
                highpoints = savedScore;
                highScore.text = highpoints.ToString();
            }
        }
    }


    public void UpdatePoints(int amountPoints)
    {
        textPoint.text = "Points: " + amountPoints;
        highpoints= amountPoints;
        yourScore.text = amountPoints.ToString();
    }


    public void GameOverFeedback()
    {
        int savedScore = PlayerPrefs.GetInt(scoreKey);
        
        if (highpoints > savedScore)
        {
            PlayerPrefs.SetInt(scoreKey, highpoints);
            PlayerPrefs.Save();
            highScore.text = highpoints.ToString();
        }
        canvasGameover.interactable = true;
        canvasGameover.DOFade(1, 1f);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }


    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
