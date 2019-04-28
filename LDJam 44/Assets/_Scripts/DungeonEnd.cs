using UnityEngine.SceneManagement;
using UnityEngine;

public class DungeonEnd : MonoBehaviour {

    public PlayerMovement player;
    public DungeonGoal goal;
    public GameObject ending;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        goal = GameObject.FindGameObjectWithTag("BaseScripts").GetComponent<DungeonGoal>();
        ending = GameObject.FindGameObjectWithTag("Ending");
        ending = ending.transform.GetChild(0).gameObject;
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerThings")
        {
            goal.DungeonsDone++;
            if (goal.DungeonsDone == goal.Goal)
            {
                Time.timeScale = 0;
                ending.SetActive(true);
            }
            else
            {
                player.transform.position = Vector3.zero;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
