using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Public Variables
    public LevelData levelData;
    #endregion

    #region Unity Delegates
    private void Awake()
    {
        GameManager.Instance.currentLevelData = this;
    }
    #endregion

    #region Public Functions
    public bool IsLevelComplete()
    {
        bool levelIsDone = true;

        foreach (Line line in levelData.lines)
        {
            if (line.LineSockets[0].connectedCircle.CircleColor == line.LineSockets[1].connectedCircle.CircleColor)
            {
                levelIsDone = false;
            }
        }

        return levelIsDone;
    }
    #endregion
}


[System.Serializable]
public class LevelData
{
    public List<Line> lines;
    public List<Socket> sockets;
    public List<Circle> circles;
}
