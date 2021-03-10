Sys.Global = {
    Application_Start: function() {
        try {
            document.getElementById("form").addEventListener("submit", function(event){ 
                Sys.Net.Send(event) 
            });
            Sys.Net.Connect();                                
            window.setTimeout(function(){ setInterval(Sys.Net.Reconnect, 5000) }, 10000);
            document.getElementById("button1").addEventListener("click", function() {

                var arg = Sys.Function.Argument("testName", "string", "hello world from C#");
                var args = [];
                args.push(JSON.parse(arg));
                var funktion = Sys.Function.Funktion("Sys.Function.Test",JSON.stringify(args),"Sys.Function.TestCallback");
                Sys.Function.Call(funktion);
            });
            document.getElementById("button2").addEventListener("click", function() {

                var args = [];
                var funktion = Sys.Function.Funktion("Sys.Function.TestWorker",JSON.stringify(args),"Sys.Function.TestCallback");
                Sys.Threading.Task(funktion);
            });
        }
        catch(exception) {
            Sys.Global.Application_Error(exception);
        }
    },
    Application_Error : function(exception){ 
        alert(exception);
    }
};