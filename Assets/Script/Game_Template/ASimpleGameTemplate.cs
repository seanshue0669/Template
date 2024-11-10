using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.Overlays;

public class ASimpleGameTemplate : MonoBehaviour
{
    private GameContext context             = new GameContext();
    private IStageData  stageData           = new StageData  ();
    private Func<bool>  currentStepCondition;
    private IStage[]    stages;

    [SerializeField] private TMP_InputField inputField    ;
    [SerializeField] private TMP_Text       gameStatusText;
    [SerializeField] private Button         nextStepButton;

    void Start()
    {
        // Initialize GameContext with references from the Inspector
        context.InputField      = inputField;
        context.GameStatusText  = gameStatusText;
        context.NextStepButton  = nextStepButton;

        // Initialize each stage with the shared GameContext
        stages = new IStage[]
        {
            new Stage.RunGamblingEventStage        (context),
            new Stage.PlaceBetStage                (context),
            new Stage.CustomStage                  (context),
            new Stage.DisplayResultsStage          (context),
            new Stage.ProcessPayoutStage           (context),
            new Stage.WaitForPlayerDecisionStage   (context)
            // Add or remove stage if u needed 
        };

        //here is the entry of loop
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        while(true)
        {
            // StageData is to pass data to each stage
            stageData = new StageData();
            foreach (var stage in stages)
            {
                currentStepCondition = () => stage.IsStageCompleted();
                yield return stage.InitialStage ();          //Adding the diolog or hint here
                yield return stage.ExecuteStage (stageData); //Run some shit stuff here
                yield return new WaitUntil(
                    () => currentStepCondition());           
                yield return stage.EndingStage  (stageData); //Settlement someData for next stage OR show some diolog or hint here
            }
        }
    }

    //In most case,u should only adding the Stage to stages array(dont touch other code :D)
    /* ----------------------------------------------------------------------
    If u need more stageData member for each stage,follow the few step
        1.Go to IStageData->Add some shit
        2.Go to IStageData->Add {get; set;} & constructor
        3.Done
    ----------------------------------------------------------------------*/
}
