using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public float rotationSpeed = 10f; // ��ת�ٶ�

    private void Update()
    {
        // ��ÿһ֡�����У��� Y ����ת
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
