using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Snake : Actor
    {
        private List<Actor> segments = new List<Actor>();


        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Snake(Point pointstart, Point startvelocity, Color playercolor)
        {
            PrepareBody(pointstart, startvelocity, playercolor);
        
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(Color color)
        {
    
                Actor head = segments.First<Actor>();
                Point position = head.GetPosition();

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(new Point(0,0));
                segment.SetText("#");
                segment.SetColor(color);
                segments.Add(segment);

        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
           Actor head = GetHead();
           head.MoveNext();
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        Random random = new Random();
        private void PrepareBody(Point pointstart, Point startvelocity, Color playercolor)
        {  
            string head = "8";

            Actor segment = new Actor();
            segment.SetPosition(pointstart);
            segment.SetVelocity(startvelocity);
            segment.SetText(head);
            segment.SetColor(playercolor);
            segments.Add(segment);
            
        }
    }
}