function findMaxSequence(input) {
    var maxSequence = 1;
    var tempSequence = 1;
    var result = [];
    var start = 0;
    var end = 0;
    for (var i = 1; i < input.length; i++) {
        if (input[i-1] < input[i]) {
            tempSequence++;
        } else {
            tempSequence = 1;
        }
        if (maxSequence <= tempSequence) {
            maxSequence = tempSequence;
            end = i;
            start = i - maxSequence + 1;
        }
    }
    if (maxSequence < 2) {
        console.log('no');
    } else {
        for (var i = start; i <= end; i++) {
            result.push(input[i]);
        }
        console.log(result);
    }
}
findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);