using System.Collections;
using UnityEditor.Overlays;
using UnityEngine;
namespace Stage
{
    public class WaitForPlayerDecisionStage : IStage
    {
        private readonly GameContext context;

        public WaitForPlayerDecisionStage(GameContext context)
        {
            this.context = context;
        }
        public IEnumerator InitialStage()
        {
            context.canProceed = false;
            context.NextStepButton.onClick.AddListener(OnNextStepClicked);

            yield return null;
        }
        public IEnumerator ExecuteStage(IStageData stageData)
        {
            context.GameStatusText.text = "Waiting for player decision whether to continue the game...";
            Debug.Log(stageData.testStageData);
            yield return new WaitForSeconds(2);
        }
        public IEnumerator EndingStage(IStageData stageData)
        {
            context.GameStatusText.text = "Player decided to continue, resetting the game!";
            yield return new WaitForSeconds(2);
            stageData.testStageData++;
        }
        
        public bool IsStageCompleted()
        {
            return context.canProceed;
        }
        public void OnNextStepClicked()
        {
            context.canProceed = true;
        }
    }
}
