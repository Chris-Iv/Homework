function Solve(input) {
    var words = input[0].split(' ');
    var maxLength = 0;
    for (var i = 0; i < words.length; i++) {
        if (maxLength < words[i].length) {
            maxLength = words[i].length;
        }
    }
    for (var i = 0; i < words.length; i++) {
        words[i] = words[i].split('');
    }
    var letters = '';
    for (var lett = 0; lett < maxLength; lett++) {
        for (var index = 0; index < words.length; index++) {
            if (words[index].length > 0) {
                letters += words[index].pop();
            }
        }
    }
    letters = letters.split('');
    for (var i = 0; i < letters.length; i++) {
        var numMoves = letters[i].toLowerCase().charCodeAt(0) - 96;
        var newPosition = (numMoves + i) % letters.length;
        var currChar = letters[i];
        letters.splice(i,1);
        letters.splice(newPosition,0,currChar);
    }
    console.log(letters.join(''));
}
Solve(['Fun exam right']);
Solve(['Hi exam']);