//! SwitchWidgetJs.debug.js
//

(function($) {

Type.registerNamespace('SwitchWidgetJs.Model');

////////////////////////////////////////////////////////////////////////////////
// SwitchWidgetJs.Model.SwitchType

SwitchWidgetJs.Model.SwitchType = function SwitchWidgetJs_Model_SwitchType() {
    /// <field name="name" type="String">
    /// </field>
    /// <field name="class" type="String">
    /// </field>
    /// <field name="caption" type="String">
    /// </field>
    /// <field name="state" type="String">
    /// </field>
    /// <field name="onClick" type="Function">
    /// </field>
}
SwitchWidgetJs.Model.SwitchType.prototype = {
    name: null,
    class: null,
    caption: null,
    state: null,
    onClick: null
}


Type.registerNamespace('SwitchWidgetJs');

////////////////////////////////////////////////////////////////////////////////
// SwitchWidgetJs.Main

SwitchWidgetJs.Main = function SwitchWidgetJs_Main() {
    /// <field name="_settings_service_component" type="Object" static="true">
    /// </field>
    /// <field name="_root" type="jQueryObject" static="true">
    /// </field>
    /// <field name="_switchTypes" type="Array" static="true">
    /// </field>
}
SwitchWidgetJs.Main._dependencyExists = function SwitchWidgetJs_Main$_dependencyExists() {
    /// <returns type="Boolean"></returns>
    return chameleon.componentExists(SwitchWidgetJs.Main._settings_service_component);
}
SwitchWidgetJs.Main._displayNoDependencyError = function SwitchWidgetJs_Main$_displayNoDependencyError() {
    if (chameleon.exists()) {
        chameleon.invalidate();
    }
    var options = {};
    options.title = 'No Local Service';
    options.caption = 'This widget requires an external APK. Touch here to get it.';
    $('#chameleon-widget').chameleonWidgetMessageHTML(options).chameleonInvalidate();
}
SwitchWidgetJs.Main._updateSwitchStates = function SwitchWidgetJs_Main$_updateSwitchStates() {
    var options = {};
    options.component = SwitchWidgetJs.Main._settings_service_component;
    options.result = function(data) {
        SwitchWidgetJs.Main._handleUpdateSwitchStatesData(data);
    };
    chameleon.intent(options);
}
SwitchWidgetJs.Main._handleUpdateSwitchStatesData = function SwitchWidgetJs_Main$_handleUpdateSwitchStatesData(data) {
    /// <param name="data" type="Object">
    /// </param>
    if (!SwitchWidgetJs.Main._hasInitSwitches()) {
        SwitchWidgetJs.Main._initSwitches(data);
        SwitchWidgetJs.Main._drawSwitches(null);
    }
    else {
        var switch_wifi = SwitchWidgetJs.Main._getSwitchByName('wifi');
        if (data['wifi'].enabled) {
            SwitchWidgetJs.Main._applySwitchState(switch_wifi, 'highlighted');
        }
        else {
            SwitchWidgetJs.Main._applySwitchState(switch_wifi, 'disabled');
        }
        var switch_bluetooth = SwitchWidgetJs.Main._getSwitchByName('bluetooth');
        if (data['bluetooth'].enabled) {
            SwitchWidgetJs.Main._applySwitchState(switch_bluetooth, 'highlighted');
        }
        else {
            SwitchWidgetJs.Main._applySwitchState(switch_bluetooth, 'disabled');
        }
        var switch_airplanemode = SwitchWidgetJs.Main._getSwitchByName('airplanemode');
        if (data['airplanemode'].enabled) {
            SwitchWidgetJs.Main._applySwitchState(switch_airplanemode, 'highlighted');
        }
        else {
            SwitchWidgetJs.Main._applySwitchState(switch_airplanemode, 'disabled');
        }
        var switch_gps = SwitchWidgetJs.Main._getSwitchByName('gps');
        if (data['gps'].enabled) {
            SwitchWidgetJs.Main._applySwitchState(switch_gps, 'highlighted');
        }
        else {
            SwitchWidgetJs.Main._applySwitchState(switch_gps, 'disabled');
        }
        var switch_rotation = SwitchWidgetJs.Main._getSwitchByName('rotation');
        if (data['rotation'].enabled) {
            SwitchWidgetJs.Main._applySwitchState(switch_rotation, 'highlighted');
        }
        else {
            SwitchWidgetJs.Main._applySwitchState(switch_rotation, 'disabled');
        }
        var switch_brightness = SwitchWidgetJs.Main._getSwitchByName('brightness');
        var brightness_state = 'off';
        if (data['brightness'].automode) {
            brightness_state = 'auto';
        }
        else if (data['brightness'].level === 255) {
            brightness_state = 'full';
        }
        else if (data['brightness'].level >= 125) {
            brightness_state = 'half';
        }
        SwitchWidgetJs.Main._applySwitchState(switch_brightness, brightness_state);
    }
}
SwitchWidgetJs.Main._setWiFiState = function SwitchWidgetJs_Main$_setWiFiState(flag) {
    /// <param name="flag" type="Boolean">
    /// </param>
    var data = { change_wifi: flag };
    SwitchWidgetJs.Main._setSwitchState(data);
}
SwitchWidgetJs.Main._setBluetoothState = function SwitchWidgetJs_Main$_setBluetoothState(flag) {
    /// <param name="flag" type="Boolean">
    /// </param>
    var data = { change_bluetooth: flag };
    SwitchWidgetJs.Main._setSwitchState(data);
}
SwitchWidgetJs.Main._setAirplaneModeState = function SwitchWidgetJs_Main$_setAirplaneModeState(flag) {
    /// <param name="flag" type="Boolean">
    /// </param>
    var data = { change_airplanemode: flag };
    SwitchWidgetJs.Main._setSwitchState(data);
}
SwitchWidgetJs.Main._setRotationState = function SwitchWidgetJs_Main$_setRotationState(flag) {
    /// <param name="flag" type="Boolean">
    /// </param>
    var data = { change_rotation: flag };
    SwitchWidgetJs.Main._setSwitchState(data);
}
SwitchWidgetJs.Main._setGPSState = function SwitchWidgetJs_Main$_setGPSState(flag) {
    /// <param name="flag" type="Boolean">
    /// </param>
    var data = { change_gps: flag };
    SwitchWidgetJs.Main._setSwitchState(data);
}
SwitchWidgetJs.Main._setBrightnessState = function SwitchWidgetJs_Main$_setBrightnessState(automode, level) {
    /// <param name="automode" type="Boolean">
    /// </param>
    /// <param name="level" type="Number" integer="true">
    /// </param>
    var data = { change_brightness_auto: automode, change_brightness_level: level };
    SwitchWidgetJs.Main._setSwitchState(data);
}
SwitchWidgetJs.Main._setSwitchState = function SwitchWidgetJs_Main$_setSwitchState(data) {
    /// <param name="data" type="Object">
    /// </param>
    var options = {};
    options.component = SwitchWidgetJs.Main._settings_service_component;
    options.data = data;
    chameleon.intent(options);
}
SwitchWidgetJs.Main._handleAirplaneModeClick = function SwitchWidgetJs_Main$_handleAirplaneModeClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('airplanemode');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted', function() {
            SwitchWidgetJs.Main._setAirplaneModeState(true);
        });
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled', function() {
            SwitchWidgetJs.Main._setAirplaneModeState(false);
        });
    }
}
SwitchWidgetJs.Main._handleBluetoothClick = function SwitchWidgetJs_Main$_handleBluetoothClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('bluetooth');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted', function() {
            SwitchWidgetJs.Main._setBluetoothState(true);
        });
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled', function() {
            SwitchWidgetJs.Main._setBluetoothState(false);
        });
    }
}
SwitchWidgetJs.Main._handleBrightnessClick = function SwitchWidgetJs_Main$_handleBrightnessClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var options = {};
    options.action = 'android.settings.DISPLAY_SETTINGS';
    chameleon.intent(options);
}
SwitchWidgetJs.Main._handleGPSClick = function SwitchWidgetJs_Main$_handleGPSClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var options = {};
    options.action = 'android.settings.LOCATION_SOURCE_SETTINGS';
    chameleon.intent(options);
}
SwitchWidgetJs.Main._handleLockClick = function SwitchWidgetJs_Main$_handleLockClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('lock');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted');
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled');
    }
}
SwitchWidgetJs.Main._handleNetworkClick = function SwitchWidgetJs_Main$_handleNetworkClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('network');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted');
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled');
    }
}
SwitchWidgetJs.Main._handleRingerClick = function SwitchWidgetJs_Main$_handleRingerClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('ringer');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted');
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled');
    }
}
SwitchWidgetJs.Main._handleRotationClick = function SwitchWidgetJs_Main$_handleRotationClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('rotation');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted', function() {
            SwitchWidgetJs.Main._setRotationState(true);
        });
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled', function() {
            SwitchWidgetJs.Main._setRotationState(false);
        });
    }
}
SwitchWidgetJs.Main._handleSyncClick = function SwitchWidgetJs_Main$_handleSyncClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('sync');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted');
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled');
    }
}
SwitchWidgetJs.Main._handleTimeoutClick = function SwitchWidgetJs_Main$_handleTimeoutClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('timeout');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted');
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled');
    }
}
SwitchWidgetJs.Main._handleVibrateClick = function SwitchWidgetJs_Main$_handleVibrateClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('vibrate');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted');
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled');
    }
}
SwitchWidgetJs.Main._handleWiFiClick = function SwitchWidgetJs_Main$_handleWiFiClick(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    e.preventDefault();
    var switch_type = SwitchWidgetJs.Main._getSwitchByName('wifi');
    if (switch_type.state === 'disabled') {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'highlighted', function() {
            SwitchWidgetJs.Main._setWiFiState(true);
        });
    }
    else {
        SwitchWidgetJs.Main._applySwitchState(switch_type, 'disabled', function() {
            SwitchWidgetJs.Main._setWiFiState(false);
        });
    }
}
SwitchWidgetJs.Main._hasInitSwitches = function SwitchWidgetJs_Main$_hasInitSwitches() {
    /// <returns type="Boolean"></returns>
    return SwitchWidgetJs.Main._switchTypes != null;
}
SwitchWidgetJs.Main._initSwitches = function SwitchWidgetJs_Main$_initSwitches(options) {
    /// <param name="options" type="Object">
    /// </param>
    if (SwitchWidgetJs.Main._switchTypes == null) {
        SwitchWidgetJs.Main._switchTypes = [];
        var test_state = 'disabled';
        if (options['airplanemode'] != null && options['airplanemode'].exists) {
            var airplane_state = 'disabled';
            if (options['airplanemode'].enabled) {
                airplane_state = 'highlighted';
            }
            var airplane = new SwitchWidgetJs.Model.SwitchType();
            airplane.name = 'airplanemode';
            airplane.class = 'switch-airplanemode';
            airplane.caption = 'Airplane Mode';
            airplane.state = airplane_state;
            airplane.onClick = SwitchWidgetJs.Main._handleAirplaneModeClick;
            SwitchWidgetJs.Main._switchTypes.add(airplane);
        }
        if (options['bluetooth'] != null && options['bluetooth'].exists) {
            var bluetooth_state = 'disabled';
            if (options['bluetooth'].enabled) {
                bluetooth_state = 'highlighted';
            }
            var bluetooth = new SwitchWidgetJs.Model.SwitchType();
            bluetooth.name = 'bluetooth';
            bluetooth.class = 'switch-bluetooth';
            bluetooth.caption = 'Bluetooth';
            bluetooth.state = bluetooth_state;
            bluetooth.onClick = SwitchWidgetJs.Main._handleBluetoothClick;
            SwitchWidgetJs.Main._switchTypes.add(bluetooth);
        }
        if (options['brightness'] != null && options['brightness'].exists) {
            var brightness_state = 'off';
            if (options['brightness'].automode) {
                brightness_state = 'auto';
            }
            else if (options['brightness'].level === 255) {
                brightness_state = 'full';
            }
            else if (options['brightness'].level >= 125) {
                brightness_state = 'half';
            }
            var brightness = new SwitchWidgetJs.Model.SwitchType();
            brightness.name = 'brightness';
            brightness.class = 'switch-brightness';
            brightness.caption = 'Brightness';
            brightness.state = brightness_state;
            brightness.onClick = SwitchWidgetJs.Main._handleBrightnessClick;
            SwitchWidgetJs.Main._switchTypes.add(brightness);
        }
        if (options['gps'] != null && options['gps'].exists) {
            var gps_state = 'disabled';
            if (options['gps'].enabled) {
                gps_state = 'highlighted';
            }
            var gps = new SwitchWidgetJs.Model.SwitchType();
            gps.name = 'gps';
            gps.class = 'switch-gps';
            gps.caption = 'GPS';
            gps.state = gps_state;
            gps.onClick = SwitchWidgetJs.Main._handleGPSClick;
            SwitchWidgetJs.Main._switchTypes.add(gps);
        }
        if (options['lock'] != null && options['lock'].exists) {
            var deviceLock = new SwitchWidgetJs.Model.SwitchType();
            deviceLock.name = 'lock';
            deviceLock.class = 'switch-lock';
            deviceLock.caption = 'Lock';
            deviceLock.state = test_state;
            deviceLock.onClick = SwitchWidgetJs.Main._handleLockClick;
            SwitchWidgetJs.Main._switchTypes.add(deviceLock);
        }
        if (options['network'] != null && options['network'].exists) {
            var network = new SwitchWidgetJs.Model.SwitchType();
            network.name = 'network';
            network.class = 'switch-network';
            network.caption = 'Network';
            network.state = test_state;
            network.onClick = SwitchWidgetJs.Main._handleNetworkClick;
            SwitchWidgetJs.Main._switchTypes.add(network);
        }
        if (options['ringer'] != null && options['ringer'].exists) {
            var ringer = new SwitchWidgetJs.Model.SwitchType();
            ringer.name = 'ringer';
            ringer.class = 'switch-ringer';
            ringer.caption = 'Ringer';
            ringer.state = test_state;
            ringer.onClick = SwitchWidgetJs.Main._handleRingerClick;
            SwitchWidgetJs.Main._switchTypes.add(ringer);
        }
        if (options['rotation'] != null && options['rotation'].exists) {
            var rotation_state = 'disabled';
            if (options['rotation'].enabled) {
                rotation_state = 'highlighted';
            }
            var rotation = new SwitchWidgetJs.Model.SwitchType();
            rotation.name = 'rotation';
            rotation.class = 'switch-rotation';
            rotation.caption = 'Rotation';
            rotation.state = test_state;
            rotation.onClick = SwitchWidgetJs.Main._handleRotationClick;
            SwitchWidgetJs.Main._switchTypes.add(rotation);
        }
        if (options['sync'] != null && options['sync'].exists) {
            var sync = new SwitchWidgetJs.Model.SwitchType();
            sync.name = 'sync';
            sync.class = 'switch-sync';
            sync.caption = 'Sync';
            sync.state = test_state;
            sync.onClick = SwitchWidgetJs.Main._handleSyncClick;
            SwitchWidgetJs.Main._switchTypes.add(sync);
        }
        if (options['timeout'] != null && options['timeout'].exists) {
            var timeout = new SwitchWidgetJs.Model.SwitchType();
            timeout.name = 'timeout';
            timeout.class = 'switch-timeout';
            timeout.caption = 'Timeout';
            timeout.state = test_state;
            timeout.onClick = SwitchWidgetJs.Main._handleTimeoutClick;
            SwitchWidgetJs.Main._switchTypes.add(timeout);
        }
        if (options['vibrate'] != null && options['vibrate'].exists) {
            var vibrate = new SwitchWidgetJs.Model.SwitchType();
            vibrate.name = 'vibrate';
            vibrate.class = 'switch-vibrate';
            vibrate.caption = 'Vibrate';
            vibrate.state = test_state;
            vibrate.onClick = SwitchWidgetJs.Main._handleVibrateClick;
            SwitchWidgetJs.Main._switchTypes.add(vibrate);
        }
        if (options['wifi'] != null && options['wifi'].exists) {
            var wifi_state = 'disabled';
            if (options['wifi'].enabled) {
                wifi_state = 'highlighted';
            }
            var wifi = new SwitchWidgetJs.Model.SwitchType();
            wifi.name = 'wifi';
            wifi.class = 'switch-wifi';
            wifi.caption = 'WiFi';
            wifi.state = wifi_state;
            wifi.onClick = SwitchWidgetJs.Main._handleWiFiClick;
            SwitchWidgetJs.Main._switchTypes.add(wifi);
        }
    }
}
SwitchWidgetJs.Main._getSwitchByName = function SwitchWidgetJs_Main$_getSwitchByName(name) {
    /// <param name="name" type="String">
    /// </param>
    /// <returns type="SwitchWidgetJs.Model.SwitchType"></returns>
    SwitchWidgetJs.Main._initSwitches(null);
    var $enum1 = ss.IEnumerator.getEnumerator(SwitchWidgetJs.Main._switchTypes);
    while ($enum1.moveNext()) {
        var switchType = $enum1.current;
        if (!String.isNullOrEmpty(switchType.name) && name === switchType.name) {
            return switchType;
        }
    }
    return null;
}
SwitchWidgetJs.Main._applySwitchState = function SwitchWidgetJs_Main$_applySwitchState(switch_type, new_state, callback) {
    /// <param name="switch_type" type="SwitchWidgetJs.Model.SwitchType">
    /// </param>
    /// <param name="new_state" type="String">
    /// </param>
    /// <param name="callback" type="Function">
    /// </param>
    if (switch_type.state !== new_state) {
        chameleon.invalidate();
        var options = {};
        options.time = 100;
        options.callback = callback;
        var class_state_suffix = '';
        if (switch_type.state != null) {
            class_state_suffix = '-' + switch_type.state;
        }
        var current_class = switch_type.class + class_state_suffix;
        var new_class = switch_type.class + '-' + new_state;
        $('.' + current_class).removeClass('switch-' + switch_type.state).addClass('switch-' + new_state);
        $('.' + current_class).removeClass(current_class).addClass(new_class).chameleonInvalidate(options);
        switch_type.state = new_state;
        chameleon.invalidateTwo();
    }
}
SwitchWidgetJs.Main._drawSwitches = function SwitchWidgetJs_Main$_drawSwitches(options) {
    /// <param name="options" type="Object">
    /// </param>
    SwitchWidgetJs.Main._initSwitches(options);
    var html = '<ul class="switches-list">';
    var $enum1 = ss.IEnumerator.getEnumerator(SwitchWidgetJs.Main._switchTypes);
    while ($enum1.moveNext()) {
        var switch_type = $enum1.current;
        var class_state_suffix = '';
        if (switch_type.state != null) {
            class_state_suffix = '-' + switch_type.state;
        }
        html += '<li class="' + switch_type.class + class_state_suffix + ' switch' + class_state_suffix + '">';
        html += '<div class="icon">';
        html += '</div>';
        html += '<div class="caption">';
        html += '<p>' + switch_type.caption.toUpperCase() + '</p>';
        html += '</div>';
        html += '</li>';
    }
    html += '</ul>';
    $('#chameleon-widget').html(html);
    var $enum2 = ss.IEnumerator.getEnumerator(SwitchWidgetJs.Main._switchTypes);
    while ($enum2.moveNext()) {
        var switch_type = $enum2.current;
        if (switch_type.onClick != null) {
            var class_state_suffix = '';
            if (switch_type.state != null) {
                class_state_suffix = '-' + switch_type.state;
            }
            $('.' + switch_type.class + class_state_suffix).click(switch_type.onClick);
        }
    }
}
SwitchWidgetJs.Main._launchGlobalSettings = function SwitchWidgetJs_Main$_launchGlobalSettings(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    if (e != null) {
        e.preventDefault();
    }
    var options = {};
    options.action = 'android.settings.SETTINGS';
    chameleon.intent(options);
}


