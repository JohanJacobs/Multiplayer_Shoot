using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float speed;

    public override void OnNetworkSpawn()
    {

    }

    private void Update()
    {
        if (!IsOwner) return;

        var moveVector = GetMoveVector();
        MoveInDirection(moveVector);
    }

    private void MoveInDirection(Vector3 directionVec)
    {
        transform.position += directionVec * speed * Time.deltaTime;
    }

    private Vector3 GetMoveVector()
    {
        // TODO: move over to new input system
        Vector3 moveVec = new Vector3(0,0,0);

        if (!Application.isFocused)
            return moveVec;

        if (Input.GetKey(KeyCode.A))
            moveVec.x = -1;
        else if (Input.GetKey(KeyCode.D))
            moveVec.x =+1;

        if (Input.GetKey(KeyCode.W))
            moveVec.y = +1;
        else if (Input.GetKey(KeyCode.S))
            moveVec.y = -1;

        return moveVec;
    }

}
