using UnityEngine;
using System.Collections;

public class SequentialStepsExample : MonoBehaviour
{
    void Start()
    {
        // 啟動主協程來按順序執行步驟
        StartCoroutine(RunStepsInOrder());
    }

    // 主協程：依序執行各個步驟
    IEnumerator RunStepsInOrder()
    {
        yield return StartCoroutine(DownloadFile());

        yield return StartCoroutine(ProcessData());

        yield return StartCoroutine(DisplayResult());

        Debug.Log("所有步驟完成！");
    }

    IEnumerator DownloadFile()
    {
        Debug.Log("開始下載文件...");
        yield return new WaitForSeconds(5f);
        Debug.Log("文件下載完成！");
    }

    IEnumerator ProcessData()
    {
        Debug.Log("開始處理數據...");
        yield return new WaitForSeconds(3f);
        Debug.Log("數據處理完成！");
    }

    IEnumerator DisplayResult()
    {
        Debug.Log("開始顯示結果...");
        yield return new WaitUntil(AccpectData);
        Debug.Log("結果顯示完成！");
    }
    bool AccpectData()
    {
        return (Input.GetKeyDown(KeyCode.Space));
    }
}
