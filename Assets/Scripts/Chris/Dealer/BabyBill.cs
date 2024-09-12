using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBill : MonoBehaviour
{
    public float moveDistance;
    private float moveTime = 0.5f;

    private void Start()
    {
        GameEvents.OnSlumsplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.SlumsClipTags.BillBossSwarm);
    }

    public void SetParentPos(Vector3 parentPos)
    {
        //gets a direction away from the parentPos
        var moveDirection = (transform.position - parentPos).normalized;
        //gets a position to move to by adding move distance in the direction of the move
        var moveTarget = transform.position + (moveDirection * moveDistance);
        LeanTween.move(gameObject, moveTarget, moveTime);
    }
}
