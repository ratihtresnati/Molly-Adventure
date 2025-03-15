// using UnityEngine;

// public class PlayerFall : MonoBehaviour
// {
//     [SerializeField] private float fallSpeed = 5f;
//     [SerializeField] private LayerMask groundLayer;

//     private PlayerMovement playerMovement;

//     private void Start()
//     {
//         playerMovement = GetComponent<PlayerMovement>();
//     }

//     private void Update()
//     {

//         RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, groundLayer);


//         if (hit.collider == null)
//         {

//             Fall();
//         }
//     }

//     private void Fall()
//     {

//         transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

//         // Trigger FadeIn in PlayerMovement when falling
//         if (playerMovement != null)
//         {
//             if (playerMovement != null && !playerMovement.HasFallenOnce())
//             {
//                 playerMovement.SetFallenOnce(true);
//                 playerMovement.TriggerCutscene();
//             }
//         }
//     }
// }