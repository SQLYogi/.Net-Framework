﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP01Configuration {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class TP01Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static TP01Settings defaultInstance = ((TP01Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TP01Settings())));
        
        public static TP01Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://google.com")]
        public string ServiceURL {
            get {
                return ((string)(this["ServiceURL"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\NICO\\DOCUMENTS\\NEWEFD" +
            "B.MDF;Integrated Security=True")]
        public string dbConnection {
            get {
                return ((string)(this["dbConnection"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Red")]
        public string FavoriteColor {
            get {
                return ((string)(this["FavoriteColor"]));
            }
            set {
                this["FavoriteColor"] = value;
            }
        }
    }
}
