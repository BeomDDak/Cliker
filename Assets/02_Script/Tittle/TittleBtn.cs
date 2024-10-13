using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TittleBtn : MonoBehaviour
{
    // Background에 스크립트 달아놨음
    public void StartScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void exit()
    {
        Debug.Log("게임종료");
    }
}
