function divisionBy3(number) {
    var sum = 0;
    while (number > 0) {
        sum += number % 10;
        number = Math.floor(number / 10);
    }
    if (sum % 3 == 0) {
        console.log("the number is divided by 3 without remainder");
    } else {
        console.log("the number is not divided by 3 without remainder");
    }
}
divisionBy3(12);
divisionBy3(188);
divisionBy3(591);