function compareChars(first, second) {
    var result = 'Equal';
    if (first.length == second.length) {
        for (var i = 0; i < first.length; i++) {
            if (first[i] != second[i]) {
                result = 'Not Equal';
                break;
            }
        }
    } else {
        result = 'Not Equal';
    }
    console.log(result);
}
compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'], ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']);
compareChars(['3', '5', 'g', 'd'], ['5', '3', 'g', 'd']);
compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'], ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']);