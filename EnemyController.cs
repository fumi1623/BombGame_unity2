using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float stopDistance;
    public float moveDistance;

    public GameObject EnemyBomb;

    public float coolTime;

    public Vector3 createBombPos;


    // Start is called before the first frame update
    void Start()
    {
        coolTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject target = GameObject.FindGameObjectWithTag("Player");

        Vector3 targetPos = target.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < moveDistance && distance > stopDistance) {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }

        //createBomb
        coolTime += Time.deltaTime;

        if (distance <= 2.0f && coolTime >= 3.0f) {
            CreateBomb();
            coolTime = 0.0f;
        }
    }

    void CreateBomb() {
        GameObject enemybomb = Instantiate(EnemyBomb, this.transform.position, Quaternion.identity);
        Vector3 force;
        force = this.gameObject.transform.forward;
        enemybomb.GetComponent<Rigidbody>().AddForce(createBombPos);
    }
}
