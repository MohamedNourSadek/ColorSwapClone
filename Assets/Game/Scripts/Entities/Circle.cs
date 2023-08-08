using System;
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
    private Vector3 touchLocation;
    private bool isDragging;
    private CircleButton myButton;
    #endregion

    #region Unity Delegates

    private void Awake()
    {
        myButton = GetComponent<CircleButton>();
    }
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
            transform.position = Camera.main.ScreenToWorldPoint(touchLocation);
        }
    }
    private void HandleOnDragUp()
    {
        if (GameManager.Instance.CanSwap(this) == false)
        {
            ResetCircleToSocket(null);
        }
        else
        {
            GameManager.Instance.SwapCircleWithOverlapping(this);
        }
    }
    private void ResetCircleToSocket(Action onComplete)
    {
        LTDescr moveAnimator = this.gameObject.
            LeanMove(ConnectedSocket.location, GameManager.Instance.ResetAnimationSettings.animationTime)
            .setEase(GameManager.Instance.ResetAnimationSettings.moveAnimation);

        if(onComplete != null)
            moveAnimator.setOnComplete(onComplete);
    }
    private void UpdateInput()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        touchLocation = Input.mousePosition;
#else
        touchLocation = Input.GetTouch(0).position;
#endif
        touchLocation.z = 1;
    }
    #endregion

    #region Public Functions
    public void ConnectToNewSocket(Socket newSocket, Action onComplete)
    {
        ConnectedSocket = newSocket;
        ConnectedSocket.connectedCircle = this;

        ResetCircleToSocket(onComplete);
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
