using UnityEngine;

public class MagneticField : MonoBehaviour
{
    public float magneticForce = 10f; // The strength of the magnetic force
    public float magneticRadius = 5f; // The radius of the magnetic field

    private void FixedUpdate()
    {
        // Find all objects with the "Player" tag within the magnetic radius
        Collider[] playersInRange = Physics.OverlapSphere(transform.position, magneticRadius, 1 << LayerMask.NameToLayer("Heroes"));

        foreach (Collider player in playersInRange)
        {
            // Get the direction from the player to the magnet
            Vector3 direction = transform.position - player.transform.position;

            // Apply the magnetic force in the direction away from the magnet
            player.GetComponent<Rigidbody>().AddForce(direction.normalized * magneticForce, ForceMode.Force);

            // Translate the player away from the magnet without changing its rotation
            player.transform.Translate(direction.normalized * Time.fixedDeltaTime, Space.World);
        }
    }
}