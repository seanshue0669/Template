
using System.Collections;
using UnityEngine;
namespace Stage
{
    public class CustomStage : IStage
    {
        private readonly GameContext context;

        public CustomStage(GameContext context)
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
            context.GameStatusText.text = "Testing custom stage";
            yield return new WaitForSeconds(5);

        }
        public IEnumerator EndingStage(IStageData stageData)
        {
            yield return null;
        }
        public bool IsStageCompleted()
        {
            return true;
        }
    }
}