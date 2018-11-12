using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------------MAIN INCLUDE-------------//
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPGGame.Helpers;
using RPGGame.Managers;
using RPGGame.Templates;
using RPGGame.Inventory;
//--------------------------------------//

namespace RPGGame.Managers
{
    public static class M_PartyMovement
    {

        public static void Update()
        {
            Characters.Character member0 = Managers.M_PartyManager.Members[0];
            member0.Moving = false;
            Vector2 move_vector = Vector2.Zero;

            if (M_GlobalManager.CanMove())
            {
                switch (M_GlobalManager.GameState)
                {
                    case (M_GlobalManager.GameStates.Overworld):
                        if (Managers.M_InputManager.KeyHeld(Managers.M_InputManager.GameKeys.Right))
                        {
                            member0.direction = Characters.Character.Directions.Right;
                            move_vector += (new Vector2(member0.MoveSpeed, 0.0f));
                        }
                        else if (Managers.M_InputManager.KeyHeld(Managers.M_InputManager.GameKeys.Left))
                        {
                            member0.direction = Characters.Character.Directions.Left;
                            move_vector += (new Vector2(-member0.MoveSpeed, 0.0f));
                        }

                        if (Managers.M_InputManager.KeyHeld(Managers.M_InputManager.GameKeys.Up))
                        {
                            member0.direction = Characters.Character.Directions.Up;
                            move_vector += (new Vector2(0.0f, -member0.MoveSpeed));
                        }
                        else if (Managers.M_InputManager.KeyHeld(Managers.M_InputManager.GameKeys.Down))
                        {
                            member0.direction = Characters.Character.Directions.Down;
                            move_vector += (new Vector2(0.0f, member0.MoveSpeed));
                        }
                        break;
                }
            }

            if(move_vector != Vector2.Zero)
            {
                move_vector.Normalize();
                if (Managers.M_InputManager.KeyHeld(Managers.M_InputManager.GameKeys.Run))
                {
                    member0.AnimationSpeed = Characters.Character.AnimationSpeeds.Run;
                    member0.Move(move_vector * member0.RunMultiplier);
                }
                else
                {
                    member0.AnimationSpeed = Characters.Character.AnimationSpeeds.Walk;
                    member0.Move(move_vector * member0.WalkMultiplier);
                }
            }

            if (member0.Moving)
            {
                for (uint i = 1; i < Managers.M_PartyManager.MembersCount; i++)
                {
                    Characters.Character lead = Managers.M_PartyManager.Members[i - 1];
                    Characters.Character follower = Managers.M_PartyManager.Members[i];
                    if (lead.HistoryElements >= follower.TrackDistance)
                    {
                        follower.Move(-(follower.Position - lead.PositionHistory[follower.TrackDistance - 1]));
                        follower.Direction = lead.DirectionHistory[follower.TrackDistance - 1];
                        follower.AnimationSpeed = lead.AnimationSpeedHistory[follower.TrackDistance - 1];
                    }    
                }
            }
            else
            {
                for (uint i = 1; i < Managers.M_PartyManager.MembersCount; i++)
                {
                    Managers.M_PartyManager.Members[i].Moving = false;
                }
            }
        }


    }
}
