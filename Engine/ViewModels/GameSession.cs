﻿using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        private Location _curentLocation;
        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation
        {
            get { return _curentLocation; }
            set
            {
                _curentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));
            }
        }

        public bool HasLocationToNorth
        {
            get 
            { 
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null; 
            }

        }
        

        public bool HasLocationToEast
        {
            get 
            { 
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate +1, CurrentLocation.YCoordinate ) != null; 
            }

        }
        public bool HasLocationToSouth
        {
            get 
            { 
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null; 
            }

        }
        public bool HasLocationToWest
        {
            get 
            { 
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate -1, CurrentLocation.YCoordinate ) != null; 
            }

        }
        public GameSession()
        {
            CurrentPlayer = new Player 
            { 
                Name = "Scott",
                CharacterClass = "Fighter",
                HitPoints = 10,
                Gold = 1000000,
                ExperiencePoints = 0,
                Level = 1,
            };



            CurrentWorld = WorldFactory.CreateWorld();

            
            CurrentLocation = CurrentWorld.LocationAt(0, 0);

        }

        public void MoveNorth()
        {
            if (HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }

        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
            
         }

        public void MoveSouth()
        {
            if (HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        
    }
}