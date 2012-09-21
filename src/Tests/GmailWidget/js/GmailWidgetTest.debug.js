//! GmailWidgetTest.debug.js
//

(function($) {

Type.registerNamespace('GmailWidgetTest');

////////////////////////////////////////////////////////////////////////////////
// GmailWidgetTest.Index

GmailWidgetTest.Index = function GmailWidgetTest_Index() {
    /// <field name="_refresH_TIMESPAN" type="Number" integer="true" static="true">
    /// </field>
    /// <field name="_current_account" type="Object" static="true">
    /// </field>
    /// <field name="_last_update_call" type="Number" integer="true" static="true">
    /// </field>
    /// <field name="_root" type="jQueryObject" static="true">
    /// </field>
}
GmailWidgetTest.Index._updateFeedIfWithinTimespan = function GmailWidgetTest_Index$_updateFeedIfWithinTimespan() {
    if (GmailWidgetTest.Index._current_account != null) {
        if (GmailWidgetTest.Index._last_update_call !== -1) {
            var now = Date.get_now().getDate();
            if (now > (GmailWidgetTest.Index._last_update_call + 60000)) {
                GmailWidgetTest.Index._loadEmailFeed();
            }
        }
    }
}
GmailWidgetTest.Index._loadFeed = function GmailWidgetTest_Index$_loadFeed() {
    GmailWidgetTest.Index._stopPolling();
    if (!GmailWidgetTest.Index._loadFeedForSelectedAccount()) {
        if (!GmailWidgetTest.Index._loadDefaultFeed()) {
            if (chameleon.connected()) {
                GmailWidgetTest.Index._displayNoFeedMessage();
                chameleon.initialize();
            }
            else {
                GmailWidgetTest.Index._displayOfflineMessage();
                chameleon.initialize();
            }
        }
    }
}
GmailWidgetTest.Index._loadDefaultFeed = function GmailWidgetTest_Index$_loadDefaultFeed() {
    /// <returns type="Boolean"></returns>
    var r = false;
    var shared_data = chameleon.getSharedData();
    if (shared_data == null) {
        shared_data = {};
    }
    if (shared_data.accounts == null) {
        shared_data.accounts = [];
    }
    var account = null;
    if ((shared_data.accounts).length > 0) {
        account = (shared_data.accounts)[0];
        if (GmailWidgetTest.Index._current_account == null || account.secret !== GmailWidgetTest.Index._current_account.secret) {
            GmailWidgetTest.Index._current_account = account;
            GmailWidgetTest.Index._loadEmailFeed();
        }
        r = true;
    }
    return r;
}
GmailWidgetTest.Index._loadFeedForSelectedAccount = function GmailWidgetTest_Index$_loadFeedForSelectedAccount() {
    /// <returns type="Boolean"></returns>
    var r = false;
    var data = chameleon.getSharedData();
    if (data != null && data.account_to_load != null) {
        var shared_data = chameleon.getSharedData();
        if (shared_data == null) {
            shared_data = {};
        }
        if (shared_data.accounts == null) {
            shared_data.accounts = [];
        }
        var account = null;
        for (var i = 0; i < (shared_data.accounts).length; i++) {
            if ((shared_data.accounts)[i].email === data.account_to_load) {
                account = (shared_data.accounts)[i];
                r = true;
                break;
            }
        }
        if (account != null && (GmailWidgetTest.Index._current_account == null || account.secret !== GmailWidgetTest.Index._current_account.secret)) {
            GmailWidgetTest.Index._current_account = account;
            GmailWidgetTest.Index._loadEmailFeed();
        }
    }
    return r;
}
GmailWidgetTest.Index._displayNoFeedMessage = function GmailWidgetTest_Index$_displayNoFeedMessage() {
    var options = {};
    options.title = 'Register Your Account';
    chameleon.invalidate();
    if (chameleon.isInLayoutMode()) {
        options.caption = 'Tap the gear in the top right to register your Gmail Account and display unread messages from your inbox in this widget.';
        options.noicon = true;
        GmailWidgetTest.Index._root.chameleonWidgetConfigureHTML(options);
        GmailWidgetTest.Index._root.chameleonInvalidate();
    }
    else {
        options.caption = 'Tap here to register your Gmail Account and display unread messages from your inbox in this widget.';
        GmailWidgetTest.Index._root.chameleonWidgetConfigureHTML(options);
        GmailWidgetTest.Index._root.chameleonInvalidate();
    }
}
GmailWidgetTest.Index._displayNoUnreadMessagesMessages = function GmailWidgetTest_Index$_displayNoUnreadMessagesMessages() {
    chameleon.invalidate();
    var options = {};
    options.icon = 'images/inbox_ninja.png';
    options.title = 'No un-read email';
    options.caption = "Guess you're an inbox ninja.";
    GmailWidgetTest.Index._root.chameleonWidgetMessageHTML(options);
    GmailWidgetTest.Index._root.chameleonInvalidate();
}
GmailWidgetTest.Index._displayOfflineMessage = function GmailWidgetTest_Index$_displayOfflineMessage() {
    chameleon.invalidate();
    GmailWidgetTest.Index._root.chameleonWidgetNeedWiFiHTML();
    GmailWidgetTest.Index._root.chameleonInvalidate();
}
GmailWidgetTest.Index._displayError = function GmailWidgetTest_Index$_displayError(message) {
    /// <param name="message" type="String">
    /// </param>
    GmailWidgetTest.Index._root.html(message);
}
GmailWidgetTest.Index._clearContent = function GmailWidgetTest_Index$_clearContent() {
    GmailWidgetTest.Index._root.html('');
}
GmailWidgetTest.Index._launchSettings = function GmailWidgetTest_Index$_launchSettings(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    if (e != null) {
        e.preventDefault();
    }
    var options = {};
    options.url = 'settings.html';
    options.result = function(success, data) {
        if (success) {
            GmailWidgetTest.Index._loadFeed();
        }
    };
    chameleon.promptHTML(options);
}
GmailWidgetTest.Index._drawMessages = function GmailWidgetTest_Index$_drawMessages(messages) {
    /// <param name="messages" type="Array">
    /// </param>
    var str = '';
    if (messages != null && messages.length > 0) {
        var $enum1 = ss.IEnumerator.getEnumerator(messages);
        while ($enum1.moveNext()) {
            var message = $enum1.current;
            str += GmailWidgetTest.Index._getEmailHTMLFromEntry(message);
        }
    }
    GmailWidgetTest.Index._root.html(str);
    chameleon.invalidate();
    GmailWidgetTest.Index._root.chameleonInvalidate();
    GmailWidgetTest.Index._primeMailLinks();
    chameleon.initialize();
}
GmailWidgetTest.Index._getEmailHTMLFromEntry = function GmailWidgetTest_Index$_getEmailHTMLFromEntry(message) {
    /// <param name="message" type="Object">
    /// </param>
    /// <returns type="String"></returns>
    var r = '';
    var time_since_string = chameleon.get_chameleonInstance().timesince(message.created);
    r += "<div class='email-listing' id='" + message.id + "'>";
    r += "<img src='images/gmail_unread_email.png' class='unread-email-icon' />";
    if (message.url != null) {
        r += "<a href='" + message.url + "' class='email-listing-title-link'>";
    }
    r += "<p class='email-listing-title'>" + message.title + '</p>';
    if (message.url != null) {
        r += '</a>';
    }
    r += "<p class='email-listing-from'>" + message.author_email + '</p>';
    r += "<p class='email-listing-created'>" + time_since_string + '</p>';
    r += "<p class='email-listing-summary'>" + message.summary + '</p>';
    r += '</div>';
    return r;
}
GmailWidgetTest.Index._startPolling = function GmailWidgetTest_Index$_startPolling() {
    var pOptions = {};
    pOptions.id = 'feed_refresh';
    pOptions.action = 'start';
    pOptions.interval = GmailWidgetTest.Index._refresH_TIMESPAN;
    pOptions.callback = GmailWidgetTest.Index._loadEmailFeed;
    chameleon.get_chameleonInstance().poll(pOptions);
}
GmailWidgetTest.Index._stopPolling = function GmailWidgetTest_Index$_stopPolling() {
    var options = { id: 'feed_refresh', action: 'stop' };
    chameleon.get_chameleonInstance().poll(options);
}
GmailWidgetTest.Index._primeMailLinks = function GmailWidgetTest_Index$_primeMailLinks() {
    $('.email-listing-title-link').die('click', GmailWidgetTest.Index._launchMail).live('click', GmailWidgetTest.Index._launchMail);
}
GmailWidgetTest.Index._launchMail = function GmailWidgetTest_Index$_launchMail(e) {
    /// <param name="e" type="jQueryEvent">
    /// </param>
    if (e != null) {
        e.preventDefault();
    }
    var url = '';
    if (e != null && e.currentTarget != null) {
        url = e.currentTarget.toString();
    }
    var cOptions = {};
    cOptions.package = 'com.google.android.gm';
    cOptions.name = 'com.google.android.gm.ConversationListActivityGmail';
    if (chameleon.componentExists(cOptions) || (url == null || !url)) {
        var iOptions = {};
        iOptions.component = cOptions;
        iOptions.action = 'android.intent.action.MAIN';
        chameleon.intent(iOptions);
    }
    else {
        var iOptions = {};
        iOptions.action = 'android.intent.action.VIEW';
        iOptions.data = url;
        chameleon.intent(iOptions);
    }
}
GmailWidgetTest.Index._loadEmailFeed = function GmailWidgetTest_Index$_loadEmailFeed() {
    if (GmailWidgetTest.Index._current_account != null) {
        var inst_data = chameleon.getData();
        if (inst_data == null) {
            inst_data = {};
        }
        var tOptions = {};
        tOptions.text = 'UNREAD MESSAGES: ' + (GmailWidgetTest.Index._current_account.email).toUpperCase();
        chameleon.setTitle(tOptions);
        if (chameleon.connected()) {
            GmailWidgetTest.Index._last_update_call = Date.get_now().getDate();
            var qdata = {};
            qdata['token'] = GmailWidgetTest.Index._current_account.token;
            qdata['secret'] = GmailWidgetTest.Index._current_account.secret;
            var lOptions = {};
            lOptions.showloader = true;
            chameleon.showLoading(lOptions);
            var ajaxOptions = {};
            ajaxOptions.url = 'services/getmail.php';
            ajaxOptions.data = JSON.stringify(qdata);
            ajaxOptions.dataType = 'xml';
            ajaxOptions.timeout = 5000;
            ajaxOptions.success = function(data, textStatus, request) {
                lOptions.showloader = false;
                chameleon.showLoading(lOptions);
                GmailWidgetTest.Index._clearContent();
                var messages = [];
                var context = $(data);
                context.find('feed > entry').each(function(index, element) {
                    var message = {};
                    message.id = $(this).find('id').text();
                    message.title = $(this).find('title').text();
                    message.author_email = $(this).find('author > email').text();
                    message.url = $(this).find('url').text();
                    message.created = $(this).find('issued').text();
                    message.summary = $(this).find('summary').text();
                    messages.add(message);
                });
                if (messages.length > 0) {
                    GmailWidgetTest.Index._drawMessages(messages);
                    chameleon.saveLocalData('cached_messages', messages);
                }
                else {
                    GmailWidgetTest.Index._clearContent();
                    GmailWidgetTest.Index._displayNoUnreadMessagesMessages();
                    chameleon.initialize();
                }
                GmailWidgetTest.Index._startPolling();
            };
            ajaxOptions.error = function(req, txtStatus, error) {
                lOptions.showloader = false;
                chameleon.showLoading(lOptions);
                GmailWidgetTest.Index._startPolling();
            };
            $.ajax(ajaxOptions);
        }
        else {
            var local_data = chameleon.getLocalData('cached_messages');
            if (local_data != null) {
                GmailWidgetTest.Index._drawMessages(local_data);
            }
            else {
                GmailWidgetTest.Index._displayOfflineMessage();
            }
        }
    }
    else {
        GmailWidgetTest.Index._stopPolling();
    }
}


GmailWidgetTest.Index.registerClass('GmailWidgetTest.Index');
GmailWidgetTest.Index._refresH_TIMESPAN = 60000 * 5;
GmailWidgetTest.Index._current_account = null;
GmailWidgetTest.Index._last_update_call = -1;
GmailWidgetTest.Index._root = null;
(function () {
    $(function() {
        GmailWidgetTest.Index._root = $('#chameleon-widget');
        var widget = {};
        widget.onLoad = function() {
            GmailWidgetTest.Index._loadFeed();
        };
        widget.onScrollTop = function() {
            if (GmailWidgetTest.Index._current_account != null && chameleon.connected()) {
                GmailWidgetTest.Index._updateFeedIfWithinTimespan();
                GmailWidgetTest.Index._startPolling();
            }
        };
        widget.onScrollElsewhere = function() {
            GmailWidgetTest.Index._stopPolling();
        };
        widget.onLayoutModeStart = function() {
            if (GmailWidgetTest.Index._current_account != null) {
                GmailWidgetTest.Index._stopPolling();
            }
            else {
                if (chameleon.connected()) {
                    GmailWidgetTest.Index._displayNoFeedMessage();
                }
                else {
                    GmailWidgetTest.Index._displayOfflineMessage();
                }
            }
        };
        widget.onLayoutModeComplete = function() {
            if (GmailWidgetTest.Index._current_account != null) {
                GmailWidgetTest.Index._startPolling();
                GmailWidgetTest.Index._updateFeedIfWithinTimespan();
            }
            else {
                if (chameleon.connected()) {
                    GmailWidgetTest.Index._displayNoFeedMessage();
                }
                else {
                    GmailWidgetTest.Index._displayOfflineMessage();
                }
            }
        };
        widget.onConnectionAvailableChanged = function(available) {
            if (available) {
                if (GmailWidgetTest.Index._current_account != null) {
                    GmailWidgetTest.Index._loadEmailFeed();
                }
                else {
                    GmailWidgetTest.Index._loadFeed();
                }
            }
            else {
                GmailWidgetTest.Index._stopPolling();
                if (GmailWidgetTest.Index._current_account == null) {
                    GmailWidgetTest.Index._displayOfflineMessage();
                }
            }
        };
        widget.onConfigure = function() {
            GmailWidgetTest.Index._stopPolling();
            GmailWidgetTest.Index._launchSettings(null);
        };
        widget.onTitleBar = function() {
            GmailWidgetTest.Index._launchMail(null);
        };
        widget.onRefresh = function() {
            if (GmailWidgetTest.Index._current_account != null) {
                GmailWidgetTest.Index._loadEmailFeed();
            }
        };
        chameleon.widget(widget);
    });
})();
})(jQuery);

//! This script was generated using Script# v0.7.4.0
