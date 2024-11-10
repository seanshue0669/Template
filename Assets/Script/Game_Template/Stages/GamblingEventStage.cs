using System.Collections;
using UnityEngine;
namespace Stage
{
    public class RunGamblingEventStage : IStage
    {
        private readonly GameContext context;
        public RunGamblingEventStage(GameContext context)
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
            context.GameStatusText.text = "Starting gambling event...";
            yield return new WaitForSeconds(2);
            //do something
            context.GameStatusText.text = "Gambling event completed!";
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
