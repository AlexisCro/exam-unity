using UnityEngine;

public class DoorClickAnimator : MonoBehaviour
{
    private Animator animator;
    public bool IsOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            IsOpen = !IsOpen;
            animator.SetBool("IsOpen", IsOpen);
        }
    }
}
