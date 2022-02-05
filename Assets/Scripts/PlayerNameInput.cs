using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField]TMP_InputField nameInputField;
    [SerializeField] Button continueButton;

    public static string DisplayName { get; private set; }
    const string PlayerPrefsNameKey = "PlayerName";

    void Start() => SetUpInputField();

    void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }
        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);
        nameInputField.text = defaultName;
        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;
        PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
    }
}
