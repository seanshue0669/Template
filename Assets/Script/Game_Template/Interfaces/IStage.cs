using System.Collections;
public interface IStage
{
    IEnumerator InitialStage();
    IEnumerator ExecuteStage(IStageData stageData);
    IEnumerator EndingStage (IStageData stageData);
    bool IsStageCompleted();
}

