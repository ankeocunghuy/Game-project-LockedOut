using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    // Rotation speed (degrees/second)
    public float rotationSpeed = 45f;

    // Rotation axis (X, Y, Z)
    public Axis rotationAxis = Axis.X;

    // Rotation direction (Clockwise, CounterClockwise)
    public Direction rotationDirection = Direction.Clockwise;

    void Update()
    {
        // Determine rotation axis
        Vector3 axis = rotationAxis switch
        {
            Axis.X => Vector3.right,
            Axis.Y => Vector3.up,
            Axis.Z => Vector3.forward,
            _ => Vector3.right
        };

        // Determine rotation direction
        float direction = rotationDirection == Direction.Clockwise ? 1f : -1f;

        // Rotate the plane
        transform.Rotate(axis, rotationSpeed * direction * Time.deltaTime);
    }

    // Enum for rotation axis
    public enum Axis { X, Y, Z }

    // Enum for rotation direction
    public enum Direction { Clockwise, CounterClockwise }
}