using System.Collections;
using TMPro;
using UnityEngine;

namespace Stage
{
    public class PlaceBetStage : IStage
    {
        private readonly GameContext        context;
        //>! Declare some temporary variable here

        string userInput;

        public PlaceBetStage(GameContext context)
        {
            this.context = context;         
        }

        public IEnumerator InitialStage()
        {
            //Set something that u think is needed to be initialize
            context.canProceed = false;
            context.NextStepButton.onClick.AddListener(OnNextStepClicked);
            //>!Adding the diolog or hint in this function
            InitialStageDiolog();

            //Return in two ways bellow
            yield return null;
            //yield return new WaitForSeconds(1);
        }
        public IEnumerator ExecuteStage(IStageData stageData)
        {

            yield return new WaitUntil(() => context.canProceed);
            //>!Run some shit stuff here
            context.GameStatusText.text = "Bet completed, waiting for gambling result...";
            yield return new WaitForSeconds(1);
            //>!Get the stageData if u need
            Debug.Log(stageData.testStageData);

        }
        public IEnumerator EndingStage(IStageData stageData)
        {
            //>!Adding the diolog or hint in this function
            EndingStageDiolog();

            //>!Set the stageData if u need
            stageData.testStageData++;

            //Return in two ways bellow
            //yield return new WaitUntil(null);
            yield return new WaitForSeconds(1);

            //>!If u subscrib,remeber to unsubscribe to button click event!!
            context.NextStepButton.onClick.RemoveListener(OnNextStepClicked);
        }
        public void EndingStageDiolog()
        {
            context.GameStatusText.text = "You wagered $" + userInput;
        }
        public void InitialStageDiolog()
        {
            context.GameStatusText.text = "Start Betting,Enter the wagered:";
        }
        public bool IsStageCompleted()
        {
            // If the context.canProceed equals to true,the stage will switch
            // Dont put Any logic arithmetic here!
            return context.canProceed;
        }
        public void OnNextStepClicked()
        {
            userInput = context.InputField.text;
            bool isBetValid = int.TryParse(userInput, out int betAmount) && betAmount > 0;

            if (isBetValid)
            {
                context.GameStatusText.text = "Bet amount is valid. Proceeding to the next step...";
                context.canProceed = true;
            }
            else
            {
                context.GameStatusText.text = "Invalid bet amount, please enter again!";
            }
        }

        #region egStuff(u can delete it)
        bool Case1()
        {
            return true;
        }
        bool Case2()
        {
            return true;
        }
        bool Case3()
        {
            return true;
        }
        #endregion
    }
}
