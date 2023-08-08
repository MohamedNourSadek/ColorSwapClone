using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    #region Public Variables
    public CircleColor CircleColor;
    public Socket ConnectedSocket;
    #endregion

    #region Private Variables
    private Vector3 TouchLocation;
    private bool isDragging;
    #endregion


    #region Unity Delegates
    private void Update()
    {
        UpdateInput();
    }
    private void FixedUpdate()
    {
        HandleCircleDragging();
    }
    #endregion


    #region Private Functions
    private void HandleCircleDragging()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(TouchLocation);
        }
    }
    private void HandleOnDragUp()
    {
        if (GameManager.Instance.CanSwap(this) == false)
        {
            ResetCircleToSocket();
        }
        else
        {
            GameManager.Instance.SwapCircleWithOverlapping(this);
        }
    }

    private void ResetCircleToSocket()
    {
        this.transform.position = ConnectedSocket.location;
    }
    private void UpdateInput()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        TouchLocation = Input.mousePosition;
#else
        TouchLocation = Input.GetTouch(0).position;
#endif
        TouchLocation.z = 1;
    }
    #endregion

    #region Public Functions
    public void ConnectToNewSocket(Socket newSocket)
    {
        ConnectedSocket = newSocket;
        ConnectedSocket.connectedCircle = this;
        this.transform.position = newSocket.location;
    }
    #endregion

    #region Callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;

        //Should be done safer
        GameManager.Instance.DraggedCircle = this;
        GameManager.Instance.OverlappingCircle = null;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        
        //Should be done safer
        GameManager.Instance.DraggedCircle = null;
        HandleOnDragUp();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Should be done safer
        GameManager.Instance.OverlappingCircle = this;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Should be done safer
        if (GameManager.Instance.OverlappingCircle == this)
            GameManager.Instance.OverlappingCircle = null;
    }
    #endregion
}


public enum CircleColor
{
    Red, Green, Purple
}
