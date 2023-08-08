using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    #region Public Variables
    public AudioManager AudioManager;
    public EffectsManager EffectsManager;
    public UIManager UIManager;

    [Header("References")] 
    public List<LevelManager> Levels;
    public AnimationSettings ResetAnimationSettings;
    public GameObject LevelsParentObject;

    [Header("Global Variables")]
    public Circle DraggedCircle;
    public Circle OverlappingCircle;
    public LevelManager CurrentLevelData;
    #endregion

    #region Private Variables
    private int currentLevelIndex = 0;
    private int numberOfMoves = 0;
    #endregion

    #region Unity Delegates
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        UIManager.SetUIState(GameState.Playing);
        SwitchLevel(0);
    }
    #endregion

    #region Private Functions
    private void SwitchLevel(int levelIndex)
    {
        Instantiate(Levels[currentLevelIndex], LevelsParentObject.transform);
    }
    #endregion

    #region Public Functions
    public void SwapCircleWithOverlapping(Circle circle)
    {
        Socket mySocket = circle.ConnectedSocket;
        Socket newSocket = OverlappingCircle.ConnectedSocket;

        circle.ConnectToNewSocket(newSocket, null);
        OverlappingCircle.ConnectToNewSocket(mySocket, CheckLevelDoneCondition);
        
        AudioManager.PlaySwapSound();
    }
    public void CheckLevelDoneCondition()
    {
        if (CurrentLevelData.IsLevelComplete())
        {
            numberOfMoves = 0;
            UIManager.SetUIState(GameState.EndGame);
        }
        else
        {
            numberOfMoves++;
        }
        
        UIManager.SetNumberOfMoves(numberOfMoves);
    }
    public bool CanSwap(Circle circle)
    {
        if (OverlappingCircle == null)
        {
            return false;
        }
        else
        {
            bool onTheSameLine = false;

            Debug.LogWarning("Could be optimized");

            foreach (var line in circle.ConnectedSocket.linesConnectedTo)
            {
                foreach (var otherLine in OverlappingCircle.ConnectedSocket.linesConnectedTo)
                {
                    if (line == otherLine)
                        onTheSameLine = true;
                }
            }

            return onTheSameLine;
        }
    }
    public void OnNextLevelPressed()
    {
        if (currentLevelIndex == Levels.Count - 1)
        {
            currentLevelIndex = 0;
        }
        else
        {
            currentLevelIndex++;
        }

        UIManager.SetUIState(GameState.Playing);
        SwitchLevel(currentLevelIndex);
    }
    #endregion
}

public enum GameState
{
    Playing, EndGame
}