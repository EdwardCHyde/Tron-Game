using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool winner1 = false;

        private bool tie = false;


        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSnakeCollisions(cast);
                HandleSegmentCollisions(cast);
            }
            else if (isGameOver == true)
            {
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSnakeCollisions(Cast cast)
        {

            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");

            Actor head = snake.GetHead();
            Actor head2 = snake2.GetHead();

            List<Actor> body = snake.GetBody();
            List<Actor> body2 = snake2.GetBody();

            
            
            if (head.GetPosition().Equals(head2.GetPosition()))
            {
                isGameOver = true;
                tie = true;
            
            }
            foreach (Actor segment in body)
            {

                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    winner1 = true;
                }
            
            }
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    winner1 = false;
                }
            
            }
            
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");

            Actor head = snake.GetHead();
            Actor head2 = snake2.GetHead();

            List<Actor> body = snake.GetBody();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    winner1 = false;
                }
            
            }


            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    winner1 = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
             Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");

                List<Actor> segments = snake.GetSegments();
                List<Actor> segments2 = snake2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

            if (isGameOver == true && winner1 == true && tie == false)
            {
               

                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
        
                }
            }
            else if (isGameOver == true && winner1 == false && tie == false)
            {
               

                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
        
                }
            }
            else if (isGameOver == true && winner1 == false && tie == true)
            {
               

                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
        
                }
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
        
                }
            }
        }

    }
}