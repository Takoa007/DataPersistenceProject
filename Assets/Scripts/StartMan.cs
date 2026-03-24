using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMan : MonoBehaviour
{
    public TMP_InputField nameInput; // Drag your InputField here in Inspector
    //public TMP_Text bestScoreText;   // Drag your High Score text here*/

    public GameObject rowPrefab; // Drag your ScoreRow Prefab here
    public Transform container;  // Drag your Vertical Layout Group here

    
    void Start()
    {
        if (AllManager.Instance != null)
        {
            PopulateLeaderboard();
        }
        // When the menu opens, show the best score from the manager
        //bestScoreText.text = "Best Score: " + AllManager.Instance.bestScore;//

        // Optional: If the player already entered a name earlier, show it again
        if (!string.IsNullOrEmpty(AllManager.Instance.currentPlayerName))
        {
            nameInput.text = AllManager.Instance.currentPlayerName;
        }

 
    }

    public void StartGame()
    {
         // 1. Capture the name from the UI and save it to our "Permanent" Manager
         string playerName = nameInput.text;

         // 2. If the user left it blank, give them a default name
         if (string.IsNullOrWhiteSpace(playerName)) 
         {
             playerName = "Player 1";
         }

         AllManager.Instance.currentPlayerName = playerName;
    } 

    public void PopulateLeaderboard()
    {
        // 2. Clear out any "Design" rows you left in the editor
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // 3. Loop through the List in AllManager
        foreach (ScoreEntry entry in AllManager.Instance.leaderboard)
        {
            // 4. Create the Row and set its data
            GameObject newRow = Instantiate(rowPrefab, container);

            // Assuming your Prefab has a simple script called "LeaderboardRow"
            newRow.GetComponent<LeaderBoardRow>().SetData(entry.name, entry.score);
        }
    }

}
