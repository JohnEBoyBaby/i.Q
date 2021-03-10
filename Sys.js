"use strict";
if(typeof(window.WebSocket) == undefined
|| typeof(window.Worker) == undefined) {
    alert("Sweetheart, please upgrade to a modern web browser with support for the new ws:// and wss:// WebSockets protocols and javascript's new Worker object, a simulated form of 'background worker' threading. Thank you, babe. Respectfully, John @Smart3DWeb 'Make a way'");
}
else {
    var Sys = (function (url) {
        var Data = {};
        var Drawing = {};
        var Function = {};
        var Global = {};
        var Net = {};
        var String = {};
        var Threading = {};
        var Url = url;
        var Web = {};
        return {
            Data: Data,
            Drawing: Drawing,
            Function: Function,
            Global: Global,
            Net: Net,
            String: String,
            Threading: Threading,
            Url: Url,
            Web: Web
        };
    }("ws://127.0.0.1:12868"));
}
