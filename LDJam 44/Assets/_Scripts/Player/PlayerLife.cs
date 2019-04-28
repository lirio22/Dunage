using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            CheckHealth();
        }
    }

    private int life;
    public int MaxLife = 20;

    public TextMeshProUGUI textMesh;
    public Slider slider;

    public GameObject gameOverScreen;

    private void Awake()
    {
        Life = MaxLife;
    }

    private void CheckHealth()
    {
        textMesh.text = Life.ToString() + "/20";
        slider.value = Life;

        if(Life <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
