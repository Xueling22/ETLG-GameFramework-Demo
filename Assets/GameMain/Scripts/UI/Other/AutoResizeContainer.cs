using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoResizeContainer : MonoBehaviour
{
    public RectTransform container;
    public TextMeshProUGUI text;

    private void Start()
    {
        // �ڿ�ʼʱ�����ı����ȵ��������߶�
        ResizeContainer();
    }

    private void ResizeContainer()
    {
        // ��ȡ�ı����ݵĳ���
        float textHeight = text.preferredHeight;

        // ���������߶�Ϊ�ı����ݵĳ���
        container.sizeDelta = new Vector2(container.sizeDelta.x, textHeight);
    }
}
