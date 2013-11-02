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

using System;
using System.Runtime.Serialization;
using DZ.MediaPlayer.Vlc.Internal.Interop;

namespace DZ.MediaPlayer.Vlc.Exceptions
{
    /// <summary>
    /// Represents an exception handled during work with native libraries.
    /// </summary>
    [Serializable]
    public sealed class VlcInternalException : MediaPlayerException
    {
        /// <summary>
        /// Default constructor. This constructor automaticly calls 
        /// <see cref="LibVlcInterop.libvlc_errmsg"/> method.
        /// </summary>
        public VlcInternalException() : base(LibVlcInterop.libvlc_errmsg()) {
        }

        /// <summary>
        /// Constructor with string message.
        /// </summary>
        public VlcInternalException(string message) : base(message) {
        }

        /// <summary>
        /// Constructor for inner exceptions handling.
        /// </summary>
        public VlcInternalException(string message, Exception inner) : base(message, inner) {
        }

        /// <summary>
        /// Constructor with serialization support.
        /// </summary>
        public VlcInternalException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
