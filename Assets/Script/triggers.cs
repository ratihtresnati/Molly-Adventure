using UnityEngine;
using UnityEngine.SceneManagement;

public class triggers : MonoBehaviour
{
    public string stage1;
    public float activationDistance = 5f;

    private Transform Player;

    private void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.position);

        
        if (distance < activationDistance)
        {

            SceneManager.LoadScene(stage1);
        }
    }
}
