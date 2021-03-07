using UnityEngine;

namespace Services.InputAdapter
{
    public class KeyboardInputAdapter : IInputAdapter
    {
        public float Horizontal
        {
            get => Input.GetAxis("Horizontal");
        }
        public float Vertical
        {
            get => Input.GetAxis("Vertical");
        }

        public bool Fire
        {
            get => Input.GetKeyDown("space");
        }
    }
}