SwitchWidgetJs.Model.SwitchType.registerClass('SwitchWidgetJs.Model.SwitchType');
SwitchWidgetJs.Main.registerClass('SwitchWidgetJs.Main');
SwitchWidgetJs.Main._settings_service_component = {};
SwitchWidgetJs.Main._root = null;
SwitchWidgetJs.Main._switchTypes = null;
(function () {
    SwitchWidgetJs.Main._settings_service_component.name = 'com.teknision.android.chameleon.settingsswitchservice.SettingsService';
    SwitchWidgetJs.Main._settings_service_component.package = 'com.chameleonlauncher.preorder';
    SwitchWidgetJs.Main._settings_service_component.type = 'service';
    SwitchWidgetJs.Main._root = $('#chameleon-widget');
    $(function() {
        var wop = {};
        wop.onLoad = function() {
            if (SwitchWidgetJs.Main._dependencyExists()) {
                SwitchWidgetJs.Main._updateSwitchStates();
            }
            else {
                SwitchWidgetJs.Main._displayNoDependencyError();
            }
        };
        wop.onResume = function() {
            if (SwitchWidgetJs.Main._dependencyExists()) {
                SwitchWidgetJs.Main._updateSwitchStates();
            }
            else {
                SwitchWidgetJs.Main._displayNoDependencyError();
            }
        };
        wop.onTitleBar = function() {
            $('#chameleon-widget').append('we are live');
            SwitchWidgetJs.Main._launchGlobalSettings(null);
        };
        wop.notChameleon = function() {
            SwitchWidgetJs.Main._drawSwitches(null);
        };
        chameleon.widget(wop);
    });
})();
})(jQuery);

//! This script was generated using Script# v0.7.4.0
