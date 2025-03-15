// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     private bool canPassThroughHiddenEnemy = true;  // Flag untuk memeriksa apakah pemain dapat melewati musuh tersembunyi

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Enemy"))
//         {
//             if (collision.GetComponent<EnemyController>().IsHidden)
//             {
//                 // Pemain dapat melewati musuh tersembunyi
//                 Debug.Log("Pemain melewati musuh tersembunyi.");
//             }
//             else
//             {
//                 // Pemain menyentuh musuh aktif, respawn dari awal
//                 RespawnPlayer();
//             }
//         }
//     }

//     private void RespawnPlayer()
//     {
//         // Kembalikan pemain ke posisi awal
//         transform.position = new Vector2(0f, 0f);
//     }
// }