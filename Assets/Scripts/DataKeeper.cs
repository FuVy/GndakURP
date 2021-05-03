using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{
    [SerializeField] //только для просмотра в редакторе
    private string nickname = "Player";
    private void Awake()
    {
        DataKeeper[] objects = FindObjectsOfType<DataKeeper>();
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetPlayerNickname(string nickname)
    {
        this.nickname = nickname;
    }
    public string GetPlayerNickname()
    {
        return nickname;
    }
}
