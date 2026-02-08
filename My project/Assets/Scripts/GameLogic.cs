using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject winTextObject;
    [SerializeField] private TextMeshProUGUI P2TextScore;
    [SerializeField] private TextMeshProUGUI P1TextScore;
    [SerializeField] private TextMeshProUGUI matchPointText;
    [SerializeField] private BallLogic ballLogic;
    [SerializeField] private PowerUpLogic powerUpLogic;
    private static int p1Score;
    private static int p2Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        winTextObject.SetActive(false);
        matchPointText.gameObject.SetActive(false);
    }

    public void PlayerScored(string playerGoal)
    {
        powerUpLogic.ResetPowerUpStatus();
        
        
        if (playerGoal.Equals("Player1Goal"))
        {
            p1Score++;
            if (p1Score == 10 || p2Score == 10)
            {
                matchPointText.gameObject.SetActive(true);
            }
            P1TextScore.text = "P1: " + p1Score;
            winTextObject.SetActive(checkIfWin(p1Score));
            ballLogic.Launch("Player2Goal", checkIfWin(p1Score));
            if(checkIfWin(p1Score)) winTextObject.GetComponent<TextMeshProUGUI>().text = "Player1 WINS!";

            
            
            
            
        }else if (playerGoal.Equals("Player2Goal"))
        {
            p2Score++;
            if (p1Score == 10 || p2Score == 10)
            {
                matchPointText.gameObject.SetActive(true);
            }
            P2TextScore.text = "P2: " + p2Score;
            winTextObject.SetActive(checkIfWin(p2Score));
            ballLogic.Launch("Player1Goal", checkIfWin(p2Score));
            if(checkIfWin(p1Score)) winTextObject.GetComponent<TextMeshProUGUI>().text = "Player2 WINS!";
            
        }
    }

    private bool checkIfWin(int currentScore)
    {
        if (currentScore >= 11) return true;
        return false;
    }
}
