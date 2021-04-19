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



    //public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
        //enemyController = new EnemyController();

    }

    // Update is called once per frame
    void Update()
    {

        
        //Debug.Log(enemyController.moveSpeed);

        cameraX = Input.GetAxisRaw("Horizontal");
        cameraZ = Input.GetAxisRaw("Vertical");

        Clamp();

        //pleyer?????bomb?????????
        Bomb.transform.position = transform.position + transform.forward * 0.5f;

        if (Input.GetKeyDown(KeyCode.Z) && bombTime == true) {
            GameObject bomb = Instantiate(Bomb) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward;
            bomb.GetComponent<Rigidbody>().AddForce(force);
            StartCoroutine("Reload");
        }
    }

    private void FixedUpdate() {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * cameraZ + Camera.main.transform.right * cameraX;
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);
        if (moveForward != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void Clamp() {
        playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -9.4f, 9.4f);
        playerPos.z = Mathf.Clamp(playerPos.z, -9.4f, 9.4f);
        transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        transform.position = playerPos;
    }

    public void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("EnemyBombCrush")) {

            Debug.Log("熱い");
        }
    }

    IEnumerator Reload() {
        bombTime = false;
        yield return new WaitForSeconds(9.0f);
        bombTime = true;
    }

}
