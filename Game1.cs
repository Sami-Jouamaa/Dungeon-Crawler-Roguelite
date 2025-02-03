using System;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon_Crawler_Roguelite;

public class Game1 : Game
{
    Texture2D ballTexture;
    Vector2 ballPosition;
    float ballSpeed;

    static Player Character;

    Player character;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    static void SaveGame(Player player)
    {
        var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "saveGame.json");
        string Data = Game1.createSaveData(player);
        File.WriteAllText(path, Data);
    }

    static string createSaveData(Player player)
    {
        string returnString = "";
        returnString += player.playerTexture +
            player.playerPosition +
            player.characterClass +
            player.level +
            player.health +
            player.mana +
            player.shield +
            player.armour +
            player.dodgeChance +
            player.physicalDamageReduction +
            player.fireRes +
            player.coldRes +
            player.lightningRes +
            player.darkRes +
            player.damageIncrease +
            player.atkDamageIncrease +
            player.spellDamageIncrease +
            player.attackSpeed;
        return returnString;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 100f;
        this.character = new Player();

        // if new character
        // if (isNewCharacter)
        // {
        this.character = character.initializeNew(Dungeon_Crawler_Roguelite.Player.ClassTypes.Warrior);
        // character.addSkillTree(character);
        // }
        // else
        // {
        //     character.intializeExisting(saveFile);
        // }

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        ballTexture = Content.Load<Texture2D>("ball");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            SaveGame(Game1.Character);
            Exit();
        }

        float updatedBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        var keyboardState = Keyboard.GetState();

        // TODO: Add your update logic here
        if (keyboardState.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= updatedBallSpeed;
        }
        if (keyboardState.IsKeyDown(Keys.Down))
        {
            ballPosition.Y += updatedBallSpeed;
        }
        if (keyboardState.IsKeyDown(Keys.Right))
        {
            ballPosition.X += updatedBallSpeed;
        }
        if (keyboardState.IsKeyDown(Keys.Left))
        {
            ballPosition.X -= updatedBallSpeed;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            ballTexture,
            ballPosition,
            null,
            Color.Red,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
