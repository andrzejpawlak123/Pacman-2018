using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static Vector2 joypadPos;
    public Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position,ped.pressEventCamera,out joypadPos))
        {
            joypadPos.x = (joypadPos.x / bgImg.rectTransform.sizeDelta.x);
            joypadPos.y = (joypadPos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(joypadPos.x * 2 + 1, 0, joypadPos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //joy move
            joystickImg.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
                , inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
            Debug.Log(joypadPos);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        joypadPos = Vector2.zero;
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }

}
