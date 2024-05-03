using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace _3dtest1
{

    public class weapon : DrawableGameComponent
    {
        private ContentManager _content;
        public static Model _model;

        Matrix[] _boneTransforms;

        Vector3 wRoll = new Vector3(20, 10, 15);
        public static Vector3 wPosition = new Vector3(0, 7, 7);

        int wRolli = 10;
        int wRotatei = 15;



        public weapon(Game game, ContentManager content) : base(game)
        {
            _content = content;    
        }

        protected override void LoadContent()
        {
            _model = _content.Load<Model>("Content/Weapons/SMG");
            _boneTransforms = new Matrix[_model.Bones.Count];
        }


        public override void Draw(GameTime gameTime)
        {
           
            if (Game1.state == "play")
            {
                GameInput(gameTime);
            }
                DrawWeapon();

            base.Draw(gameTime);
        }

        public void DrawWeapon()
        {
            _model.CopyAbsoluteBoneTransformsTo(_boneTransforms);

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = _boneTransforms[mesh.ParentBone.Index];
                    effect.View = Matrix.CreateLookAt(wRoll, wPosition, Vector3.Up);
                    //close,roll,rotate   l,up/down,r
                    effect.World = Matrix.CreateScale(0.03f);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                    GraphicsDevice.Viewport.Width / GraphicsDevice.Viewport.Height,10,10000);                    
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }


        public void GameInput(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (mouse.Y < 10 && wRolli < 15)
            {
                wRolli++;
            }
            else if (mouse.Y > Game1.windowheight - 10 && wRolli > 5)
            {
                wRolli--;
            }
            else if (mouse.Y > 10 && mouse.Y < Game1.windowheight - 10)
            {
                if (wRolli > 10)
                {
                   wRolli--;
                }
                else if (wRolli < 10)
                {
                   wRolli++;
                }
            }
            if (mouse.X < 10 && wRotatei < 20)
            {
                wRotatei++;
            }
            else if (mouse.X > Game1.windowwidth - 10 && wRotatei > 10)
            {
                wRotatei--;
            }
            else if (mouse.X > 10 && mouse.X < Game1.windowwidth - 10)
            {
                if (wRotatei > 15)
                {
                    wRotatei--;
                }
                else if (wRotatei < 15)
                {
                   wRotatei++;
                }
            }
            wRoll = new Vector3(15, wRolli, wRotatei);
        }
    }
}
