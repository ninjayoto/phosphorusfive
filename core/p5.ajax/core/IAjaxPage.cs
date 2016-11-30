/*
 * Phosphorus Five, copyright 2014 - 2016, Thomas Hansen, thomas@gaiasoul.com
 * 
 * This file is part of Phosphorus Five.
 *
 * Phosphorus Five is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License version 3, as published by
 * the Free Software Foundation.
 *
 *
 * Phosphorus Five is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Phosphorus Five.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * If you cannot for some reasons use the GPL license, Phosphorus
 * Five is also commercially available under Quid Pro Quo terms. Check 
 * out our website at http://gaiasoul.com for more details.
 */

using System;
using System.Collections.Generic;

namespace p5.ajax.core
{
    /// <summary>
    ///     Interface for all your pages that uses the p5.ajax library
    /// </summary>
    public interface IAjaxPage
    {
        /// <summary>
        ///     Returns the manager for your page
        /// </summary>
        /// <value>The manager</value>
        Manager Manager
        {
            get;
        }

        /// <summary>
        ///     Returns the list of JavaScript files/objects page contains
        /// </summary>
        /// <value>The JavaScript files to push back to client</value>
        List<Tuple<string, bool>> JavaScriptToPush
        {
            get;
        }

        /// <summary>
        ///     Returns the list of new JavaScript files/objects page added during this request
        /// </summary>
        /// <value>The JavaScript files to push back to client</value>
        List<Tuple<string, bool>> NewJavaScriptToPush
        {
            get;
        }

        /// <summary>
        ///     Returns the list of Stylesheet files that page contains
        /// </summary>
        /// <value>The CSS files to push back to client</value>
        List<string> StylesheetFilesToPush
        {
            get;
        }
        
        /// <summary>
        ///     Returns the list of Stylesheet files that was added during this request
        /// </summary>
        /// <value>The CSS files to push back to client</value>
        List<string> NewStylesheetFilesToPush
        {
            get;
        }

        /// <summary>
        ///     Registers a JavaScript file to be included on to the client-side
        /// </summary>
        /// <param name="url">URL to JavaScript file</param>
        void RegisterJavaScriptFile (string url);
        
        /// <summary>
        ///     Registers a stylesheet file to be included on to the client-side
        /// </summary>
        /// <param name="url">URL to JavaScript file</param>
        void RegisterStylesheetFile (string url);
    }
}