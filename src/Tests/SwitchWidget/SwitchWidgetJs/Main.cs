using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using elkvadi.ChameleonSharp.Core;
using elkvadi.ChameleonSharp.Ui;
using System.Collections;
using SwitchWidgetJs.Model;
using System.Runtime.CompilerServices;

namespace SwitchWidgetJs
{
    public static class Main
    {
        static ComponentOptions settings_service_component = new ComponentOptions();
        static jQueryObject _root;
        static List<SwitchType> switchTypes;

        static Main()
        {    
            settings_service_component.Name = "com.teknision.android.chameleon.settingsswitchservice.SettingsService";
            settings_service_component.Package = "com.chameleonlauncher.preorder";
            settings_service_component.Type = "service";
            _root = jQuery.Select("#chameleon-widget");

            jQuery.OnDocumentReady(delegate()
            {
                WidgetOptions wop = new WidgetOptions();
                wop.OnLoad = delegate()
                {
                    if (DependencyExists())
                    {
                        UpdateSwitchStates();
                    }
                    else
                    {
                        DisplayNoDependencyError();
                    }   
                };

                wop.OnResume = delegate()
                {
                    if (DependencyExists())
                    {
                        UpdateSwitchStates();
                    }
                    else
                    {
                        DisplayNoDependencyError();
                    }
                };
                
                wop.OnTitleBar = delegate()
                {
                    jQuery.Select("#chameleon-widget").Append("we are live");
                    LaunchGlobalSettings(null);  
                };

                wop.NotChameleon = delegate()
                {
                    DrawSwitches(null);
                };

                Chameleon.Widget(wop);
            });
        }

        private static bool DependencyExists()
	    {
		    return Chameleon.ComponentExists(settings_service_component);
	    }	
		
	    private static void DisplayNoDependencyError()
	    {
		    if(Chameleon.Exists())
                Chameleon.Invalidate();

            ClickableHtmlOptions options = new ClickableHtmlOptions();
            options.Title = "No Local Service";
            options.Caption = "This widget requires an external APK. Touch here to get it.";
            jQuery.Select("#chameleon-widget").Plugin<ChameleonUiObject>().ChameleonWidgetMessageHTML(options)
                .Plugin<ChameleonUiObject>().ChameleonInvalidate();
	    }

        private static void UpdateSwitchStates()
	    {
            IntentOptions options = new IntentOptions();
            options.Component = settings_service_component;
            options.Result = delegate(Dictionary data)
            {
                HandleUpdateSwitchStatesData(data);
            };

		    Chameleon.Intent(options);
	    }

        private static void HandleUpdateSwitchStatesData(Dictionary data)
	    {
		
		    if(!HasInitSwitches())
            {
			    InitSwitches(data);
			    DrawSwitches(null);
		    }
            else
            {			
			    SwitchType switch_wifi = GetSwitchByName("wifi");
			    if((bool)Type.GetField(data["wifi"], "enabled")){
				    ApplySwitchState(switch_wifi,"highlighted");
			    }else{
				    ApplySwitchState(switch_wifi,"disabled");
			    }
			
			    SwitchType switch_bluetooth = GetSwitchByName("bluetooth");
			    if((bool)Type.GetField(data["bluetooth"], "enabled")){
				    ApplySwitchState(switch_bluetooth,"highlighted");
			    }else{
				    ApplySwitchState(switch_bluetooth,"disabled");
			    }
			
			
			    SwitchType switch_airplanemode = GetSwitchByName("airplanemode");
			    if((bool)Type.GetField(data["airplanemode"], "enabled")){
				    ApplySwitchState(switch_airplanemode,"highlighted");
			    }else{
				    ApplySwitchState(switch_airplanemode,"disabled");
			    }
			
			
			    SwitchType switch_gps = GetSwitchByName("gps");
			    if((bool)Type.GetField(data["gps"], "enabled")){
				    ApplySwitchState(switch_gps,"highlighted");
			    }else{
				    ApplySwitchState(switch_gps,"disabled");
			    }
			
			
			    SwitchType switch_rotation = GetSwitchByName("rotation");
			    if((bool)Type.GetField(data["rotation"], "enabled")){
				    ApplySwitchState(switch_rotation,"highlighted");
			    }else{
				    ApplySwitchState(switch_rotation,"disabled");
			    }
			
			
			    SwitchType switch_brightness = GetSwitchByName("brightness");
			    string brightness_state="off";
			
			    if((bool)Type.GetField(data["brightness"], "automode")){
				    brightness_state="auto";
			    }else if((int)Type.GetField(data["brightness"], "level") == 255){
				    brightness_state="full";
			    }else if((int)Type.GetField(data["brightness"], "level") >= 125){
				    brightness_state="half";
			    }
			    ApplySwitchState(switch_brightness,brightness_state);
		    }
	    }

