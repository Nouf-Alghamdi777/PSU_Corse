using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameStateText;
    [SerializeField] private TextMeshProUGUI coinsAmmountText;
    
    private const string WinMessage ="You have won the game!";
    private const string LoseMessage ="You lost the game!";
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TriggerGameState(bool isWin,int coinsAmmount)
    {
        gameStateText.text = isWin ? WinMessage : LoseMessage;
        coinsAmmountText.text = coinsAmmount.ToString();
    }
}
