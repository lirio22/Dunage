using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour{

    public GameObject protectedObject;
    public ProtectFromDestruction protectFromDestruction;

    public void GiveUp()
    {
        Time.timeScale = 1;
        protectFromDestruction.DeleteObject();
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        protectFromDestruction.DeleteObject();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
