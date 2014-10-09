function findLargestBySumOfDigits(nums) {
    if (arguments.length < 1) {
        return undefined;
    }
    var max = 0;
    var result = 0;
    for (var i = 0; i < nums.length; i++) {
        if (parseInt(nums[i]) != nums[i]) {
            return undefined;
        }
        var number = Math.abs(nums[i]).toString();
        var temp = 0;
        for (var j = 0; j < number.length; j++) {
            temp += Number(number[j]);
        }
        if (temp > max) {
            max = temp;
            result = nums[i];
        }
    }
    return result;
}
console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));