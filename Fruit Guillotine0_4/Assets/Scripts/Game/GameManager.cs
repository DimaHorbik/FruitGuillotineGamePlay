﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    [SerializeField] GameObject gullotine;
    public Text scoreText;
    public Text scoreTextDead;

    private int lastScoredHash;

    enum PageState
    {
        None,
        Start,
        Countdown,
        GameOver
    }

    int score = 0;
    bool gameOver = true;

    public bool GameOver { get { return gameOver; } }

    void Awake()
    {
       
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
          
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
       
        TapController.OnPlayerDied += OnPlayerDied;
        Damage.OnPlayerDied += OnPlayerDied;
        FruitKill.OnScoreApple += OnAppleScored;
        FruitKill.OnScoreAubergine += OnAubergineScored;
        FruitKill.OnScoreBanana += OnBananaScored;
        FruitKill.OnScoreCoconut += OnCoconutScored;
        FruitKill.OnScoreMango += OnMangoScored;
        FruitKill.OnScoreMelon += OnMelonScored;
        FruitKill.OnScoreOrange += OnOrangeScored;
        FruitKill.OnScorePineapple += OnPineappleScored;
        FruitKill.OnScoreTomato += OnTomatoScored;
        FruitKill.OnScoreWatermelon += OnWatermelonScored;
        FruitKill.OnScoreWatermelonDamage += OnWatermelonDamageScored;
        FruitKill.OnScoreDamage += OnDamageScored;
        CountdownText.OnCountFinished += OnCountdownFinished;
    }

    void OnDisable()
    {
        TapController.OnPlayerDied -= OnPlayerDied;
        Damage.OnPlayerDied -= OnPlayerDied;
        FruitKill.OnScoreApple -= OnAppleScored;
        FruitKill.OnScoreAubergine -= OnAubergineScored;
        FruitKill.OnScoreBanana -= OnBananaScored;
        FruitKill.OnScoreCoconut -= OnCoconutScored;
        FruitKill.OnScoreMango -= OnMangoScored;
        FruitKill.OnScoreMelon -= OnMelonScored;
        FruitKill.OnScoreOrange -= OnOrangeScored;
        FruitKill.OnScorePineapple -= OnPineappleScored;
        FruitKill.OnScoreTomato -= OnTomatoScored;
        FruitKill.OnScoreWatermelon -= OnWatermelonScored;
        FruitKill.OnScoreWatermelonDamage -= OnWatermelonDamageScored;
        FruitKill.OnScoreDamage -= OnDamageScored;
        CountdownText.OnCountFinished -= OnCountdownFinished;
    }

    void OnCountdownFinished()
    {
        SetPageState(PageState.None);
        OnGameStarted();
        score = 0;
        gameOver = false;
    }

    void OnAppleScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score +8;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnAubergineScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 6;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnBananaScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 5;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnCoconutScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 15;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnMangoScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 10;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnMelonScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 5;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnOrangeScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 6;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnPineappleScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 12;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnTomatoScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 5;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnWatermelonScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 3;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
        void OnWatermelonDamageScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 1;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    void OnDamageScored(int hash)
    {
        if (hash != lastScoredHash)
        {
            score = score + 2;
            scoreText.text = score.ToString();
            lastScoredHash = hash;
            scoreTextDead.text = $"Score: {score}";
        }
    }
    public void OnPlayerDied()
    {
        gameOver = true;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (score > savedScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        SetPageState(PageState.GameOver);
    }

    void SetPageState(PageState state)
    {
       
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                gullotine.SetActive(true);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                break;
            case PageState.GameOver:
                gullotine.SetActive(false);
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);                
                break;
        }
    }

    public void ConfirmGameOver()
    {
        
        SetPageState(PageState.Start);
        scoreText.text = "0";
        OnGameOverConfirmed();
    }

    public void StartGame()
    {
        SetPageState(PageState.Countdown);
       
    }

}