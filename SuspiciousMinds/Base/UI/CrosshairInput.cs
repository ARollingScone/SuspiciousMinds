using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SuspiciousMinds.Base.Interfaces;

namespace SuspiciousMinds.Base.UI
{
    public class CrosshairInput : IInputComponent
    {
        public Vector2f MouseCoords { get; set; }

        public Dictionary<Keyboard.Key, bool> Keys { get; set; } 
            = new Dictionary<Keyboard.Key, bool>(); 

        public void Update()
        {

        }
    }
}
