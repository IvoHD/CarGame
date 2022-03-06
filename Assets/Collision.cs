using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool hasPackage = false;

    [SerializeField] Color32 HasPackageColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 DefaultColor = new Color32(255, 255, 255, 255);

    [SerializeField] float DefaultSpeed = 10.5f;
    [SerializeField] ParticleSystem HouseExplosionEffect;
    float AffectedTimer = 0;
    bool Affected;
    bool Boost; //false = bumped

    Driver Driver;

    SpriteRenderer Sprite;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Driver = GetComponent<Driver>();
    }

    void Update()
    {
        isAffected();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle") {
            if (Driver.MoveSpeed == Driver.BoostSpeed) {
                HouseExplosionEffect.transform.position = collision.transform.position;

                HouseExplosionEffect.Play();
                Destroy(collision.gameObject);

            }
            Debug.Log("Slowdown");
            Driver.MoveSpeed = Driver.SlowSpeed;
            Affected = true;
            Boost = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) //collision = the thing bumbed into
    {
        if (collider.tag == "Package") {
            if(hasPackage) {
                Debug.Log("You already have a Package");
            }
            else {
                hasPackage = true;
                Sprite.color = HasPackageColor;
                Debug.Log("Package picked up");
                Destroy(collider.gameObject); //Destroy(collider, 0.5f);
            }
        }
        else if (collider.tag == "Boost") {
            Debug.Log("Boost activated");
            Driver.MoveSpeed = Driver.BoostSpeed;
            Affected = true;
            Boost = true;
        }
        else if (collider.tag == "Customer" && hasPackage) {
            hasPackage = false;

            Sprite.color = DefaultColor;
            Debug.Log("Package delivered");
        }
    }

    void isAffected()
    {
        if (Affected) {
            AffectedTimer += Time.deltaTime;
            if (AffectedTimer >= (Boost ? 3 : 1)) {
                AffectedTimer = 0;
                Driver.MoveSpeed = DefaultSpeed;
                Affected = false;
            }
        }
    }

 
}
