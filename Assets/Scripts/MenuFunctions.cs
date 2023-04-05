using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private CanvasGroup creditsPanel, menuPanel;


    public void Start()
    {
        DOTween.Init();
    }


    public void GoToMenu()
    {
        creditsPanel.interactable = false;
        creditsPanel.blocksRaycasts = false;
        creditsPanel.DOFade(0, 0.5f).OnComplete(MenuFadeIn);
    }


    public void GoToCredits()
    {
        menuPanel.interactable = false;
        menuPanel.blocksRaycasts = false;
        menuPanel.DOFade(0, 0.5f).OnComplete(CreditsFadeIn);
    }


    public void CreditsFadeIn()
    {
        creditsPanel.interactable = true;
        creditsPanel.blocksRaycasts = true;
        creditsPanel.DOFade(1, 0.5f);
    }


    public void MenuFadeIn()
    {
        menuPanel.interactable = true;
        menuPanel.blocksRaycasts = true;
        menuPanel.DOFade(1, 0.5f);
    }


    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
