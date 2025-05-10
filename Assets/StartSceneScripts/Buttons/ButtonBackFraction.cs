using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBackFraction : MonoBehaviour
{
    [SerializeField] private CreateFractions create_fractions;
    public Button button;

    public void OnButtonClick()
    {
        if (create_fractions != null)
        {
            create_fractions.backFraction();
        }
    }

    void Start()
    {
        GameObject obj_fractions = GameObject.Find("CreateFractions");
        create_fractions = obj_fractions.GetComponent<CreateFractions>();
        button.onClick.AddListener(OnButtonClick);
    }

}
