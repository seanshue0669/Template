using UnityEngine;
using System.Collections;

public class SequentialStepsExample : MonoBehaviour
{
    void Start()
    {
        // �ҰʥD��{�ӫ����ǰ���B�J
        StartCoroutine(RunStepsInOrder());
    }

    // �D��{�G�̧ǰ���U�ӨB�J
    IEnumerator RunStepsInOrder()
    {
        yield return StartCoroutine(DownloadFile());

        yield return StartCoroutine(ProcessData());

        yield return StartCoroutine(DisplayResult());

        Debug.Log("�Ҧ��B�J�����I");
    }

    IEnumerator DownloadFile()
    {
        Debug.Log("�}�l�U�����...");
        yield return new WaitForSeconds(5f);
        Debug.Log("���U�������I");
    }

    IEnumerator ProcessData()
    {
        Debug.Log("�}�l�B�z�ƾ�...");
        yield return new WaitForSeconds(3f);
        Debug.Log("�ƾڳB�z�����I");
    }

    IEnumerator DisplayResult()
    {
        Debug.Log("�}�l��ܵ��G...");
        yield return new WaitUntil(AccpectData);
        Debug.Log("���G��ܧ����I");
    }
    bool AccpectData()
    {
        return (Input.GetKeyDown(KeyCode.Space));
    }
}