        private static void SetWiFiState(bool flag)
	    {
            Dictionary data = new Dictionary("change_wifi", flag);

            SetSwitchState(data);
	    }
	
	
	    private static void SetBluetoothState(bool flag)
	    {
            Dictionary data = new Dictionary("change_bluetooth", flag);

            SetSwitchState(data);
	    }
	
	
	    private static void SetAirplaneModeState(bool flag)
	    {
            Dictionary data = new Dictionary("change_airplanemode", flag);

            SetSwitchState(data);
	    }
	
	
	    private static void SetRotationState(bool flag)
	    {
            Dictionary data = new Dictionary("change_rotation", flag);

            SetSwitchState(data);
	    }
	
	    private static void SetGPSState(bool flag)
	    {
            Dictionary data = new Dictionary("change_gps", flag);

            SetSwitchState(data);
	    }
	
	
	    private static void SetBrightnessState(bool automode, int level)
	    {
            Dictionary data = new Dictionary(
                "change_brightness_auto", automode,
                "change_brightness_level", level);

            SetSwitchState(data);
	    }

        private static void SetSwitchState(Dictionary data)
        {
            IntentOptions options = new IntentOptions();
            options.Component = settings_service_component;
            options.Data = data;

            Chameleon.Intent(options);
        }

        private static void HandleAirplaneModeClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    
            SwitchType switch_type = GetSwitchByName("airplanemode");
		    if(switch_type.State == "disabled"){
			    ApplySwitchState(switch_type,"highlighted",delegate()
                {
                    SetAirplaneModeState(true);
                });
		    }else{
			    ApplySwitchState(switch_type,"disabled",delegate()
                {
                    SetAirplaneModeState(false);
                });
		    }
	    }

