function Solve(input) {
    var text = input[0];
    var words = text.split(/[^A-Za-z]+/);
    words = words.filter(Boolean);
    var result = [];
    for (var a = 0; a < words.length; a++) {
        for (var b = 0; b < words.length; b++) {
            for (var c = 0; c < words.length; c++) {
                if (a !== b) {
                    var check = words[a] + words[b] === words[c];
                    if (check) {
                        var cognated = words[a] + '|' + words[b] + '=' + words[c];
                        if (result.indexOf(cognated) < 0) {
                            result.push(cognated);
                        }
                    }
                }
            }
        }
    }
    if (result.length < 1) {
        console.log('No');
    } else {
        console.log(result.join('\n'));
    }
}
Solve(['java..?|basics/*-+=javabasics']);
Solve(['Hi, Hi, Hihi']);
Solve(['Uni(lo,.ve=I love SoftUni (Soft)']);
Solve(['a a aa a']);
Solve(['x a ab b aba a hello+java a b aaaaa']);
Solve(['aa bb bbaa']);
Solve(['ho hoho']);