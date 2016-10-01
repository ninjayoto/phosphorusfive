/*
 * Phosphorus Five, copyright 2014 - 2016, Thomas Hansen, phosphorusfive@gmail.com
 * Phosphorus Five is licensed under the terms of the MIT license, see the enclosed LICENSE file for details
 */

using System.IO;
using p5.exp;
using p5.core;
using p5.io.common;

namespace p5.io.file.file_state
{
    /// <summary>
    ///     Class to help check the read-only state of a file
    /// </summary>
    public static class IsReadOnly
    {
        /// <summary>
        ///     Returns the read-only state of the specified file(s)
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "file-is-read-only")]
        public static void file_is_read_only (ApplicationContext context, ActiveEventArgs e)
        {
            QueryHelper.Run (context, e.Args, true, "file-is-read-only", delegate (string filename, string fullpath) {
                FileInfo info = new FileInfo (fullpath);
                e.Args.Add (filename, info.IsReadOnly);
                return true;
            });
        }

        /// <summary>
        ///     Changes the read-only state of the specified file(s)
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "file-set-read-only")]
        public static void file_set_read_only (ApplicationContext context, ActiveEventArgs e)
        {
            QueryHelper.Run (context, e.Args, true, "file-set-read-only", delegate (string filename, string fullpath) {
                FileInfo info = new FileInfo (fullpath);
                info.IsReadOnly = true;
                return true;
            });
        }

        /// <summary>
        ///     Changes the read-only state of the specified file(s)
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "file-delete-read-only")]
        public static void file_delete_read_only (ApplicationContext context, ActiveEventArgs e)
        {
            QueryHelper.Run (context, e.Args, true, "file-set-read-only", delegate (string filename, string fullpath) {
                FileInfo info = new FileInfo (fullpath);
                info.IsReadOnly = false;
                return true;
            });
        }
    }
}
