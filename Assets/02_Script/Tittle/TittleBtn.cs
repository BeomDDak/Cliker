using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TittleBtn : MonoBehaviour
{
    // Background�� ��ũ��Ʈ �޾Ƴ���
    public void StartScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void exit()
    {
        Debug.Log("��������");
    }
}
