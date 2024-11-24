using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    private List<IStage> stages = new List<IStage>();
    private IStage currentStage;
    public bool GameContinue = true;
    public Action CoroUpdata;
    [SerializeField] public SharedDataSO SharedData;
    public UIComponentCollectionSO UIComponents;

    private async void Start()
    {
        InitializeStages();
        await ExecuteStagesAsync();
    }

    private async void Update()
    {
        if (currentStage != null)
        {
           await currentStage.InputAsync();
        }
    }

    private void InitializeStages()
    {
        stages.Clear();
        stages.Add(new InitialStage());
    }

    private async Task ExecuteStagesAsync()
    {
        while (GameContinue)
        {
            foreach (var stage in stages)
            {
                currentStage = stage;
                Debug.Log($"Starting stage: {currentStage.GetType().Name}");
                await currentStage.ExecuteAsync(SharedData, UIComponents);
            }

            Debug.Log("All game stages completed!");
        }
    }
}
