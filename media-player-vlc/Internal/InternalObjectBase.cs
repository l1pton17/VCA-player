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
using DZ.MediaPlayer.Vlc.Common;

#endregion

namespace DZ.MediaPlayer.Vlc.Internal {
	/// <summary>
	/// Base class for all entities associated with internal structures of libvlc library.
	/// </summary>
	internal abstract class InternalObjectBase : DisposingRequiredObjectBase {
        /// <summary>
        /// Internal vlclib-managed handle of internal object.
        /// </summary>
	    public abstract IntPtr Descriptor {
			get;
		}
        
        protected override void Dispose(bool isDisposing) {
            try {
            } finally {
                base.Dispose(isDisposing);
            }
        }
	}
}