        private static void HandleBluetoothClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    
            SwitchType switch_type = GetSwitchByName("bluetooth");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted",delegate()
                {
                    SetBluetoothState(true);
                });
		    }else{
			    ApplySwitchState(switch_type,"disabled",delegate()
                {
                    SetBluetoothState(false);
                });
		    }
	    }

        private static void HandleBrightnessClick(jQueryEvent e)
        {
	        e.PreventDefault();
		
	        //launch display settings
            IntentOptions options = new IntentOptions();
            options.Action = "android.settings.DISPLAY_SETTINGS";
	        Chameleon.Intent(options);
        }

        private static void HandleGPSClick(jQueryEvent e)
	    {
		    e.PreventDefault();

            IntentOptions options = new IntentOptions();
            options.Action = "android.settings.LOCATION_SOURCE_SETTINGS";
		    Chameleon.Intent(options);
	    }

	    private static void HandleLockClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("lock");
		    if(switch_type.State == "disabled"){
			    ApplySwitchState(switch_type,"highlighted");
		    }else{
			    ApplySwitchState(switch_type,"disabled");
		    }
	    }
	
        private static void HandleNetworkClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("network");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted");
		    }else{
			    ApplySwitchState(switch_type,"disabled");
		    }
	    }
	
	
	    private static void HandleRingerClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("ringer");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted");
		    }else{
			    ApplySwitchState(switch_type,"disabled");
		    }
	    }

        private static void HandleRotationClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("rotation");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted",delegate()
                {
                    SetRotationState(true);
                });
		    }else{
			    ApplySwitchState(switch_type,"disabled",delegate()
                {
                    SetRotationState(false);
                });
		    }
	    }
	
	    private static void HandleSyncClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("sync");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted");
		    }else{
			    ApplySwitchState(switch_type,"disabled");
		    }
	    }

        private static void HandleTimeoutClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("timeout");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted");
		    }else{
			    ApplySwitchState(switch_type,"disabled");
		    }
	    }
	
	    private static void HandleVibrateClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("vibrate");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted");
		    }else{
			    ApplySwitchState(switch_type,"disabled");
		    }
	    }

        private static void HandleWiFiClick(jQueryEvent e)
	    {
		    e.PreventDefault();
		    SwitchType switch_type = GetSwitchByName("wifi");
		    if(switch_type.State=="disabled"){
			    ApplySwitchState(switch_type,"highlighted",delegate()
                {
                    SetWiFiState(true);
                });
		    }else{
			    ApplySwitchState(switch_type,"disabled",delegate()
                {
                    SetWiFiState(false);
                });
		    }
	    }

        private static bool HasInitSwitches()
	    {
		    return switchTypes != null;
	    }

        private static void InitSwitches(Dictionary options)
	    {
		    if(switchTypes == null){
			    switchTypes = new List<SwitchType>();
			
			    string test_state = "disabled";
			
			    if(options["airplanemode"] != null && (bool)Type.GetField(options["airplanemode"], "exists")){
				    string airplane_state = "disabled";
				    if((bool)Type.GetField(options["airplanemode"], "enabled"))
                        airplane_state = "highlighted";
				
                    SwitchType airplane = new SwitchType();
                    airplane.Name = "airplanemode";
                    airplane.ClassName = "switch-airplanemode";
                    airplane.Caption = "Airplane Mode";
                    airplane.State = airplane_state;
                    airplane.OnClick = HandleAirplaneModeClick;
				    switchTypes.Add(airplane);
			    }
			
			
			    if(options["bluetooth"] != null && (bool)Type.GetField(options["bluetooth"], "exists")){
				    string bluetooth_state = "disabled";
				    if((bool)Type.GetField(options["bluetooth"], "enabled"))
                        bluetooth_state="highlighted";

                    SwitchType bluetooth = new SwitchType();
                    bluetooth.Name = "bluetooth";
                    bluetooth.ClassName = "switch-bluetooth";
                    bluetooth.Caption = "Bluetooth";
                    bluetooth.State = bluetooth_state;
                    bluetooth.OnClick = HandleBluetoothClick;
				    switchTypes.Add(bluetooth);
			    }
			
			
			    if(options["brightness"] != null && (bool)Type.GetField(options["brightness"], "exists")){
				    string brightness_state="off";
				
				    if((bool)Type.GetField(options["brightness"], "automode")){
					    brightness_state="auto";
				    }else if((int)Type.GetField(options["brightness"], "level") == 255){
					    brightness_state="full";
				    }else if((int)Type.GetField(options["brightness"], "level") >= 125){
					    brightness_state="half";
				    }
				
                    SwitchType brightness = new SwitchType();
                    brightness.Name = "brightness";
                    brightness.ClassName = "switch-brightness";
                    brightness.Caption = "Brightness";
                    brightness.State = brightness_state;
                    brightness.OnClick = HandleBrightnessClick;
				    switchTypes.Add(brightness);
			    }
			
			    if(options["gps"] != null && (bool)Type.GetField(options["gps"], "exists")){
				    string gps_state="disabled";
				    if((bool)Type.GetField(options["gps"], "enabled"))
                        gps_state="highlighted";
				    
                    SwitchType gps = new SwitchType();
                    gps.Name = "gps";
                    gps.ClassName = "switch-gps";
                    gps.Caption = "GPS";
                    gps.State = gps_state;
                    gps.OnClick = HandleGPSClick;
				    switchTypes.Add(gps);
			    }
			
			    if(options["lock"] != null && (bool)Type.GetField(options["lock"], "exists"))
                {
                    SwitchType deviceLock = new SwitchType();
                    deviceLock.Name = "lock";
                    deviceLock.ClassName = "switch-lock";
                    deviceLock.Caption = "Lock";
                    deviceLock.State = test_state;
                    deviceLock.OnClick = HandleLockClick;
				    switchTypes.Add(deviceLock);
                }

                if(options["network"] != null && (bool)Type.GetField(options["network"], "exists"))
                {
                    SwitchType network = new SwitchType();
                    network.Name = "network";
                    network.ClassName = "switch-network";
                    network.Caption = "Network";
                    network.State = test_state;
                    network.OnClick = HandleNetworkClick;
				    switchTypes.Add(network);
                }
			    
                if(options["ringer"] != null && (bool)Type.GetField(options["ringer"], "exists"))
                {
                    SwitchType ringer = new SwitchType();
                    ringer.Name = "ringer";
                    ringer.ClassName = "switch-ringer";
                    ringer.Caption = "Ringer";
                    ringer.State = test_state;
                    ringer.OnClick = HandleRingerClick;
				    switchTypes.Add(ringer);
                }
			
			
			    if(options["rotation"] != null && (bool)Type.GetField(options["rotation"], "exists"))
                {
				    string rotation_state="disabled";
				    if((bool)Type.GetField(options["rotation"], "enabled"))
                        rotation_state="highlighted";
				    
                    SwitchType rotation = new SwitchType();
                    rotation.Name = "rotation";
                    rotation.ClassName = "switch-rotation";
                    rotation.Caption = "Rotation";
                    rotation.State = test_state;
                    rotation.OnClick = HandleRotationClick;
				    switchTypes.Add(rotation);
			    }
			
			
			    if(options["sync"] != null && (bool)Type.GetField(options["sync"], "exists"))
                {
                    SwitchType sync = new SwitchType();
                    sync.Name = "sync";
                    sync.ClassName = "switch-sync";
                    sync.Caption = "Sync";
                    sync.State = test_state;
                    sync.OnClick = HandleSyncClick;
				    switchTypes.Add(sync);
                }

			    if(options["timeout"] != null && (bool)Type.GetField(options["timeout"], "exists"))
                {
                    SwitchType timeout = new SwitchType();
                    timeout.Name = "timeout";
                    timeout.ClassName = "switch-timeout";
                    timeout.Caption = "Timeout";
                    timeout.State = test_state;
                    timeout.OnClick = HandleTimeoutClick;
				    switchTypes.Add(timeout);
                }

			    if(options["vibrate"] != null && (bool)Type.GetField(options["vibrate"], "exists"))
                {
                    SwitchType vibrate = new SwitchType();
                    vibrate.Name = "vibrate";
                    vibrate.ClassName = "switch-vibrate";
                    vibrate.Caption = "Vibrate";
                    vibrate.State = test_state;
                    vibrate.OnClick = HandleVibrateClick;
				    switchTypes.Add(vibrate);
                }
			
			    if(options["wifi"] != null && (bool)Type.GetField(options["wifi"], "exists"))
                {
				    string wifi_state = "disabled";
				    if((bool)Type.GetField(options["wifi"], "enabled"))
                        wifi_state="highlighted";

                    SwitchType wifi = new SwitchType();
                    wifi.Name = "wifi";
                    wifi.ClassName = "switch-wifi";
                    wifi.Caption = "WiFi";
                    wifi.State = wifi_state;
                    wifi.OnClick = HandleWiFiClick;
				    switchTypes.Add(wifi);   
			    }
		    }
	    }

        private static SwitchType GetSwitchByName(string name)
	    {
		    InitSwitches(null);

            foreach(SwitchType switchType in switchTypes)
            {
                if(!string.IsNullOrEmpty(switchType.Name) && name == switchType.Name)
				    return switchType;
            }

            return null;
	    }

        [AlternateSignature]
        private extern static void ApplySwitchState(SwitchType switch_type, string new_state);

        private static void ApplySwitchState(SwitchType switch_type, string new_state, Action callback)
        {		
		    if(switch_type.State != new_state)
            {
			    Chameleon.Invalidate();

                InvalidateOptions options = new InvalidateOptions();
                options.Time = 100;
                options.Callback = callback;
		
			    string class_state_suffix="";
			    if(switch_type.State != null)
                    class_state_suffix="-"+switch_type.State;
		
			    string current_class = switch_type.ClassName + class_state_suffix;
			    string new_class = switch_type.ClassName + "-" + new_state;
			
			    jQuery.Select("." + current_class).RemoveClass("switch-" + switch_type.State).AddClass("switch-" + new_state);
			    jQuery.Select("." + current_class).RemoveClass(current_class).AddClass(new_class)
                    .Plugin<ChameleonUiObject>().ChameleonInvalidate(options);	
			    
                switch_type.State = new_state;
			
			    Chameleon.InvalidateTwo();
		    }
	    }

        private static void DrawSwitches(Dictionary options)
	    {
		    InitSwitches(options);
		
		    string html="<ul class=\"switches-list\">";		
				
		    foreach(SwitchType switch_type in switchTypes)
            {			
			    string class_state_suffix="";
			    if(switch_type.State != null)
                    class_state_suffix = "-" + switch_type.State;
			
			    html +="<li class=\"" + switch_type.ClassName + class_state_suffix + " switch" + class_state_suffix + "\">";
		
			    html +=	"<div class=\"icon\">";
			    html +=	"</div>";
			
			    html +=	"<div class=\"caption\">";
			    html +=	"<p>" +switch_type.Caption.ToUpperCase() + "</p>";
			    html +=	"</div>";
			
			    html += "</li>";
		    }
		
		
		    html += "</ul>";
            jQuery.Select("#chameleon-widget").Html(html);
		
		    foreach(SwitchType switch_type in switchTypes)
            {
			    if(switch_type.OnClick != null)
                {
				    string class_state_suffix = "";
				    if(switch_type.State != null)
                        class_state_suffix="-"+switch_type.State;

				    jQuery.Select("." + switch_type.ClassName + class_state_suffix).Click(switch_type.OnClick);
			    }			
		    }
		
	    }
	
	    private static void LaunchGlobalSettings(jQueryEvent e)
	    {
		    if(e != null)
                e.PreventDefault();
		 
            IntentOptions options = new IntentOptions();
            options.Action = "android.settings.SETTINGS";

            Chameleon.Intent(options);
	    }
    }
}
