using UnityEngine;
using UnityEngine.UI;

public class DamageTextController : MonoBehaviour
{
    public GameObject canvas; // объект Canvas
    public Text damageTextPrefab; // префаб текстового объекта

    public void ShowDamageText(int damage, Vector3 targetPosition)
    {
        Text damageTextObject = Instantiate(damageTextPrefab, canvas.transform); // создаем текстовый объект
        damageTextObject.transform.position = Camera.main.WorldToScreenPoint(targetPosition); // устанавливаем позицию текстового объекта
        damageTextObject.text = damage.ToString(); // устанавливаем текст с уроном
    }
}
