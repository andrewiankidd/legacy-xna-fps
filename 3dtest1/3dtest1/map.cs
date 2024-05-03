using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _3dtest1
{

    public class map : DrawableGameComponent
    {
        private ContentManager _content;
        private Model _model;

        Matrix[] _boneTransforms;


        public map(Game game, ContentManager content)
            : base(game)
        {
            _content = content;
        }

        protected override void LoadContent()
        {
            _model = _content.Load<Model>("Content/maps/map1/House");
            _boneTransforms = new Matrix[_model.Bones.Count];

        }


        public override void Draw(GameTime gameTime)
        {

            Drawmap();


            base.Draw(gameTime);
        }

        public void Drawmap()
        {
            _model.CopyAbsoluteBoneTransformsTo(_boneTransforms);
            // Draw the model.

            foreach (ModelMesh mesh in _model.Meshes)
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    //effect.EnableDefaultLighting();
                    effect.World = _boneTransforms[mesh.ParentBone.Index];
                    effect.View = Game1.viewMatrix;
                    effect.Projection = Game1.projectionMatrix;
                }

                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }


    }

}
