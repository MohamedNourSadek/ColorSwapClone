using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    #region Public Variables
    public List<Line> LinesConnectedTo;
    public Circle ConnectedCircle;
    public Vector3 Location;
    #endregion


    private void Awake()
    {
        Location = ConnectedCircle.transform.position;
    }
}
