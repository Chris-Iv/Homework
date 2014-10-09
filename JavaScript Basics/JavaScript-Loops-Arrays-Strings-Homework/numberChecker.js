function printNumbers(n) {
    var result = "1";
    if (n < 2) {
        console.log("no");
    } else {
        for (var i = 2; i <= n; i++) {
            if ((i % 4 == 0) || (i % 5 == 0)) {
                continue;
            } else {
                result = result + ", " + i.toString();
            }
        }
        console.log(result);
    }
}
printNumbers(20);
printNumbers(-5);
printNumbers(13);