using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", GameManager.Instance.highScore);
        PlayerPrefs.Save();
    }
    public int ShowSavedHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.Save();
    }
}
