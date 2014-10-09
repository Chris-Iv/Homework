function findMostFreqWord(input) {
    var sorted = input.toLowerCase().split(/[^a-zA-z]+/);
    sorted.sort();
    var counter = 1;
    var max = 0;
    var wordsCount = {};
    for (var i = 1; i < sorted.length; i++) {
        if (sorted[i-1] == sorted[i]) {
            counter++;
            wordsCount[sorted[i]] = counter;
            if (counter >= max) {
                max = counter;
            }
        } else {
            counter = 1;
        }
    }
    var result = "";
    for (var word in wordsCount) {
        if (wordsCount[word] === max) {
            result += word + " -> " + wordsCount[word] + " times" + "\n";
        }
    }
    console.log(result);
}
findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');