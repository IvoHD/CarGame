using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool hasPackage = false;

    [SerializeField] Color32 HasPackageColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 DefaultColor = new Color32(255, 255, 255, 255);

    SpriteRenderer Sprite;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Contact confirmed");
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
                Destroy(collider.gameObject); //Destroy(collision, 0.5f);
            }
        }
        if (collider.tag == "Customer" && hasPackage) {
            hasPackage = false;

            Sprite.color = DefaultColor;
            Debug.Log("Package delivered");
        }
    }
}
