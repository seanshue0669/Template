using System.Collections;
using UnityEngine;
namespace Stage
{
    public class ProcessPayoutStage : IStage
    {
        private readonly GameContext context;

        public ProcessPayoutStage(GameContext context)
        {
            this.context = context;
        }
        public IEnumerator InitialStage()
        {
            context.canProceed = false;
            yield return null;
        }

        public IEnumerator ExecuteStage(IStageData stageData)
        {
            context.GameStatusText.text = "Calculating payout and processing player's balance...";
            yield return new WaitForSeconds(2);
            context.GameStatusText.text = "Payout processed!";

            Debug.Log(stageData.testStageData);

            yield return new WaitForSeconds(2);
        }
        public IEnumerator EndingStage(IStageData stageData)
        {
            stageData.testStageData++;
            yield return null;
        }
        public bool IsStageCompleted()
        {
            return true;
        }
    }
}

