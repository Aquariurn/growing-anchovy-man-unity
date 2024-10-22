using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(AnimationLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelUp() {
        animator.SetInteger("Level", playerManager.player.GetLevel());
        ResetAnimation();
    }

    private void ResetAnimation() {
        animator.Play($"player{playerManager.player.GetLevel()}_idle", -1, 0f);
        animator.SetBool("IsWorking", false);
        animator.SetBool("Workout1", false);
        animator.SetBool("Workout2", false);
    }

    private IEnumerator AnimationLoop() {
        while (true) {
            yield return StartCoroutine(SetAnimation());
        }
    }

    public IEnumerator SetAnimation() {
        int select = 0;
        select = Random.Range(0, 3);

        switch (select) {
            case 0:
                animator.SetBool("IsWorking", false);
                animator.SetBool("Workout1", false);
                animator.SetBool("Workout2", false);
                yield return new WaitForSeconds(3f);
                break;
            case 1:
                animator.SetBool("IsWorking", true);
                animator.SetBool("Workout2", true);
                animator.SetBool("Workout1", false);
                yield return new WaitForSeconds(3.6f);
                break;
            case 2:
                animator.SetBool("IsWorking", true);
                animator.SetBool("Workout1", true);
                animator.SetBool("Workout2", false);
                yield return new WaitForSeconds(3f);
                break;
        }
    }
}
