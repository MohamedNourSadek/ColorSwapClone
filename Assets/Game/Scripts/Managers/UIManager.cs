using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
    public static UIManager Instance;

    #region Public Variables
    public GameObject GameplayUI;
    public GameObject EndGameUI;
    public TextMeshProUGUI NumberOfMovesText;
    #endregion

    #region Unity Delegates
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Public Variables
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

            EffectsManager.Instance.PlayCelebrationEffect();
            AudioManager.Instance.PlayCeleberationSound();
        }

        foreach (var levelOjbect in GameManager.Instance.LevelsParentObject.GetComponentsInChildren<Level>())
        {
            Destroy(levelOjbect.gameObject);
        }
    }
    #endregion
}
