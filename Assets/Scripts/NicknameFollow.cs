﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NicknameFollow : MonoBehaviour
{
    [SerializeField]
    Character target; //для просмотра в редакторе
    TMP_Text nickname;
    Transform targetTransform;
    Transform nicknameTransform;
    Camera camera;
    private void Awake()
    {
        nickname = GetComponent<TMP_Text>();
    }
    void Start()
    {
        camera = Camera.main; //
        nicknameTransform = transform;
        nicknameTransform.SetParent(FindObjectOfType<Canvas>().transform);
    }
    void Update()
    {
        Vector3 nicknamePosition = camera.WorldToScreenPoint(targetTransform.position + (Vector3.forward * 1.2f));
        nicknameTransform.position = nicknamePosition;
    }

    public void SetTarget(Character target)
    {
        this.target = target;
        targetTransform = target.transform;
        nickname.text = target.GetNickname();
    }
}
