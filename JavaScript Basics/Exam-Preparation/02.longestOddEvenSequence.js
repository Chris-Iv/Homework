function Solve(input) {
    var numbers = input[0].split(/[ ()]+/);
    numbers = numbers.filter(Boolean);
    var counter = 0;
    var maxCounter = 0;
    var firstOdd = numbers[0] % 2 != 0;
    for (var i = 0; i < numbers.length; i++) {
        var isOdd = numbers[i] % 2 != 0;
        if (firstOdd == isOdd || numbers[i] == 0) {
            counter++;
        } else {
            counter = 1;
            firstOdd = isOdd;
        }
        firstOdd = !firstOdd;
        if (counter > maxCounter) {
            maxCounter = counter;
        }
    }
    console.log(maxCounter);
}
Solve(['(3) (22) (-18) (55) (44) (3) (21)']);
Solve(['(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)']);
Solve(['  ( 2 )  ( 33 ) (1) (4)   (  -1  ) ']);
Solve(['(102)(103)(0)(105)  (107)(1)']);
Solve(['(2) (2) (2) (2) (2)']);