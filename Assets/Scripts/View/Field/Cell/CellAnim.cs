using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAnim : MonoBehaviour
{
    public Action AnimFinished;
    public Animator Animator;
    public void SetChip(Chip chip)
    {
        switch (chip)
        {
            case Chip.Fire:
                Animator.SetBool("Fire",true);
                break;
            case Chip.Water:
                Animator.SetBool("Water",true);
                break;
        }
    }
    public void PlayDestroyAnim()
    {
        Animator.SetBool("Destroy", true);
    }
    private void OnAnimFinished()
    {
        AnimFinished?.Invoke();
    }
}
