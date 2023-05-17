using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MousePoint : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 clickOffset;
    private Vector3 savePos;

    private void Start()
    {
        // UI 요소의 RectTransform 컴포넌트를 가져옵니다.
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        // 마우스 클릭 이벤트가 발생한 위치를 UI 요소의 부모 객체의 좌표계로 변환합니다.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 localMousePosition);
        savePos = rectTransform.localPosition;
        // UI 요소의 위치와 마우스 클릭 이벤트가 발생한 위치 사이의 차이를 구합니다.
        clickOffset = (Vector2)rectTransform.localPosition - localMousePosition;
        canvasGroup.blocksRaycasts = false;
        gameObject.transform.parent = gameObject.transform.parent.parent.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        // 마우스 드래그 이벤트가 발생한 위치를 UI 요소의 부모 객체의 좌표계로 변환합니다.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 localMousePosition);
        //Transform[] hierarchy = GetComponentsInParent<Transform>();
        //foreach (Transform t in hierarchy)
        //{
        //    t.SetAsLastSibling();
        //}

        // UI 요소의 위치를 마우스 드래그 이벤트가 발생한 위치로 이동합니다.
        rectTransform.localPosition = localMousePosition + clickOffset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        canvasGroup.blocksRaycasts = true;

        foreach (RaycastResult hit in results)
        {
            if(hit.gameObject.tag.Equals("Box"))//레이캐스트의검출된 오브젝트의 태그 검사
            {
                transform.parent = hit.gameObject.transform;
            }
        }
        rectTransform.localPosition = savePos;
    }
}