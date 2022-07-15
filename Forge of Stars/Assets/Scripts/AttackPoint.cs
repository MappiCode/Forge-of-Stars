using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackPoint : MonoBehaviour
{
    public Transform aimPoint;

    public Sprite[] animationSprites;

    private Collider2D coll;
    [SerializeField] private bool isAttacking = false;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector2 aimPositionNormalized = Vector3.Normalize(aimPoint.localPosition);
        Vector2 difference = aimPoint.position - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90;

        if (!isAttacking)
        {
            transform.localPosition = aimPositionNormalized * (new Vector2(1, 0.5f)) / 2;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }

    private IEnumerator OnAttack()
    {
        isAttacking = true;
        coll.enabled = isAttacking;
        
        yield return StartCoroutine(SpriteAnimator.AnimateOnceCo(GetComponent<SpriteRenderer>(), animationSprites, 0.1f));
        
        isAttacking = false;
        coll.enabled = isAttacking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking)
            Debug.Log("Treffer");
        else
            Debug.Log("Angriff ins Leere");
    }
}
