function findPalindromes(input) {
    var result = [];
    var str = input.toLowerCase();
    var words = str.split(/\W+/);
    for (var i = 0; i < words.length; i++) {
        if (words[i] == words[i].split('').reverse().join('')) {
            result.push(words[i]);
        }
    }
    console.log(result.join(', '));
}
findPalindromes('There is a man, his name was Bob.');