using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PhoneController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image backgroudImage;
    private Image joystickImage;

    public Vector3 inputVector;
    
    void Start()
    {
       backgroudImage= GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        inputVector = Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroudImage.rectTransform, ped.position, ped.enterEventCamera, out pos))
        {
            pos.x = (pos.x / backgroudImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backgroudImage.rectTransform.sizeDelta.y);

            float x = (backgroudImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2-1;
            float y = (backgroudImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2-1;

            inputVector = new Vector3(x, 0, y);
            inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;         //Otherwise would go out of bounds when x =1 and y =1 since not normalised they become 1.33

            joystickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (backgroudImage.rectTransform.sizeDelta.x / 3), inputVector.z * (backgroudImage.rectTransform.sizeDelta.y / 3));
        }
        print("OnDrag");
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        //Reset Joystick Position when releasing the joystick
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);            //So that the joystick would move without needing to drag it
    }
    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (inputVector.z != 0)
        {
            return inputVector.z;
        }
        return Input.GetAxis("Vertical");
    }

}
