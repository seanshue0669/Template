using UnityEngine;
using TMPro;

public class UIflowing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text AnimationTargetText;
    [SerializeField]
    private TMP_Text AnimationTargetText_1;
    [SerializeField]
    private TMP_Text AnimationTargetText_2;
    [SerializeField]
    private float Amplitude = 0.1f;
    [SerializeField]
    private float Speed = 0.5f;
    [SerializeField]
    private float RandomSault = 0.1f;
    private float RandomAmp = 10.0f;

    private Vector3[] positionArray = new Vector3[3];
    private TMP_Text[] AnimationText = new TMP_Text[3];
    private float[] randomSault = new float[3];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AnimationText[0] = AnimationTargetText;
        AnimationText[1] = AnimationTargetText_1;
        AnimationText[2] = AnimationTargetText_2;

        for (int i = 0; i < AnimationText.Length; i++)
        {
            Vector3 randPos = new Vector3(0.0f, Random.Range(-RandomSault, RandomSault), 0.0f);
            positionArray[i] = AnimationText[i].rectTransform.position;
            randomSault[i] = Random.Range(0, RandomAmp * RandomSault);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < AnimationText.Length; i++)
        {
            Vector3 deltaPosition = new Vector3(0f, Mathf.PingPong(Time.time * Speed, Amplitude* randomSault[i]), 0f);
            AnimationText[i].rectTransform.position = positionArray[i] + deltaPosition;
        }
    }
}
