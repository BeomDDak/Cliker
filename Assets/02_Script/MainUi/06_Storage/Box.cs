using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Box : MonoBehaviour
{
    [Header("Open")]
    public Button boxOpenBtn;  // �ڽ� ������ ��ư
    public GameObject boxHead;  // �ڽ� �Ѳ�
    public GameObject inBox;

    [Header("Close")]
    public Button boxCloseBtn;
    // Start is called before the first frame update
    void Start()
    {
        boxOpenBtn.onClick.AddListener(OpenBox);
        boxCloseBtn.onClick.AddListener(CloseBox);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OpenAnimBox()
    {
        boxHead.transform.Rotate(-30, 0, 0);
        yield return new WaitForSeconds(0.2f);
        inBox.SetActive(true);
    }

    IEnumerator CloseAnimBox()
    {
        inBox.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        boxHead.transform.Rotate(30, 0, 0);
    }

    void OpenBox()
    {
        StartCoroutine(OpenAnimBox());
    }

    void CloseBox()
    {
        StartCoroutine (CloseAnimBox());
    }
}
