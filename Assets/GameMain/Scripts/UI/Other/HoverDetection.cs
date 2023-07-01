using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���������ʱ�Ĵ����߼�
        Debug.Log("Mouse entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ����뿪���ʱ�Ĵ����߼�
        Debug.Log("Mouse exited");
    }
}
