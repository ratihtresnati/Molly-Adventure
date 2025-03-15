using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isGettingHurt = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy" && !isGettingHurt)
        {
            GetHurt();
            Debug.Log("sakit :(");
        }
    }

    private void GetHurt()
    {
        isGettingHurt = true;
        GetComponent<Animator>().SetLayerWeight(1, 1);
        float timer = 0f;
        while (timer < 3f)
        {
            timer += Time.fixedDeltaTime;
        }
        GetComponent<Animator>().SetLayerWeight(1, 0);
        isGettingHurt = false;
    }
}