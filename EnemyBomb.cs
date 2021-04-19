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

    private float fireCount;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (this.gameObject == true) {
            fireCount += Time.deltaTime;
        }

        if (fireCount >= 5.0f || distance <= 0.2) {
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
