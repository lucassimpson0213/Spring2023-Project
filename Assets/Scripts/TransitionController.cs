using UnityEngine;

public class TransitionController : MonoBehaviour
{

    public Animator animator;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
}
