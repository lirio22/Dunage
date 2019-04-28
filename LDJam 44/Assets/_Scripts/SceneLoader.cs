using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	public void CallScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
