using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float x;
    float z;
    float cameraX;
    float cameraZ;
    public float speed;
    Rigidbody rb;
    public Vector3 playerPos;
    public GameObject Bomb;
    private bool bombTime = true;

    Animator animator;
    private float damageTrueTime;

    public int playerHp = 3;

    //public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //enemyController = new EnemyController();

    }

    // Update is called once per frame
    void Update()
    {

        damageTrueTime += Time.deltaTime;

        //Debug.Log(enemyController.moveSpeed);

        cameraX = Input.GetAxisRaw("Horizontal");
        cameraZ = Input.GetAxisRaw("Vertical");

        Clamp();

        //pleyer?????bomb?????????
        Bomb.transform.position = transform.position + transform.forward * 0.5f + transform.up * 0.2f;

        if (Input.GetKeyDown(KeyCode.Z) && bombTime == true) {
            animator.SetTrigger("Bomb");
            StartCoroutine("CreateBomb");
            StartCoroutine("Reload");
        }

        if(playerHp <= 0) {
            animator.SetTrigger("Dead");
        }
    }

    public void FixedUpdate() {

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * cameraZ + Camera.main.transform.right * cameraX;
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y * speed, 0);
        if (moveForward != Vector3.zero && speed != 0f) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        animator.SetFloat("Speed", rb.velocity.magnitude);

    }

    void Clamp() {
        playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -9.4f, 9.4f);
        playerPos.z = Mathf.Clamp(playerPos.z, -9.4f, 9.4f);
        transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        transform.position = playerPos;
    }

    public void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("EnemyBombCrush") && (damageTrueTime >= 3.0f)) {

            damageTrueTime = 0f;
            animator.SetTrigger("Damage");
            playerHp -= 1;
            Debug.Log(playerHp);
        }
    }



    IEnumerator CreateBomb() {
        yield return new WaitForSeconds(0.6f);
        GameObject bomb = Instantiate(Bomb) as GameObject;
        Vector3 force;
        force = this.gameObject.transform.forward;
        bomb.GetComponent<Rigidbody>().AddForce(force);
    }

    IEnumerator Reload() {
        bombTime = false;
        yield return new WaitForSeconds(9.0f);
        bombTime = true;
    }

}
