function createArray() {
    var numbers = new Array(20);
    for (var i = 0; i < 20; i++) {
        numbers[i] = i * 5;
    }
    console.log(numbers);
}
createArray();