using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using Unity.VisualScripting;

public class DiceGameListener : MonoBehaviour
{
    private bool isWaiting = false;
    private void Start()
    {
        EventSystem.Instance.RegisterCallBack<string, string>("DiceGame", "Options", ProcessDiceGameEvent);

    }

    private async void Update()
    {
        if (isWaiting) 
            return; 
        isWaiting = true;

        var tcs = EventSystem.Instance.WaitForCallBack("DiceGame", "Options");
        Debug.Log("Wait Task");

        await tcs;
        Debug.Log(tcs.Result);
        isWaiting = false;
    }

    private IEnumerator Testing()
    {
        var tcs= EventSystem.Instance.WaitForCallBack("DiceGame", "Options");
        yield return new WaitUntil(() => tcs.IsCompleted);
        Debug.Log(tcs.Result);
        yield return null;
    }

    private async Task<string> ProcessDiceGameEvent(string data)
    {
        await Task.Delay(100);
        return data;
    }

}
