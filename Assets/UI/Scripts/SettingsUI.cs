using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Button MouseControlButton;
    [SerializeField]
    private Button KeyboardMouseContorlButton;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() //playersettings 플레이어 데이터 파일.. Onenable 즉, 활성화될 때 마다
    {
        switch (PlayerSettings.controlType) //가져와서 switch문으로 비교 후 설정값으로 변경
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseContorlButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseContorlButton.image.color = Color.green;
                break;
        }
    }

    public void SetControlMode(int controlType) //버튼을 누를 때 마다 위에랑 전혀 다름 같아보이지만 이건 사용자가 누를때 마다 반응 button연결
    {
        PlayerSettings.controlType = (EControlType)controlType;
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseContorlButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseContorlButton.image.color = Color.green;
                break;
        }
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("Close");
    }

}
