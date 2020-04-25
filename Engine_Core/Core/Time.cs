using Microsoft.Xna.Framework;

namespace Engine_Core.Core
{
    public static class Time
    {
        public static int Fps;
        public static float DeltaTime;
        public static GameTime GameTime;


        public static void Update_Time(GameTime _gameTime)
        {
            DeltaTime = (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
            Fps = (int)(1 / DeltaTime);
            GameTime = _gameTime;
        }
    }
}
