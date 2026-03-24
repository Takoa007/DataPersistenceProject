using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ScoreEntry
{
    public string name;
    public int score;

    public ScoreEntry(string n, int s)
    {
        name = n;
        score = s;
    }
}

public class AllManager : MonoBehaviour
{
    // Static instance allows other scripts to access this easily: MainMan.Instance
    public static AllManager Instance { get; private set; }

    
    [Header("Current Session Data")]
    public string currentPlayerName;
    public int currentScore;

    [Header("Permanent Data")]
    public List<ScoreEntry> leaderboard = new List<ScoreEntry>();

    private void Awake()
    {
        // Singleton Logic: If an instance already exists, destroy this one.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Load the best score from the hard drive immediately on startup
        // bestScore = PlayerPrefs.GetInt("HighScore", 0);
        LoadLeaderboard();
    }

    /*public void SaveNewHighScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("HighScore", bestScore);
            PlayerPrefs.Save(); // Forces the save to the disk
        }
    }*/

    public void AddScoreToBoard(string name, int score)
    {
        // 1. Add the new entry
        leaderboard.Add(new ScoreEntry(name, score));

        // 2. Sort by score (Highest first)
        leaderboard = leaderboard.OrderByDescending(s => s.score).ToList();

        // 3. Keep only the top 10
        if (leaderboard.Count > 10)
        {
            leaderboard.RemoveRange(10, leaderboard.Count - 10);
        }

        SaveLeaderboard();
    }

    public void SaveLeaderboard()
    {
        // Convert the whole list into a single string
        string json = JsonUtility.ToJson(new SerializationWrapper { list = leaderboard });
        PlayerPrefs.SetString("LeaderboardData", json);
    }

     public void LoadLeaderboard()
    {
        string json = PlayerPrefs.GetString("LeaderboardData", "");
        if (!string.IsNullOrEmpty(json))
        {
            var wrapper = JsonUtility.FromJson<SerializationWrapper>(json);
            leaderboard = wrapper.list;
        }
    }

    // Small helper class needed for JsonUtility to work with Lists
    [System.Serializable]
    public class SerializationWrapper { public List<ScoreEntry> list; }
}
