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
        // UI ����� RectTransform ������Ʈ�� �����ɴϴ�.
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        // ���콺 Ŭ�� �̺�Ʈ�� �߻��� ��ġ�� UI ����� �θ� ��ü�� ��ǥ��� ��ȯ�մϴ�.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 localMousePosition);
        savePos = rectTransform.localPosition;
        // UI ����� ��ġ�� ���콺 Ŭ�� �̺�Ʈ�� �߻��� ��ġ ������ ���̸� ���մϴ�.
        clickOffset = (Vector2)rectTransform.localPosition - localMousePosition;
        canvasGroup.blocksRaycasts = false;
        gameObject.transform.parent = gameObject.transform.parent.parent.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        // ���콺 �巡�� �̺�Ʈ�� �߻��� ��ġ�� UI ����� �θ� ��ü�� ��ǥ��� ��ȯ�մϴ�.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 localMousePosition);
        //Transform[] hierarchy = GetComponentsInParent<Transform>();
        //foreach (Transform t in hierarchy)
        //{
        //    t.SetAsLastSibling();
        //}

        // UI ����� ��ġ�� ���콺 �巡�� �̺�Ʈ�� �߻��� ��ġ�� �̵��մϴ�.
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
            if(hit.gameObject.tag.Equals("Box"))//����ĳ��Ʈ�ǰ���� ������Ʈ�� �±� �˻�
            {
                transform.parent = hit.gameObject.transform;
            }
        }
        rectTransform.localPosition = savePos;
    }
}