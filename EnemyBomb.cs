using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public float moveSpeed;
    public float stopDistance;
    public float moveDistance;

    public GameObject enemyBombBody;
    public GameObject enemyBombFire;

    public GameObject target;
    public float distance;

    private float fireCount;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);


        if (enemyBombBody.activeSelf == true) {
            Vector3 targetPos = target.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);

            if (distance < moveDistance && distance > stopDistance) {
                transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            }
        }
        


        if (this.gameObject == true) {
            fireCount += Time.deltaTime;
        }

        if (fireCount >= 5.0f || (fireCount >= 3.0f && distance <= 0.2)) {
            enemyBombFire.SetActive(true);
            enemyBombBody.SetActive(false);
        }

        if (enemyBombFire.activeSelf == true) {
            Despawn();
        }
    }

    public void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")) {

            Debug.Log("ダメージ");
        }
    }

    IEnumerator Despawn() {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
