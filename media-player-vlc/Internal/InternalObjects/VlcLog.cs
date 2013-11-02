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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Common.Logging;
using DZ.MediaPlayer.Vlc.Exceptions;
using DZ.MediaPlayer.Vlc.Internal.Interfaces;
using DZ.MediaPlayer.Vlc.Internal.Interop;

#endregion

namespace DZ.MediaPlayer.Vlc.Internal.InternalObjects
{
    /// <summary>
    /// Mapper of original vlc log to specified <seealso cref="ILog"/> logger interface.
    /// </summary>
    internal sealed class VlcLog : InternalObjectBase
    {
        private readonly ILog logger;

        /// <summary>
        /// Pointer to associated libvlc_log_t structure.
        /// </summary>
        private readonly IntPtr descriptor;
        public override IntPtr Descriptor {
            get {
                return (descriptor);
            }
        }

        /// <summary>
        /// Pointer to MediaLibraryFactory' descriptor.
        /// </summary>
        //private readonly IntPtr ownerDescriptor;
        private readonly ILogVerbosityManager logVerbosityManager;

        public VlcLog(IntPtr descriptor, ILogVerbosityManager logVerbosityManager, ILog logger) {
            if (descriptor == IntPtr.Zero) {
                throw new ArgumentException("Zero pointer.", "descriptor");
            }
            if (logVerbosityManager == null) {
                throw new ArgumentNullException("logVerbosityManager");
            }
            if (logger == null) {
                throw new ArgumentNullException("logger");
            }
            //
            this.descriptor = descriptor;
            this.logVerbosityManager = logVerbosityManager;
            this.logger = logger;
        }

        /// <summary>
        /// Vlc log verbosity level.
        /// </summary>
        public int Verbosity {
            get {
                VerifyObjectIsNotDisposed();
                //
                return (logVerbosityManager.Verbosity);
            }
            set {
                VerifyObjectIsNotDisposed();
                //
                logVerbosityManager.Verbosity = value;
            }
        }

        public void UpdateMessages() {
            VerifyObjectIsNotDisposed();
            //
            IntPtr iterator = LibVlcInterop.libvlc_log_get_iterator(descriptor);
            if (IntPtr.Zero == iterator) {
                throw new VlcInternalException(LibVlcInterop.libvlc_errmsg());
            }
            //
            try {
                while (0 != LibVlcInterop.libvlc_log_iterator_has_next(iterator)) {
                    //
                    libvlc_log_message_t messageBuffer = new libvlc_log_message_t();
                    messageBuffer.sizeof_msg = Convert.ToUInt32(Marshal.SizeOf(typeof(libvlc_log_message_t)));
                    IntPtr ptrStructRes = LibVlcInterop.libvlc_log_iterator_next(iterator, ref messageBuffer);
                    if (IntPtr.Zero == ptrStructRes) {
                        throw new VlcInternalException(LibVlcInterop.libvlc_errmsg());
                    }
                    //
                    libvlc_log_message_t msgRes = (libvlc_log_message_t)Marshal.PtrToStructure(ptrStructRes, typeof(libvlc_log_message_t));
                    string text = String.Format("{0} {1} {2} : {3}", msgRes.Type,msgRes.Name,msgRes.Header,msgRes.Message);
                    //
                    switch (msgRes.Severity) {
                        case libvlc_log_message_t_severity.INFO : {
                            // INFO
                            logger.Info(text);
                            break;
                        }
                        case libvlc_log_message_t_severity.ERR: {
                            // ERR
                            logger.Error(text);
                            break;
                        }
                        case libvlc_log_message_t_severity.WARN: {
                            // WARN
                            logger.Warn(text);
                            break;
                        }
                        case libvlc_log_message_t_severity.DBG: {
                            // DBG
                            logger.Debug(text);
                            break;
                        }
                        default: {
                            logger.Trace("Unknown severity : " + text);
                            break;
                        }
                    }
                }
            } finally {
                LibVlcInterop.libvlc_log_iterator_free(iterator);
            }
        }

        public void Clear() {
            VerifyObjectIsNotDisposed();
            // Clear the vlc log source
            LibVlcInterop.libvlc_log_clear(descriptor);
        }

        protected override void Dispose(bool isDisposing) {
            try {
                // Release unmanaged resources
                LibVlcInterop.libvlc_log_close(descriptor);
            } finally {
                base.Dispose(isDisposing);
            }
        }
    }
}