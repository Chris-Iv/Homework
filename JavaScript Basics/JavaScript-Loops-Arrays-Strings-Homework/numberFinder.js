function findMostFreqNum(entry) {
    var input = entry;
    var temp = 1;
    var max = 1;
    var number = 0;
    var tempNumber = 0;
    input.sort(function(a, b) { return a - b });
    for (var i = 1; i < input.length; i++) {
        tempNumber = input[i];
        if (input[i-1] === input[i]) {
            temp++;
        } else {
            temp = 1;
        }
        if (temp > max) {
            max = temp;
            number = input[i];
        }
    }
    if (max < 2) {
        console.log(entry[0] + ' (' + '1 times)');
    } else {
        console.log(number + ' (' + max + ' times)');
    }
}
findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);