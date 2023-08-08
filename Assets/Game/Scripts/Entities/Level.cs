using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Public Variables
    public LevelData LevelData;
    #endregion

    #region Unity Delegates
    private void Awake()
    {
        GameManager.Instance.CurrentLevelData = this;
    }
    #endregion

    #region Public Functions
    public bool IsLevelComplete()
    {
        bool levelIsDone = true;

        foreach (Line line in LevelData.lines)
        {
            if (line.LineSockets[0].ConnectedCircle.CircleColor == line.LineSockets[1].ConnectedCircle.CircleColor)
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
