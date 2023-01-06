using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public RectTransform joystick_BG;
    public RectTransform joystick_control;
    public GameObject joystick_panel;

    private bool active;

    public static Vector3 direct;

    private Vector3 mouseDown;
    private Vector3 mouseMove;
    public float magnitude;

    private Vector3 screen;

    private Vector3 MousePosition => Input.mousePosition - screen;
    public void Awake()
    {
        screen.x = Screen.width / 2;
        screen.y = Screen.height / 2;

        direct = Vector3.zero;

        active = false;
        joystick_panel.SetActive(false);
    }

    public void Update()
    {
        if (active)
        {
            mouseMove = MousePosition;

            joystick_control.
                anchoredPosition = Vector3.ClampMagnitude((mouseMove - mouseDown),magnitude) + mouseDown;

            direct = (mouseMove - mouseDown).normalized;
            direct.z = direct.y; // dieu chinh dung truc toa do 3D (z: forward)
            direct.y = 0;
        }
    }

    public void ButtonDown()
    {
        mouseDown = MousePosition;
        joystick_BG.anchoredPosition = mouseDown;
        joystick_panel.SetActive(true);
        active = true;
    }

    public void ButtonUp()
    {
        joystick_panel.SetActive(false);
        active = false;
        direct = Vector3.zero;
    }
}
