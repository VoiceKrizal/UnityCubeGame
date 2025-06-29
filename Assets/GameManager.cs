using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public PlayerMovement PlayerMovement;
    public float RestDelay = 1f;

    public void EndGame()
    {
        //PlayerMovement = null;
        PlayerMovement.enabled = false;

        Invoke("RestartLevel", RestDelay);
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
