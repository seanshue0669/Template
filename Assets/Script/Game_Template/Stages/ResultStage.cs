using System.Collections;
using UnityEditor.Overlays;
using UnityEngine;
namespace Stage
{
    public class DisplayResultsStage : IStage
    {
        private readonly GameContext context;

        public DisplayResultsStage(GameContext context)
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
            context.GameStatusText.text = "Displaying gambling results...";
            yield return new WaitForSeconds(2);
            context.GameStatusText.text = "Results displayed!";

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