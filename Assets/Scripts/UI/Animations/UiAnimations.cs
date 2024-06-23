using UnityEngine;

public class UiAnimations : MonoBehaviour
{
    public void HoverOn()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void HoverOff()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
