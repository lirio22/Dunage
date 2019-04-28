using TMPro;
using UnityEngine;

public class EndingText : MonoBehaviour {

    public TextMeshProUGUI textMesh;
    public AgeCurrency age;

    private void OnEnable()
    {
        textMesh.text = "You escaped the dungeon! Now you are " + age.CurrentAge + " years old.";
    }
}
