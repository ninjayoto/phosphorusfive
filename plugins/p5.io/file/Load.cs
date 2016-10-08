/*
 * Phosphorus Five, copyright 2014 - 2016, Thomas Hansen, mr.gaia@gaiasoul.com
 * 
 * This file is part of Phosphorus Five.
 *
 * Phosphorus Five is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Phosphorus Five is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * If you cannot for some reasons use the Affero GPL license, Phosphorus
 * Five is also commercially available under Quid Pro Quo terms. Check 
 * out our website at http://gaiasoul.com for more details.
 */

using System.IO;
using p5.exp;
using p5.core;
using p5.io.common;
using p5.exp.exceptions;

namespace p5.io.file
{
    /// <summary>
    ///     Class to help load files
    /// </summary>
    public static class Load
    {
        /// <summary>
        ///     Loads files from disc
        /// </summary>
        /// <param name="context">Application Context</param>
        /// <param name="e">Parameters passed into Active Event</param>
        [ActiveEvent (Name = "load-file")]
        public static void file_load (ApplicationContext context, ActiveEventArgs e)
        {
            ObjectIterator.Iterate (context, e.Args, true, "read-file", delegate (string filename, string fullpath) {
                if (File.Exists (fullpath)) {
                    if (IsTextFile (filename)) {
                        LoadTextFile (context, e.Args, fullpath, filename);
                    } else {
                        LoadBinaryFile (e.Args, fullpath, filename);
                    }
                } else {
                    throw new LambdaException (
                        string.Format ("Couldn't find file '{0}'", filename),
                        e.Args,
                        context);
                }
            });
        }

        /*
         * Determines if file is text according to the most common file extensions
         */
        private static bool IsTextFile (string fileName)
        {
            switch (Path.GetExtension (fileName)) {
                case ".txt":
                case ".md":
                case ".css":
                case ".js":
                case ".html":
                case ".htm":
                case ".hl":
                case ".xml":
                case ".csv":
                    return true;
                default:
                    return false;
            }
        }

        /*
         * Loads specified as text and appends into args
         */
        private static void LoadTextFile (
            ApplicationContext context, 
            Node args, 
            string fullpath,
            string fileName)
        {
            using (TextReader reader = File.OpenText (fullpath)) {

                // Reading file content
                string fileContent = reader.ReadToEnd ();

                // Checking if we should automatically convert file content to lambda
                if (fileName.EndsWith (".hl") && args.GetExChildValue ("convert", context, true)) {

                    // Automatically converting to Hyperlambda before returning
                    args.Add (fileName, null, Utilities.Convert<Node> (context, fileContent).Children);
                }
                else {

                    // Adding file content as string
                    args.Add (fileName, fileContent);
                }
            }
        }

        /*
         * Loads a binary file and appends as blob/byte[] into args
         */
        private static void LoadBinaryFile (
            Node args, 
            string rootFolder,
            string fileName)
        {
            using (FileStream stream = File.OpenRead (rootFolder + fileName)) {

                // Reading file content
                var buffer = new byte [stream.Length];
                stream.Read (buffer, 0, buffer.Length);
                args.Add (fileName, buffer);
            }
        }
    }
}
