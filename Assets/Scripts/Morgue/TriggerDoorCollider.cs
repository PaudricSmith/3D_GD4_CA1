using UnityEngine;


public class TriggerDoorCollider : MonoBehaviour
{
    [SerializeField] private Animator door1Animator;
    [SerializeField] private Animator door2Animator;
    
    
    private void OnTriggerEnter(Collider other)
    {
        print("In Trigger: " + other);
        if (other.gameObject.transform.parent.CompareTag("Player"))
        {
            print("In Trigger");
            door1Animator.Play("Door_01_Open", 0, 0.0f);
            door2Animator.Play("Door_02_Open", 0, 0.0f);
            gameObject.SetActive(false);   
        }
    }
}
