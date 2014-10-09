function checkBrackets(input) {
    var count = 0;
    for (var br in input) {
        if (input[br] == '(') {
            count++;
        } else if (input[br] == ')') {
            count--;
        }
        if (count < 0) {
            break;
        }
    }
    if (count == 0) {
        console.log('correct');
    } else {
        console.log('incorrect');
    }
}
checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');