using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace lab.mono.game
{
    public interface ISprite
    {
        Vector2 Posicao { get; set; }

        float Rotacao { get; set; }

        bool OrigemCentralizada { get; set; }

        float Escala { get; set; }

        void LoadContent(ContentManager content);

        void Draw(SpriteBatch spriteBatch);
    }
}
