using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine_Core.Core
{
    public static class Input
    {
        private static KeyboardState pKeys;
        private static KeyboardState cKeys;

        private static MouseState pMouse;
        private static MouseState cMouse;

        public static Vector2 mousePosition = Vector2.Zero;

        private static int pScroll = 0;
        private static int cScroll = 0;


        public static void Update_Input()
        {
            pKeys = cKeys;
            cKeys = Keyboard.GetState();

            pMouse = cMouse;
            cMouse = Mouse.GetState();

            pScroll = cScroll;
            cScroll = cMouse.ScrollWheelValue;

            mousePosition.X = cMouse.X;
            mousePosition.Y = cMouse.Y;

            //------------------Pause/Mouse Cursor Stuff goes here

        }



        public static bool GetKeyDown(Keys _key)
        {
            if (cKeys.IsKeyDown(_key) && !pKeys.IsKeyDown(_key))
            {
                return true;
            }

            return false;
        }

        public static bool GetKeyUp(Keys _key)
        {
            if (cKeys.IsKeyUp(_key) && !pKeys.IsKeyUp(_key))
            {
                return true;
            }

            return false;
        }

        public static bool GetKey(Keys _key)
        {
            if (cKeys.IsKeyDown(_key))
            {
                return true;
            }

            return false;
        }



        public static bool GetMouseButtonDown(int _index)
        {
            if (cMouse.LeftButton == ButtonState.Pressed && pMouse.LeftButton != ButtonState.Pressed && _index == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Pressed && pMouse.RightButton != ButtonState.Pressed && _index == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Pressed && pMouse.MiddleButton != ButtonState.Pressed && _index == 2)
            {
                return true;
            }

            return false;
        }

        public static bool GetMouseButtonUp(int _index)
        {
            if (cMouse.LeftButton == ButtonState.Released && pMouse.LeftButton != ButtonState.Released && _index == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Released && pMouse.RightButton != ButtonState.Released && _index == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Released && pMouse.MiddleButton != ButtonState.Released && _index == 2)
            {
                return true;
            }

            return false;
        }

        public static bool GetMouseButton(int _index)
        {

            if (cMouse.LeftButton == ButtonState.Pressed && _index == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Pressed && _index == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Pressed && _index == 2)
            {
                return true;
            }

            return false;
        }

        public static int GetScrollWheel()
        {
            if (cScroll < pScroll)
            {
                return -1;
            }

            if (cScroll > pScroll)
            {
                return 1;
            }

            return 0;
        }

        public static Vector2 GetMousePosition()
        {
            return mousePosition;
        }

        public static Rectangle GetMouseClickRect()
        {
            return new Rectangle((int)mousePosition.X, (int)mousePosition.Y, 1, 1);
        }

    }
}
