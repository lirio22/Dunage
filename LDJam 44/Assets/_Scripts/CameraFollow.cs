using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Camera mainCamera;
    private GameObject target;
    
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10.0f), new Vector3(target.transform.position.x, target.transform.position.y, -10.0f), 1.0f);
    }
}
