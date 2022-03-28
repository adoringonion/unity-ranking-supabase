using TMPro;
using UnityEngine;

public class UserScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ranking;
    [SerializeField] private TextMeshProUGUI userName;

    [SerializeField] private TextMeshProUGUI scoreValue;


    public void SetScore(int ranking, string userName, int score)
    {
        this.ranking.text = ranking.ToString();
        this.userName.text = userName;
        scoreValue.text = score.ToString();
    }
}