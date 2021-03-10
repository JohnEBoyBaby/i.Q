Sys.Threading = {
    Task: function(funktion) {
        var Funktion = Sys.Function.GetFunctionFromString(funktion.name);
        if (typeof Funktion === "function") {
            var Call = task.wrap(Funktion); 
            var args = [];
            Call(funktion).then(function(result){
                funktion = Sys.Function.Funktion(funktion.callback,JSON.stringify(result),Sys.String.Empty);
                Funktion = Sys.Function.GetFunctionFromString(funktion.name);
                args.push(funktion);
                if (typeof Funktion === "function") {
                    Funktion.apply(null, args);
                }
            });
        }
    }
};
