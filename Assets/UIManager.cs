using UnityEngine;
using TMPro;  

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  
    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}