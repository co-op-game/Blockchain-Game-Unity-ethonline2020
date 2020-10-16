using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
public class PlayerController : NetworkBehaviour
{
    public MeshRenderer[] meshrendere;
    public CharacterController cControl;
    
    private Vector3 moveDirection;

    public float gravity = 9.8f;
    public float walkForce = 4f;
    public float sprintForce = 8f;
    public bool isSprinting;
    public float stoppingForceGround;

    [Header("Camera")]
    public bool invertCamera = true;
    public bool disableCursor = true;
    public Transform camTrans;
    public float verticalLookSpeed = 0.1f;
    public float horizontalLookSpeed = 0.1f;

    public Transform shoulder;
    
    [Header("Bullets")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletLimit = 30;
    public float bulletLifetime = 5f;
    private List<GameObject> bullets;

    public override void OnStartAuthority()
    {
        for (int i = 0; i < meshrendere.Length; i++)
        {
            meshrendere[i].material.color = Color.blue;
        }
    }

    void Start()
    {
        SetCursorActive(!disableCursor);
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasAuthority) return;
        
        MouseMovement();

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        isSprinting = Input.GetKey(KeyCode.LeftShift);
        
        
    }

    void FixedUpdate()
    {
        if (!hasAuthority) return;

        Vector3 appliedForce = Vector3.zero;
        
        //Camera & player rotation
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
            
        Vector3 moveForce = Vector3.zero;

        //Move input direction
        if (inputDirection.magnitude >= 0.1f)
        {
            //float targetAngle = Mathf.Atan2(faceDirection.x, faceDirection.z) * Mathf.Rad2Deg + camTrans.eulerAngles.y;
            float moveAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + camTrans.eulerAngles.y;

            moveDirection = Quaternion.Euler(0f, moveAngle, 0f) * Vector3.forward;
                
            //Debug.Log("Velocity: " + velocity);
                
            float moveSpeed = isSprinting ? sprintForce : walkForce;

            moveForce = moveDirection * moveSpeed;
            //Debug.Log("Move force: " + moveForce);

            Vector3 stoppingForce = Vector3.zero;

            if (Mathf.Pow((appliedForce.x + moveForce.x), 2) < Mathf.Pow(appliedForce.x, 2))
                stoppingForce.x = stoppingForceGround;
            if (Mathf.Pow((appliedForce.z + moveForce.z), 2) < Mathf.Pow(appliedForce.z, 2))
                stoppingForce.z = stoppingForceGround;

            moveForce.y = 0f;
            
            Vector3 gravityForce = new Vector3(0,-gravity, 0);

            appliedForce += (moveForce - stoppingForce + gravityForce) * Time.deltaTime;
        }

        cControl.Move(appliedForce);
    }

    void MouseMovement()
    {
        float h = horizontalLookSpeed * Input.GetAxis("Mouse X");
        float v = verticalLookSpeed * Input.GetAxis("Mouse Y");
        v *= invertCamera ? 1 : -1;

        //if (camTrans.eulerAngles.x + v <= 10f || camTrans.eulerAngles.x + v >= 80f) v = 0;

        camTrans.RotateAround(camTrans.position, camTrans.right, v);
        shoulder.RotateAround(shoulder.position, shoulder.right, v);
        transform.RotateAround(transform.position, transform.up, h);
    }

    GameObject bullet;

    public void Fire()
    {
        
        CmdFire(bulletSpawn.position, bulletSpawn.rotation);
    }

    [Command]
    public void CmdFire(Vector3 pos, Quaternion rot)
    {
        if (bullets.Count < bulletLimit)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, pos, rot);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30f;

            // Spawn the bullet on the client
            NetworkServer.Spawn(bullet);

            bullet.GetComponent<Bullet>().pc = this;
            bullets.Add(bullet);
            
        }
    }
    
    public void SetCursorActive(bool active)
    {
        Cursor.lockState = active ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = active;
    }

    public void BulletDeath(Bullet bullet)
    {
        bullets.Remove(bullet.gameObject);
        Destroy(bullet.gameObject);
    }

}
