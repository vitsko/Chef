﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chef {
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
    internal class Text {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Text() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Chef.Text", typeof(Text).Assembly);
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
        ///   Looks up a localized string similar to Caloricity of salad: {0}.
        /// </summary>
        internal static string AboutCaloricity {
            get {
                return ResourceManager.GetString("AboutCaloricity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to About vegetables in the salad:.
        /// </summary>
        internal static string AboutVegetables {
            get {
                return ResourceManager.GetString("AboutVegetables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You input incorrect max calorie of vegetable per unit of weigth. 
        ///Max calorie of vegetable per unit of weigth must be integer..
        /// </summary>
        internal static string ErrorRange {
            get {
                return ResourceManager.GetString("ErrorRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Main menu:
        ///[1] -- About vegetables in the salad
        ///[2] -- Caloricity of salad
        ///[3] -- Sort vegetables by color
        ///[4] -- Search vegetables by calories per unit of weigth
        ///
        ///[Q] -- Exit
        ///    .
        /// </summary>
        internal static string MainMenu {
            get {
                return ResourceManager.GetString("MainMenu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please press any key to exit in the main menu..
        /// </summary>
        internal static string PressAnyKey {
            get {
                return ResourceManager.GetString("PressAnyKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could you please specify max calorie of vegetable per unit of weigth?.
        /// </summary>
        internal static string QuestionRange {
            get {
                return ResourceManager.GetString("QuestionRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Result of search is empty..
        /// </summary>
        internal static string ResultEmpty {
            get {
                return ResourceManager.GetString("ResultEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chef.
        /// </summary>
        internal static string Title {
            get {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }
    }
}