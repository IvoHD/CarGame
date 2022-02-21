using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float SteerSpeed = 220;
    float DefaultSpeed = 10.5f;
    [SerializeField] float MoveSpeed = 10.5f;
    [SerializeField] float SlowSpeed = 7.5f;
    [SerializeField] float BoostSpeed = 18.5f;
    float AffectedTimer = 0;
    bool Affected;
    float SteerAmount;
    float MoveAmount;
    bool Boost; //false = bumped
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Package").Length == 0 && !GetComponent<Collision>().hasPackage) {
            Debug.Log("Nice, you won the Game!");
        }
        if (Input.GetAxis("Vertical") != 0) SteerAmount = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        else SteerAmount = 0;
        MoveAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        transform.Translate(0, MoveAmount, 0);
        transform.Rotate(0, 0, -SteerAmount);

        if (Affected) {
            AffectedTimer += Time.deltaTime;
            if (AffectedTimer >= (Boost ? 3 : 1)) {
                AffectedTimer = 0;
                MoveSpeed = DefaultSpeed;
                Affected = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost") {
            Debug.Log("Boost activated");
            MoveSpeed = BoostSpeed;
            Affected = true;
            Boost = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle") {
            Debug.Log("Slowdown");
            MoveSpeed = SlowSpeed;
            Affected = true;
            Boost = false;
        }
    }
}
