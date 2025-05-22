using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PassButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdDuration = 1f; // Время удержания кнопки (в секундах)
    private float holdTimer = 0f;   // Таймер удержания
    private bool isHolding = false; // Флаг удержания
    public GwentGame gwent;

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

    void Start()
    {
        gwent = GameObject.Find("GameField").GetComponent<GwentGame>();
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
        if (gwent.round == 1)
        {
            gwent.create_second_round();
        }
        else if (gwent.round == 2)
        {
            gwent.create_third_round();
        }
        else
        {
            gwent.end();
        }
    }

    private void ResetHold()
    {
        // Сбрасываем состояние удержания
        isHolding = false;
        holdTimer = 0f;
    }
}