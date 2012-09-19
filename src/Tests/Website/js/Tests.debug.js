//! Tests.debug.js
//

(function($) {

Type.registerNamespace('Tests');

////////////////////////////////////////////////////////////////////////////////
// Tests.Main

Tests.Main = function Tests_Main() {
}


Tests.Main.registerClass('Tests.Main');
(function () {
    $(function() {
        var _root = $('#chameleon-widget');
        var wop = {};
        wop.onLoad = function() {
            _root.append('<div>widget loaded...</div>');
        };
        wop.onCreate = function() {
            _root.append('<div>widget created...</div>');
        };
        wop.onResume = function() {
            _root.append('<div>widget resumed...</div>');
        };
        wop.onPause = function() {
            _root.append('<div>widget paused...</div>');
        };
        wop.onLayout = function() {
            _root.append('<div>widget size changed...</div>');
        };
        wop.onScrollTop = function() {
            _root.append('<div>widget scrolled to top...</div>');
        };
        wop.onScrollElsewhere = function() {
            _root.append('<div>widget scrolled...</div>');
        };
        wop.onLayoutModeStart = function() {
            _root.append('<div>widget layout mode started...</div>');
        };
        wop.onLayoutModeComplete = function() {
            _root.append('<div>widget layout mode complete...</div>');
        };
        wop.onConnectionAvailableChanged = function(available) {
            _root.append('<div>widget connection status changed to ' + available + ' ...</div>');
        };
        wop.onConfigure = function() {
            _root.append('<div>widget entered configure mode...</div>');
        };
        wop.onTitleBar = function() {
            _root.append('<div>widget title clicked...</div>');
            var options = {};
            options.url = 'settings.html';
            options.height = 200;
            options.width = 300;
            options.result = function(success, data) {
                _root.append('result from window ' + success);
            };
            chameleon.promptHTML(options);
        };
        wop.onRefresh = function() {
            _root.html('<div>widget refreshed...</div>');
            _root.append('<div>connection status: ' + chameleon.connected() + '</div>');
            _root.append('<div>layout mode status: ' + chameleon.isInLayoutMode() + '</div>');
            var firstLoadOptions = {};
            firstLoadOptions.showloader = true;
            chameleon.showLoading(firstLoadOptions);
            window.setTimeout(function() {
                var lo = {};
                lo.showloader = false;
                chameleon.showLoading(lo);
            }, 2000);
        };
        wop.notChameleon = function() {
            _root.append('<div>widget loaded outside of Chameleon...</div>');
        };
        chameleon.widget(wop);
    });
})();
})(jQuery);

//! This script was generated using Script# v0.7.4.0
