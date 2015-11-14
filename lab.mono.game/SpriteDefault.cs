using lab.mono.game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class SpriteDefault : ISprite
{
    private readonly string nomeTextura;
    private Texture2D textura;
    private Vector2 origem;

    public float Escala { get; set; }

    public bool OrigemCentralizada { get; set; }

    public Vector2 Posicao { get; set; }

    public float Rotacao { get; set; }


    public SpriteDefault(string nomeTextura)
    {
        this.nomeTextura = nomeTextura;
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(textura, Posicao, null, Color.White, Rotacao, origem, Escala, SpriteEffects.None, 0);
    }

    public void LoadContent(ContentManager content)
    {
        textura = content.Load<Texture2D>(nomeTextura);

        if (OrigemCentralizada)
            origem = new Vector2(textura.Width, textura.Height) / 2f;
    }
}