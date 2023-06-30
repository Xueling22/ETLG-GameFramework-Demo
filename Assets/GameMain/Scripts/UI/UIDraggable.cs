using UnityEngine;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 pointerOffset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // ���������λ����UIλ�õ�ƫ����
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // ��������ƶ�����UI��λ��
            rectTransform.anchoredPosition = eventData.position - pointerOffset;
        }
    }
}
