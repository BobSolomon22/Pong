using Microsoft.Xna.Framework;

namespace Pong {
    public class CollisionRectangle {
        private int height, width;
        private Vector2 origin, A, B, C, D;

        public CollisionRectangle(Vector2 origin, int width, int height) {
            this.origin = origin;
            this.height = height;
            this.width = width;
            update(origin);
        }

        public void update(Vector2 origin) {
            A = new Vector2(origin.X - (width / 2), origin.Y - height / 2);
            B = new Vector2(A.X + width, A.Y);
            C = new Vector2(A.X, A.Y + height);
            D = new Vector2(B.X, B.Y - height);
        }
        public bool collidesWith(CollisionRectangle otherRect) {
            return false;
        }
    }
}