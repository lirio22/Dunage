using TMPro;
using UnityEngine;

public class AgeCurrency : MonoBehaviour {

    //Gets player speed
    public PlayerMovement playerMovement;
    public GameObject gameOver;

    public TextMeshProUGUI textMesh;
    public int CurrentAge = 25;

    public SpriteRenderer playerSprite;
    public Sprite[] ageSprite;

    public void SpendAge(int ageToSpend)
    {
        CurrentAge += ageToSpend;
        textMesh.text = "Age: " + CurrentAge.ToString();
        CheckAge();
    }

    private void CheckAge()
    {
        if(CurrentAge > 40 && CurrentAge < 60)
        {
            playerMovement.Speed = 4;
            playerSprite.sprite = ageSprite[1];
        }else if (CurrentAge > 59 && CurrentAge < 80)
        {
            playerMovement.Speed = 3;
            playerSprite.sprite = ageSprite[2];
        }else if (CurrentAge > 79 && CurrentAge < 100)
        {
            playerMovement.Speed = 2;
            playerSprite.sprite = ageSprite[3];
        }else if(CurrentAge >= 100)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

    }
}
