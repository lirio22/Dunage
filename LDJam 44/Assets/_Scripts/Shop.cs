using UnityEngine;

public class Shop : MonoBehaviour {

    public AgeCurrency currency;
    public PlayerLife life;

    public GameObject shopHUD;

    private bool isIn;

    private void Start()
    {
        life = GameObject.FindGameObjectWithTag("PlayerThings").GetComponent<PlayerLife>();
        currency = GameObject.FindGameObjectWithTag("BaseScripts").GetComponent<AgeCurrency>();
    }

    private void Update()
    {
        if(isIn)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Time.timeScale = 0;
                shopHUD.SetActive(true);
            }
        }
    }

    public void BuyHealth()
    {
        if(life.Life < life.MaxLife)
        {
            currency.SpendAge(life.MaxLife - life.Life);
            life.Life = life.MaxLife;
            shopHUD.SetActive(false);
        }
        else
        {
            //Mostra mensagem de que não precisa de cura
            Debug.Log("Está todo curado já");
            shopHUD.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void GiveUp()
    {
        Time.timeScale = 1;
        shopHUD.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerThings")
        {
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "PlayerThings")
        {
            isIn = false;
        }
    }
}
