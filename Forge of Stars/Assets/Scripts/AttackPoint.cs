using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackPoint : MonoBehaviour
{
    public Transform aimPoint;

    public Sprite[] animationSprites;

    private void Update()
    {
        Vector2 aimPositionNormalized = Vector3.Normalize(aimPoint.localPosition);
        Vector2 difference = aimPoint.position - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90;

        transform.localPosition = aimPositionNormalized * (new Vector2(1, 0.5f))/2;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    //private IEnumerator animationCo()
    //{
    //    SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    //    foreach (Sprite sprite in animationSprites)
    //    {
    //        spriteRenderer.sprite = sprite;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    private void OnAttack()
    {
        StartCoroutine(SpriteAnimator.AnimateOnceCo(GetComponent<SpriteRenderer>(), animationSprites, 0.1f));
    }
}
