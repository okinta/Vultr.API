﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;balance&quot;: &quot;-5519.11&quot;,
        ///    &quot;pending_charges&quot;: &quot;57.03&quot;,
        ///    &quot;last_payment_date&quot;: &quot;2014-07-18 15:31:01&quot;,
        ///    &quot;last_payment_amount&quot;: &quot;-1.00&quot;
        ///}.
        /// </summary>
        internal static string AccountInfo {
            get {
                return ResourceManager.GetString("AccountInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;SCRIPTID&quot;: 5
        ///}.
        /// </summary>
        internal static string CreateStartupScript {
            get {
                return ResourceManager.GetString("CreateStartupScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;3&quot;: {
        ///        &quot;SCRIPTID&quot;: &quot;3&quot;,
        ///        &quot;date_created&quot;: &quot;2014-05-21 15:27:18&quot;,
        ///        &quot;date_modified&quot;: &quot;2014-05-21 15:27:18&quot;,
        ///        &quot;name&quot;: &quot;test &quot;,
        ///        &quot;type&quot;: &quot;boot&quot;,
        ///        &quot;script&quot;: &quot;#!/bin/bash echo Hello World &gt; /root/hello&quot;
        ///    },
        ///    &quot;5&quot;: {
        ///        &quot;SCRIPTID&quot;: &quot;5&quot;,
        ///        &quot;date_created&quot;: &quot;2014-08-22 15:27:18&quot;,
        ///        &quot;date_modified&quot;: &quot;2014-09-22 15:27:18&quot;,
        ///        &quot;name&quot;: &quot;test &quot;,
        ///        &quot;type&quot;: &quot;pxe&quot;,
        ///        &quot;script&quot;: &quot;#!ipxe\necho Hello World\nshell&quot;
        ///    }
        ///}.
        /// </summary>
        internal static string StartupScripts {
            get {
                return ResourceManager.GetString("StartupScripts", resourceCulture);
            }
        }
    }
}
