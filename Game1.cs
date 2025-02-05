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
    static Player[] SavedCharacters;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Character = new Player();
        SavedCharacters = new Player[4];
    }

    static void SaveGame()
    {
        var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "saveGame.json");
        string Data = Game1.createSaveData();
        File.WriteAllText(path, Data);
    }

    static string createSaveData()
    {
        string returnString = "";
        for (int index = 0; index < 3; index++)
        {
            returnString += SavedCharacters[index].playerTexture + "," +
            SavedCharacters[index].playerPosition + "," +
            SavedCharacters[index].characterClass + "," +
            SavedCharacters[index].intelligence + "," +
            SavedCharacters[index].str + "," +
            SavedCharacters[index].dex + "," +
            SavedCharacters[index].level + "," +
            SavedCharacters[index].health + "," +
            SavedCharacters[index].mana + "," +
            SavedCharacters[index].shield + "," +
            SavedCharacters[index].armour + "," +
            SavedCharacters[index].dodgeRating + "," +
            SavedCharacters[index].dodgeChance + "," +
            SavedCharacters[index].physicalDamageReduction + "," +
            SavedCharacters[index].fireRes + "," +
            SavedCharacters[index].coldRes + "," +
            SavedCharacters[index].lightningRes + "," +
            SavedCharacters[index].darkRes + "," +
            SavedCharacters[index].damageIncrease + "," +
            SavedCharacters[index].atkDamageIncrease + "," +
            SavedCharacters[index].spellDamageIncrease + "," +
            SavedCharacters[index].attackSpeed + "/n";
        }
        return returnString;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 100f;

        // if new character
        // if (isNewCharacter)
        // {
        // Character = Character.initializeNew(Dungeon_Crawler_Roguelite.Player.ClassTypes.Warrior);
        // character.addSkillTree(character);
        // }
        // else
        // {
        //     var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "saveGame.json");
        //     string data = File.ReadAllText(path);
        //     character.intializeExisting(data);
        // }

        SavedCharacters.Append<Player>(Character);
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
            SaveGame();
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
