using UnityEngine;
using UnityEngine.UI;

public class DamageTextController : MonoBehaviour
{
    public GameObject canvas; // ������ Canvas
    public Text damageTextPrefab; // ������ ���������� �������

    public void ShowDamageText(int damage, Vector3 targetPosition)
    {
        Text damageTextObject = Instantiate(damageTextPrefab, canvas.transform); // ������� ��������� ������
        damageTextObject.transform.position = Camera.main.WorldToScreenPoint(targetPosition); // ������������� ������� ���������� �������
        damageTextObject.text = damage.ToString(); // ������������� ����� � ������
    }
}
