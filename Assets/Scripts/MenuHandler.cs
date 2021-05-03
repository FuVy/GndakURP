using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nicknameField;
    DataKeeper dataKeeper;
    private void Awake()
    {
        dataKeeper = FindObjectOfType<DataKeeper>();
    }
    public void PlayButton()
    {
        //dataKeeper.SetPlayerNickname(nicknameField.text);
        PlayerPrefs.SetString("nickname", nicknameField.text);
    }
}
