function parameterless() {
    console.log("Number of arguments: " + arguments.length);
    
    for (var i = 0; i < arguments.length; i++) {
        console.log("Argument " + (i + 1) + "- " + typeof arguments[i]);
    }
}

var func = function() {
    var obj = {};
    obj.name = "Ivan";
    return obj;
};


parameterless(1234, "gosho", func().name);
parameterless("Pesho", "Gosho", "Tosho");
parameterless(12345555, "gosho");
parameterless(this);
parameterless.call(null, 1234, "Gosho");
parameterless.apply(null, [1234, "Gosho"]);