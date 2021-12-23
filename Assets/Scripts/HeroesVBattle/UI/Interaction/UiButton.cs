using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Interaction
{
  [RequireComponent(typeof(Button))]
  public class UiButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
  {
    private const float DoubleClickTime = 0.3f;
    
    public UnityEvent OnClick;
    public UnityEvent OnDoubleClick;

    private bool _clickedOnce = false;
    private float _doubleClickTime = 0f;
    
    private Button _button;

    protected virtual void Awake() => 
      _button = GetComponent<Button>();

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      switch (eventData.button)
      {
        case PointerEventData.InputButton.Left:
          LeftClick();
          break;
        case PointerEventData.InputButton.Right:
          break;
      }      
      
    }

    private void LeftClick()
    {
      if(_button.interactable)
        StartCoroutine(WaitForSecondClick());
    }

    private IEnumerator WaitForSecondClick()
    {
      OnClick?.Invoke();
      if (_clickedOnce == false && _doubleClickTime < DoubleClickTime)
      {
        _clickedOnce = true;
      }
      else
      {
        _clickedOnce = false;
        yield break;
      }
      
      yield return new WaitForEndOfFrame();
      
      while (_doubleClickTime < DoubleClickTime)
      {
        if (_clickedOnce == false)
        {
          OnDoubleClick?.Invoke();
          yield break;
        }
        
        _doubleClickTime += Time.deltaTime;
        yield return null;
      }

      _doubleClickTime = 0f;
      _clickedOnce = false;
    }
  }
}