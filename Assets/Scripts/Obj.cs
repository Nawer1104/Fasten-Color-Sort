using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public GameObject vfxScale;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == gameObject.tag)
        {
            anim.SetTrigger("Scale");
            GetComponent<DragAndDrop>()._dragging = false;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
        }
    }

    public void PlayVfx()
    {
        GameObject vfx = Instantiate(vfxScale, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
        gameObject.SetActive(false);
    }
}
