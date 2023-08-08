using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    #region Public Variables
    public List<Line> linesConnectedTo;
    public Circle connectedCircle;
    public Vector3 location;
    #endregion


    private void Awake()
    {
        location = connectedCircle.transform.position;
    }
}
