﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.19462
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroKLobby {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Configs {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Configs() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ZeroKLobby.Configs", typeof(Configs).Assembly);
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
        ///   Looks up a localized string similar to ////////////////////////////////////////////////////////////////
        /////
        /////  Selected Unit Boxes
        /////
        ///
        ///unitBoxLineWidth  1.49
        ///unitBox           0.0  1.0  0.0  1.0
        ///buildBox          0.0  1.0  0.0  1.0
        ///allyBuildBox      0.8  0.8  0.2  1.0
        ///buildBoxesOnShift 1
        ///
        ///
        ///////////////////////////////////////////////////////////////////
        /////
        /////  Mouse Selection Box
        /////
        ///
        ///mouseBoxLineWidth  1.49
        ///mouseBox           1.0  1.0  1.0  1.0
        ///mouseBoxBlendSrc   src_alpha
        ///mouseBoxBlendDst   one_minus_src_alpha
        ///
        ///// best cho [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string cmdcolors {
            get {
                return ResourceManager.GetString("cmdcolors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] lups0 {
            get {
                object obj = ResourceManager.GetObject("lups0", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] lups1 {
            get {
                object obj = ResourceManager.GetObject("lups1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] lups2 {
            get {
                object obj = ResourceManager.GetObject("lups2", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] lups3 {
            get {
                object obj = ResourceManager.GetObject("lups3", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] lups4 {
            get {
                object obj = ResourceManager.GetObject("lups4", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string selectkeys {
            get {
                return ResourceManager.GetString("selectkeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] springsettings0 {
            get {
                object obj = ResourceManager.GetObject("springsettings0", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] springsettings1 {
            get {
                object obj = ResourceManager.GetObject("springsettings1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] springsettings2 {
            get {
                object obj = ResourceManager.GetObject("springsettings2", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] springsettings3 {
            get {
                object obj = ResourceManager.GetObject("springsettings3", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] springsettings4 {
            get {
                object obj = ResourceManager.GetObject("springsettings4", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to unbindall          // clear the defaults
        ///unbind enter chat  // clear the defaults
        ///
        ///fakemeta  space
        ///
        ///bind     Ctrl+backspace  togglecammode
        ///bind    Shift+backspace  togglecammode
        ///bind      Any+backspace  edit_backspace
        ///bind            Any+tab  toggleoverview
        ///bind            Any+tab  edit_complete
        ///bind          Alt+enter  chatally
        ///bind          Alt+enter  chatswitchally
        ///bind         Ctrl+enter  chatall
        ///bind         Ctrl+enter  chatswitchall
        ///bind        Shift+enter  chatspec
        ///bind        Shift+en [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string uikeys {
            get {
                return ResourceManager.GetString("uikeys", resourceCulture);
            }
        }
    }
}
