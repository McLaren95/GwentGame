using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PassButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdDuration = 1f; // ����� ��������� ������ (� ��������)
    private float holdTimer = 0f;   // ������ ���������
    private bool isHolding = false; // ���� ���������
    public GwentGame gwent;

    public void OnPointerDown(PointerEventData eventData)
    {
        // �������� ������ ������� ��� �������
        isHolding = true;
        Debug.Log("������ ������!");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ���������� ������ ��� ���������� ������
        isHolding = false;
        holdTimer = 0f;
        Debug.Log("������ ��������!");
    }

    void Start()
    {
        gwent = GameObject.Find("GameField").GetComponent<GwentGame>();
    }

    void Update()
    {
        // ��������� ������ ����
        if (isHolding)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdDuration)
            {
                Debug.Log("����� �������� ����� ������!");
                PassTurn();
                ResetHold();
            }
        }

        // ��������� �������
        if (Input.GetKey(KeyCode.Space))
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdDuration)
            {
                Debug.Log("����� �������� ����� ������!");
                PassTurn();
                ResetHold();
            }
        }
        else if (!isHolding) // ���� �� ������ ����, �� ������ �� ������������
        {
            holdTimer = 0f; // ����� �������
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
        // ���������� ��������� ���������
        isHolding = false;
        holdTimer = 0f;
    }
}