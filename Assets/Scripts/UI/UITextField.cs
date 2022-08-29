using UnityEngine;
using TMPro;

public class UITextField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string userPrefsKey;
    private int userPrefsValue;

    void Start()
    {
        userPrefsValue = PlayerPrefs.GetInt(userPrefsKey);
        text.text = userPrefsValue.ToString();
    }
}
