using UnityEngine;

public class DumbButtonBehavior : MonoBehaviour
{
    public string Color;
    private bool _clickable = true;

    private void OnMouseDown()
    {
        if (!_clickable)
            return;
        _clickable = false;

        var registerManager = FindObjectOfType<RegisterManagerBehavior>();
        registerManager.AddColor(Color);
        Destroy(this.gameObject, 0.1f);
    }
}
