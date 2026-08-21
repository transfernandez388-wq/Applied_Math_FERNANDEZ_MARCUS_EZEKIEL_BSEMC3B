using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class UIManager : MonoBehaviour
{
    [Header("Animation settings")]
    public Ease easeType;
    public float duration;
    public RectTransform gameoverRect;

    public TextMeshProUGUI gameOverLabel;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI highScoreLabel;
    public TextMeshProUGUI healthLabel;
    public TextMeshProUGUI endScoreLabel;
    public TextMeshProUGUI enemySlainLabel;


    public Button restartBtn;



    private void Start()
    {
        restartBtn.onClick.AddListener(GameManager.Instance.RestartGame);
        ShowHighScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Press 'B' to show game over screen");
            ShowGameOverUI();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Press 'X' to delete the saved highscore");
            SaveManager.Instance.DeleteHighScore();
            ShowHighScore();
        }

        SetHealthLabel();
    }

    public void SetHealthLabel()
    {
        healthLabel.text = $"{GameManager.Instance.health}";
    }
    public void AddScore()
    {
        GameManager.Instance.score = GameManager.Instance.killedEnemyCount * 10;
        scoreLabel.text = $"{GameManager.Instance.score}";
        SetHigheScore();
    }

    public void SetHigheScore()
    {
        if(GameManager.Instance.score > GameManager.Instance.highScore)
        {
            GameManager.Instance.highScore = GameManager.Instance.score;
            SaveManager.Instance.SaveHighScore();
            ShowHighScore();
        }
    }
   
    public void ShowHighScore()
    {
        highScoreLabel.text = $"{SaveManager.Instance.ShowSavedHighScore()}";
    }


    public void ShowGameOverUI(bool isGameOver = true)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameoverRect.DOScale(Vector3.one,duration).SetEase(easeType));
        gameOverLabel.text = isGameOver ? "GAME OVER" : "GAME WON";


    }

    public void ShowEndScore()
    {
        enemySlainLabel.text = $"{enemySlainLabel.text}{GameManager.Instance.killedEnemyCount}";
        endScoreLabel.text = $"{endScoreLabel.text}{SaveManager.Instance.ShowSavedHighScore()}";
    }

    public void HideGameOverUI()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameoverRect.DOScale(Vector3.zero, duration).SetEase(easeType));
    }
}
