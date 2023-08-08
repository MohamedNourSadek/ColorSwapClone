using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]   
public class UIManager
{
    public GameObject GameplayUI;
    public GameObject EndGameUI;
    public TextMeshProUGUI NumberOfMovesText;

    public void SetNumberOfMoves(int numberOfMoves)
    {
        NumberOfMovesText.text = numberOfMoves.ToString();
    }
    public void SetUIState(GameState state)
    {
        AnimationSettings animationSettings = GameManager.Instance.ResetAnimationSettings;

        if (state == GameState.Playing)
        {
            GameplayUI.LeanScaleY(1, animationSettings.animationTime)
                .setEase(animationSettings.moveAnimation);

            EndGameUI.LeanScaleY(0, animationSettings.animationTime / 2)
                .setEase(animationSettings.moveAnimation);
        }
        else if (state == GameState.EndGame)
        {
            GameplayUI.LeanScaleY(0, animationSettings.animationTime)
                .setEase(animationSettings.moveAnimation);

            EndGameUI.LeanScaleY(1, animationSettings.animationTime / 2)
                .setEase(animationSettings.moveAnimation);

            GameManager.Instance.EffectsManager.PlayCelebrationEffect();
            GameManager.Instance.AudioManager.PlayCeleberationSound();
        }

        foreach (var levelOjbect in GameManager.Instance.LevelsParentObject.GetComponentsInChildren<LevelManager>())
        {
            MonoBehaviour.Destroy(levelOjbect.gameObject);
        }
    }
}
