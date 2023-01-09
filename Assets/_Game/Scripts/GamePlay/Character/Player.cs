using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask obstacleLayer;

    private bool isMoving;
    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        base.OnInit();
        isMoving = false;
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(JoystickControl.direct != Vector3.zero)
            {
                Moving();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopMoVing();
        }
    }
    private void Moving()
    {
        isMoving = true;
        rb.MovePosition(rb.position + JoystickControl.direct * speed * Time.deltaTime);
        tf.position = rb.position;
        tf.forward = JoystickControl.direct;
        ChangeAnim(Constant.ANIM_RUN);
    }
    private void StopMoVing()
    {
        isMoving = false;
        JoystickControl.direct = Vector3.zero;
        rb.velocity = Vector3.zero;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constant.TAG_OBSTACLE))
        {
            StopMoVing();
        }
    }
}