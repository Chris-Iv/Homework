function sortArray(input) {
    var min = 0;
    for (var i = 0; i < input.length; i++) {
        min = i;
        for (j = i+1; j < input.length; j++) {
            if (input[j] < input[i]) {
                min = j;
            }
        }
        if (i != min) {
            var temp = input[i];
            input[i] = input[min];
            input[min] = temp;
        }
    }
    var result = input.join(', ');
    console.log(result);
}
sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);