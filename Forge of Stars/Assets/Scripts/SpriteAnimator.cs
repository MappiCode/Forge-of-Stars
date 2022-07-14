using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteAnimator
{
    public static IEnumerator AnimateOnceCo(SpriteRenderer spriteRenderer, Sprite[] sprites, float frameDelay)
    {
        if(spriteRenderer == null)
            yield break;

        foreach (Sprite sprite in sprites)
        {
            spriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(frameDelay);
        }

        spriteRenderer.sprite = sprites[0];
    }
}
