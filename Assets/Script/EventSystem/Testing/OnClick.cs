using UnityEngine;

public class OnClick : MonoBehaviour
{
    [SerializeField]
    public string identifyer; 
    public string words; 

    private async void OnMouseDown()
    {
        await EventSystem.Instance.TriggerCallBack<string, string>("DiceGame", identifyer, words);
    }
}
