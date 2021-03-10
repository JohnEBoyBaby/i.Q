Sys.Function = {
    Test: function (message) { 
        var callbackFunctionArgsArray = [];
        var json = Sys.Function.Argument("testArgumentName", "string", "Hello World from Javascript's FunktionCallback.apply(null,args)");
        var argument = JSON.parse(json);
        var args = Sys.Function.Arguments(callbackFunctionArgsArray, argument);
        return args;
    },
    TestWorker: function (funktion) {
        //A task as a Worker cannot call another function so the below function call will fail
        var json = "{"//\r\n" +
            + " \"name\":\"" + "testArgumentName" + "\","//"',\r\n"
            + " \"type\":\"" + "string" + "\","//"',\r\n" //undefined,null,u|boolean,b,boolean[],b[]|date,d,date[],d[]|number,n,number[],n[]|string,s,string[],s[]
            + " \"value\":\"" + "Hello World from Javascript's FunktionCallback.apply(null,args)" + "\""//"'\r\n"
            + "}";
        var array = [];
        var argument = JSON.parse(json);
        array.push(argument);
        json = "{"//\r\n" +
            + " \"name\":\"" + "testArgumentName2" + "\","//"',\r\n"
            + " \"type\":\"" + "string" + "\","//"',\r\n" //undefined,null,u|boolean,b,boolean[],b[]|date,d,date[],d[]|number,n,number[],n[]|string,s,string[],s[]
            + " \"value\":\"" + "Hello World2 from Javascript's FunktionCallback.apply(null,args)" + "\""//"'\r\n"
            + "}";
        argument = JSON.parse(json);
        array.push(argument);
        return array;
    },
//TODO: change args to funktion so that functions callback with a funktion not an args[]
    TestCallback: function (funktion) {
        alert(JSON.stringify(funktion));
    },
    Funktion: function(name, args, callback) {
        var json = "{"//\r\n" +
               + " \"name\":\"" + name + "\","//"',\r\n"
               + " \"args\":" + args + ","//",\r\n" //undefined,null,u|boolean,b,boolean[],b[]|date,d,date[],d[]|number,n,number[],n[]|string,s,string[],s[]
               + " \"callback\":\"" + callback + "\""//"'\r\n"
               + "}";
        var funktion = JSON.parse(json);
        return funktion;
        
    },
    Argument: function (name, type, value) {
        var json = "{"//\r\n" +
               + " \"name\":\"" + name + "\","//"',\r\n"
               + " \"type\":\"" + type + "\","//"',\r\n" //undefined,null,u|boolean,b,boolean[],b[]|date,d,date[],d[]|number,n,number[],n[]|string,s,string[],s[]
               + " \"value\":\"" + value + "\""//"'\r\n"
               + "}";
        return json;
    },
    Arguments: function (array, argument) {
        array.push(argument);
        return array;
    },
    Args: function (funktion) {
        //NOTE: javascript's <FunctionNameHere>.apply(null, args) function requires args be an array.
        var args = [];
        var array = [];
        for(var i=0; i<funktion.args.length; i++) {
            if(undefined == funktion.args[i].type
            || null == funktion.args[i].type) {
                throw "Sys.Function.Arg's input argument type does not exist, is null or undefined.";
            }
            if(funktion.args[i].type == "null"
            || funktion.args[i].type == "undefined"
            || funktion.args[i].type.substr(0, 1) == "u" ) {
                args.push(null);
            }
            else if(funktion.args[i].type == "boolean"
            || funktion.args[i].type.substr(0,1) == "b" ) {
                args.push(new Boolean(funktion.args[i].value));
            }
            else if(funktion.args[i].type == "boolean[]"
            || funktion.args[i].type.substr(0,2) == "b[" ) {
                for(var b=0; a<funktion.args[i][b].length; b++) {
                    array.push(new Boolean(funktion.args[i][b].value));
                }
                args.push(array);
            }
            else if(funktion.args[i].type == "date" /*new Date("2017-12-25T23:59:59Z");*/
            || funktion.args[i].type.substr(0,1) == "d" ) {
                args.push(new Date(funktion.args[i].value));
            }
            else if(funktion.args[i].type == "date[]"
            || funktion.args[i].type.substr(0,2) == "d[" ) {
                for(var d=0; d<funktion.args[i][d].length; d++) {
                    array.push(new Date(funktion.args[i][d].value));
                }
                args.push(array);
            }
            else if(funktion.args[i].type == "number"
            || funktion.args[i].type.substr(0,1) == "n" ) {
                args.push(new Number(funktion.args[i].value));
            }
            else if(funktion.args[i].type == "number[]"
            || funktion.args[i].type.substr(0,2) == "n[" ) {
                for(var n=0; n<funktion.args[i][n].length; n++) {
                    array.push(new Number(funktion.args[i][n].value));
                }
                args.push(array);
            }
            else if(funktion.args[i].type == "string"
            || funktion.args[i].type.substr(0,1) == "s" ) {
                args.push(funktion.args[i].value);
            }
            else if(funktion.args[i].type == "string[]"
            || funktion.args[i].type.substr(0,2) == "s[" ) {
                for(var s=0; s<funktion.args[i][s].length; s++) {
                    array.push(funktion.args[i][s].value);
                }
                args.push(array);
            }
            else {
                throw ("Sys.Function.Arg's input argument type is unknown.");
            }
        }
        return args;
   },
   GetFunctionFromString: function(functionName) {
        //ref: https://stackoverflow.com/questions/912596/how-to-turn-a-string-into-a-javascript-function-call
        var scope = window;
        var scopeSplit = functionName.split(".");
        for (i = 0; i < scopeSplit.length - 1; i++) {
            scope = scope[scopeSplit[i]];
            if (scope == undefined) {
                return;
            }
        }
        return scope[scopeSplit[scopeSplit.length - 1]];
    },
    JsToCs: function (json) {
        var event = new MessageEvent("Sys.Function.JsToCs", {//geckoWebBrowser.AddMessageEventListener("JsToCs",//has to match exactly, case-sensitive, the name of this javascript function: JsToCS, notice there is no mention of the function argument, json, that the javascript function
                        "view": window,//note:window is a special "keyword" referring the current "window" this code is running in
                        "bubbles": false,//this says that if we don"t handle this event that we want to pass the event up the chain or not and this time we don"t want to pass this event so we set bubbles to false instead of true
                        "cancelable": false,//no need to worry about cancelling this event right in the middle of its runtime execution so set cancelable to false
                        "data": json //turn the json object named command into its plain text utf-8 encoded form that includes all known characters of all human history from our modern a-z, 0-9, and icons to all the other languages ever used during the course of all human history including ancient kanji and heiroglyphic pictographs.
                    });
        //document.dispatchEvent(event); will call the C# GeckoFX GeckoWebBrowser function public System.String JsToCs(System.String json) {...}
        document.dispatchEvent(event);
    },
    Call: function (funktion) {
        //Sys.Function.GetFunctionFromString works for all functions including those nested in modules (e.g. Sys.Function.Test) ... window[functionName] will not work for nested scoped functions like Sys.Function.Test)
        var Funktion = Sys.Function.GetFunctionFromString(funktion.name);
        if (typeof Funktion === "function") {
            var args = Sys.Function.Args(funktion);
            var result = Funktion.apply (null, args);
            funktion = Sys.Function.Funktion(funktion.callback,JSON.stringify(result),Sys.String.Empty);
            args = [];
            args.push(funktion);
            Funktion = Sys.Function.GetFunctionFromString(funktion.name);
            if (typeof Funktion === "function") {
                Funktion.apply(null, args);
            }
        }
        else {
            throw ("Sys.Function.Call could not instantiate Function dynamically.");
        }
    }
};