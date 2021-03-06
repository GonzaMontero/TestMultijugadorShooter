using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] float mouseSensitivity, sprintspeed, walkspeed, jumpforce, smoothTime;
    [SerializeField] Rigidbody rb;

    [SerializeField] Item[] items;

    int itemIndex;
    int previousItemIndex;

    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelovity;
    Vector3 moveAmount;
    PhotonView PV;

    private void Awake()
    {
        MenuManager.Instance.CloseMenu("Room");
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();

        Cursor.lockState = (CursorLockMode.Confined);
        Cursor.visible = false;
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            EquipItem(0);
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
    }

    private void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        Look();
        Move();
        Jump();

        for(int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString())){
                EquipItem(i);
                break;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintspeed : walkspeed), ref smoothMoveVelovity, smoothTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpforce);
        }
    }

    void EquipItem(int _index)
    {
        itemIndex = _index;

        items[itemIndex].itemGameObject.SetActive(true);

        if (previousItemIndex != 1)
        {
            items[previousItemIndex].gameObject.SetActive(false);
        }

        previousItemIndex = itemIndex;
    }

    private void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    private void FixedUpdate()
    {
        if (!PV.IsMine)
        {
            return;
        }
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
