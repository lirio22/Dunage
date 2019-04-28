using UnityEngine;

public class ProtectFromDestruction : MonoBehaviour {

    public static ProtectFromDestruction instance;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
