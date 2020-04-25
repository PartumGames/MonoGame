using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine_Core.Core
{
    public static class AssetLoader
    {

        private static ContentManager content;

        public static void Init(ContentManager _content)
        {
            content = _content;
        }

        public static Texture2D GetTexture(string _path)
        {
            return content.Load<Texture2D>(_path);
        }

        public static SpriteFont GetFont(string _path)
        {
            return content.Load<SpriteFont>(_path);
        }

    }
}
