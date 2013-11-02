// This program is free software; you can redistribute it and/or modify
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

namespace DZ.MediaPlayer.Vlc.Io
{
    /// <summary>
    /// Type of media resource.
    /// </summary>
    public enum MediaInputType {
        /// <summary>
        /// Media file located in
        /// file system and can be retrieved
        /// as file.
        /// </summary>
        File,
        /// <summary>
        /// Media stream can be retrieved
        /// from network.
        /// </summary>
        NetworkStream,
        /// <summary>
        /// Media stream defined by unparsed mrl.
        /// </summary>
        UnparsedMrl
    }
}