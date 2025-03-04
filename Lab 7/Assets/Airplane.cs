using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angularDrag = 0.001f;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input .GetKeyUp(KeyCode.Escape))
        {
            rb.AddForce(transform.forward * enginePower);
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);

    }
}
