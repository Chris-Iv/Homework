function findMaxSequence(input) {
    var result = [];
    var longest = 1;
    var temp = 1;
    var number = input[0];
    for (var i = 1; i < input.length; i++) {
        if (input[i-1] === input[i]) {
            temp++;
            if (temp >= longest) {
                longest = temp;
                number = input[i];
            }
        } else {
            temp = 1;
        }
    }
    for (var i = 0; i < longest; i++) {
        result.push(number);
    }
    console.log(result);
}
findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);