using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float fireCount = 0.0f;
    public GameObject fire;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject == true) {
            fireCount += Time.deltaTime;
        }

        if(fireCount >= 5.0f) {
            fire.SetActive(true);
            bomb.SetActive(false);
        }

        if(fireCount >= 8.0f) {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Enemy")) {

            Destroy(other.gameObject);
        }
    }
}
