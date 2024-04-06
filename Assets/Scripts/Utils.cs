using UnityEngine;

public static class Utils
{
    public static Vector2 GetMouseScreenPosition()
    {
        // TODO: Move to new input system
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        // convert the screen coordinates (X, Y) to world coordinates (X, Y, Z)
        Vector3 mousePos = GetMouseScreenPosition();
        mousePos.z = Camera.main.nearClipPlane;
        
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public static Vector3 GetMouseWorldPositionNoZ()
    {
        // reset the z to be 0 
        var mouseWorldPos = GetMouseWorldPosition();
        mouseWorldPos.z = 0;
        return mouseWorldPos;
    }


    public static bool IsMouseButtonDown(int button)
    {
        // TODO: Move to new input system
        return Input.GetMouseButtonDown(button);
    }
}
