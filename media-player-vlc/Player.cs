﻿// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston MA 02110-1301, USA.

#region Usings

using System;
using System.Collections.Generic;
using DZ.MediaPlayer.Vlc.Common;
using DZ.MediaPlayer.Vlc.Io;

#endregion

namespace DZ.MediaPlayer {
	
#pragma warning disable 0419
	
    /// <summary>
    /// Represents player's features and behaviour.
    /// </summary>
    public abstract class Player : DisposingRequiredObjectBase {
        /// <summary>
        /// Cleanup method should be overrided.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected override void Dispose(bool isDisposing) {
            try {
            } finally {
                base.Dispose(isDisposing);
            }
        }

		/// <summary>
		/// Current state of the player.
		/// </summary>
        public abstract PlayerState State {
            get;
        }

		/// <summary>
		/// Gets value from 0.0 to 1.0 which defines percentage position of currently playing media.
		/// </summary>
        public abstract float Position {
            get;
            set;
        }

		/// <summary>
		/// Indicates player fullscreen state. If that property is <value>true</value> then
		/// player output window is in fullscreen mode.
		/// </summary>
    	public abstract bool IsFullScreen {
    		get;
    		set;
    	}

		/// <summary>
		/// Gets or sets time of current position.
		/// </summary>
        public abstract TimeSpan Time {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets volume of player.
		/// </summary>
        public abstract int Volume {
            get;
            set;
        }

        /// <summary>
        /// List of player's events subscribers.
        /// </summary>
        public abstract IList<PlayerEventsReceiver> EventsReceivers {
            get;
        }
		
		/// <summary>
		/// Parses media and returns information about it.
		/// </summary>
		/// <param name="mediaInput">
		/// A <see cref="MediaInput"/> to locate media to be preparsed.
		/// </param>
		/// <returns>
		/// A <see cref="PreparsedMedia"/> instance with information about media located using
		/// <param cref="mediaInput"/>.
		/// </returns>
		public abstract PreparsedMedia ParseMediaInput(MediaInput mediaInput);

		/// <summary>
		/// Initializes media to play.
		/// </summary>
        /// <param name="mediaInput">A <see cref="MediaInput"/> instance which identifies resource to 
        /// play after <see cref="Play"/> method call.
        /// </param>
        public abstract void SetMediaInput(MediaInput mediaInput);
		
		/// <summary>
		/// Initializes previously preparsed media to play.
		/// </summary>
		/// <param name="preparsedMedia">
		/// A <see cref="PreparsedMedia"/> instance returned from <see cref="ParseMediaInput"/> method.
		/// </param>
		public abstract void SetMediaInput(PreparsedMedia preparsedMedia);

		/// <summary>
		/// Initializes next media to play.
		/// </summary>
		/// <param name="mediaInput">A <see cref="MediaInput"/> instance which identifies resource to 
        /// play after <see cref="Play"/> method call.
        /// </param>
		public abstract void SetNextMediaInput(MediaInput mediaInput);
		
		/// <summary>
		/// Initializes previously preparsed next media to play.
		/// </summary>
		/// <param name="preparsedMedia">
		/// A <see cref="PreparsedMedia"/> instance returned from <see cref="ParseMediaInput"/> method.
		/// </param>
		public abstract void SetNextMediaInput(PreparsedMedia preparsedMedia);

		/// <summary>
		/// Starts playing of media which was initialized using <see cref="SetMediaInput"/> method.
		/// </summary>
        public abstract void Play();

		/// <summary>
		/// Pauses playing.
		/// </summary>
        public abstract void Pause();

		/// <summary>
		/// Resumes playing after <see cref="Pause"/> call.
		/// </summary>
        public abstract void Resume();

		/// <summary>
		/// Stops playing.
		/// </summary>
        public abstract void Stop();

		/// <summary>
		/// Plays next media which was initialized using <see cref="SetNextMediaInput"/> method.
		/// </summary>
        public abstract void PlayNext();

		/// <summary>
		/// Takes snapshot of currently playing media.
		/// </summary>
		/// <param name="filePath">Path where to save snapshot.</param>
		/// <param name="width">Width of image.</param>
		/// <param name="height">Height of image.</param>
        public abstract void TakeSnapshot(string filePath, int width, int height);
    }
}