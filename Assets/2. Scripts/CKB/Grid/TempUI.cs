using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUI : MonoBehaviour
{
    public void OnClickMoveButton(int direction)
    {
        PlaceableObject.MoveDirection moveDirection = 0;

        switch (direction)
        {
            case 1 : moveDirection = PlaceableObject.MoveDirection.Up; break;
            case -1 : moveDirection = PlaceableObject.MoveDirection.Down; break;
            case 2 : moveDirection = PlaceableObject.MoveDirection.Right; break;
            case -2 : moveDirection = PlaceableObject.MoveDirection.Left; break;
        }

        BuildingSystem.Instance.objectToPlace.Move(moveDirection);
    }

    public void OnClickRotateButton()
    {
        BuildingSystem.Instance.objectToPlace.RotateVertical();
    }
}
