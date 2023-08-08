using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Circle))]
public class CircleButton : Button
{
    private Circle myCircle;

    #region Unity Delegates
    protected override void Awake()
    {
        base.Awake();
        myCircle = GetComponent<Circle>();
    }
    #endregion


    #region Unity Delegates
    #endregion

    #region Callbacks
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        targetGraphic.raycastTarget = false;
        myCircle.OnPointerDown(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        targetGraphic.raycastTarget = true;

        myCircle.OnPointerUp(eventData);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        myCircle.OnPointerEnter(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        myCircle.OnPointerExit(eventData);
    }

    #endregion
}


[System.Serializable]
public class AnimationSettings
{
    public LeanTweenType moveAnimation = LeanTweenType.easeSpring;
    public float animationTime = 0.5f;
}