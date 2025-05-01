using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PassButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdDuration = 1f; // Время удержания кнопки (в секундах)
    private float holdTimer = 0f;   // Таймер удержания
    private bool isHolding = false; // Флаг удержания

    public void OnPointerDown(PointerEventData eventData)
    {
        // Начинаем отсчет времени при нажатии
        isHolding = true;
        Debug.Log("Кнопка нажата!");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбрасываем таймер при отпускании кнопки
        isHolding = false;
        holdTimer = 0f;
        Debug.Log("Кнопка отпущена!");
    }

    void Update()
    {
        // Удержание кнопки мыши
        if (isHolding)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdDuration)
            {
                Debug.Log("Игрок спасовал через кнопку!");
                PassTurn();
                ResetHold();
            }
        }

        // Удержание пробела
        if (Input.GetKey(KeyCode.Space))
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdDuration)
            {
                Debug.Log("Игрок спасовал через пробел!");
                PassTurn();
                ResetHold();
            }
        }
        else if (!isHolding) // Если ни кнопка мыши, ни пробел не удерживаются
        {
            holdTimer = 0f; // Сброс таймера
        }
    }

    private void PassTurn()
    {
        // Логика пасования (например, передача хода противнику)
    }

    private void ResetHold()
    {
        // Сбрасываем состояние удержания
        isHolding = false;
        holdTimer = 0f;
    }
}