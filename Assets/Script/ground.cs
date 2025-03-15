using UnityEngine;

public class ground: MonoBehaviour
{
    private bool isGrounded = false;

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            // Objek berada di atas tanah (ground).
            // Lakukan tindakan atau aksi yang sesuai di sini.
        }
        else
        {
            // Objek tidak berada di atas tanah (ground).
            // Lakukan tindakan atau aksi yang sesuai di sini.
        }
    }
}