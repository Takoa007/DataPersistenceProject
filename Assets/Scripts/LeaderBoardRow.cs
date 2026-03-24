using UnityEngine;
using TMPro;

public class LeaderBoardRow : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text scoreText;

    public void SetData(string n, int s)
    {
        nameText.text = n;
        scoreText.text = s.ToString();
    }
}
