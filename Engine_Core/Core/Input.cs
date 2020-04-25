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

        private static int pScroll;
        private static int cScroll;

        public static Vector2 MousePosition
        {
            get
            {
                return new Vector2(cMouse.Position.X, cMouse.Position.Y);
            }
        }
        public static Rectangle MouseClickRect
        {
            get
            {
                return new Rectangle((int)MousePosition.X, (int)MousePosition.Y, 1, 1);
            }
        }



        public static void UpdateInput()
        {
            pKeys = cKeys;
            cKeys = Keyboard.GetState();

            pMouse = cMouse;
            cMouse = Mouse.GetState();

            pScroll = cScroll;
            cScroll = cMouse.ScrollWheelValue;
        }



        public static bool GetKeyDown(Keys _key)
        {
            if (!pKeys.IsKeyDown(_key) && cKeys.IsKeyDown(_key))
            {
                return true;
            }

            return false;
        }

        public static bool GetKeyUp(Keys _key)
        {
            if (pKeys.IsKeyDown(_key) && cKeys.IsKeyUp(_key))
            {
                return true;
            }

            return false;
        }

        public static bool GetKey(Keys _key)
        {
            if (pKeys.IsKeyDown(_key) && cKeys.IsKeyDown(_key))
            {
                return true;
            }

            return false;
        }



        public static bool MouseButtonDown(int _button)
        {
            if (cMouse.LeftButton == ButtonState.Pressed && pMouse.LeftButton != ButtonState.Pressed && _button == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Pressed && pMouse.RightButton != ButtonState.Pressed && _button == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Pressed && pMouse.MiddleButton != ButtonState.Pressed && _button == 2)
            {
                return true;
            }

            return false;
        }

        public static bool MouseButtonUp(int _button)
        {
            if (cMouse.LeftButton == ButtonState.Released && pMouse.LeftButton != ButtonState.Released && _button == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Released && pMouse.RightButton != ButtonState.Released && _button == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Released && pMouse.MiddleButton != ButtonState.Released && _button == 2)
            {
                return true;
            }

            return false;
        }

        public static bool MouseButton(int _button)
        {
            if (cMouse.LeftButton == ButtonState.Pressed && pMouse.LeftButton == ButtonState.Pressed && _button == 0)
            {
                return true;
            }

            if (cMouse.RightButton == ButtonState.Pressed && pMouse.RightButton == ButtonState.Pressed && _button == 1)
            {
                return true;
            }

            if (cMouse.MiddleButton == ButtonState.Pressed && pMouse.MiddleButton == ButtonState.Pressed && _button == 2)
            {
                return true;
            }

            return false;
        }



        public static float HorizontalAxis()
        {
            float value = 0f;

            if (GetKey(Keys.A) || GetKey(Keys.Left))
            {
                value -= 1f;
            }

            if (GetKey(Keys.D) || GetKey(Keys.Right))
            {
                value += 1f;
            }

            return MathHelper.Clamp(value, -1f, 1f);
        }

        public static float VerticalAxis()
        {
            float value = 0f;

            if (GetKey(Keys.W) || GetKey(Keys.Up))
            {
                value -= 1f;
            }

            if (GetKey(Keys.S) || GetKey(Keys.Down))
            {
                value += 1f;
            }

            return MathHelper.Clamp(value, -1f, 1f);
        }

        public static float ScrollWheel()
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


        public static float Mouse_X_Axis()
        {
            return pMouse.X - cMouse.X;
        }

        public static float Mouse_Y_Axis()
        {
            return pMouse.Y - cMouse.Y;
        }
    }

}
