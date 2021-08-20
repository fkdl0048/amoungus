﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private InputField nicknameInputField;
    [SerializeField]
    private GameObject createRoomUI;

    public void OnClickCreateRoomButton()
    {
        if (nicknameInputField.text != "")
        {
            PlayerSettings.nickname = nicknameInputField.text;
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            //nicknameInputField.GetComponent<Animator>().SetTrigger("on"); 원본
            StartCoroutine("nicknameAni");
        }
    }

    private IEnumerator nicknameAni()
    {
        nicknameInputField.GetComponent<Animator>().SetTrigger("on");
        yield return new WaitForSeconds(0.1f);
        nicknameInputField.GetComponent<Animator>().ResetTrigger("on");
    }
}
