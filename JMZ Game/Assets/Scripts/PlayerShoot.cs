using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject prefab;
    public float Bulletspeed = 5.0f;
    public float BulletLifetime = 2.0f;
    public AudioClip shootSound;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)

            //when the mouse is clicked
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 shootDir = mousePosition - transform.position;
                shootDir.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * Bulletspeed;
                Destroy(bullet, BulletLifetime);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
            }
    }
}
