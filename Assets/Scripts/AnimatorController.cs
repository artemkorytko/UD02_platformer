using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

        [SerializeField] private Animator _animator;

    private string Run = "Run";
    private string Jump = "Jump";
    private string Idle = "Idle";
        public void SetRunTrigger()
        {
            SetTrigger(Run);
        }

        public void SetJumpTrigger()
        {
            SetTrigger(Jump);
        }

        public void SetIdleTrigger()
        {
            SetTrigger(Idle);
        }

        public void SetTrigger(string triggerName) => _animator.SetTrigger(triggerName);
    
}
